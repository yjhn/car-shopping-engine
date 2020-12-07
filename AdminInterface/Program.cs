using DataTypes;
using Frontend;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminInterface
{
    // This console app will serve as the admin interface for the program


    class Program
    {
        public static IApiWrapper Api;
        public static bool LoggedIn = false;
        public static string username;
        public static string password;

        static void Main()
        {
            Api = new ApiWrapper(new Uri("https://localhost:5001/"));
            Console.WriteLine("Welcome to Car Shopping Engine administrator console");
            while (!LoggedIn)
            {
                Login();
            }
            while (true)
            {
                CommandProcessor();
            }
        }


        // command structure: <fn> [<subject/object>] [<args>]
        static void CommandProcessor()
        {
            string c = Console.ReadLine();
            string command = c.ToLower();
            if (command == null)
            {
                CommandProcessor();
                return;
            }
            string[] splitCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            switch (splitCommand.Length)
            {
                case 0:
                    break;
                case 1: // functions which do not take arguments: login ; logout ; exit
                    ProcessNoArgsCommands(splitCommand[0]);
                    break;
                case 2: // functions which take 1 arg: ?
                    ProcessOneArgCommands(splitCommand[0], splitCommand[1]);
                    break;
                case 3: // functions which take multiple args: delete user <username[s]> ; delete ad <id[s]> ; disable ad <id[s]> ; disable user <id[s]> (hides ads from this user) ; show users <usernames> show ads <ids>
                    ProcessThreeArgsCommands(splitCommand);
                    break;
                case 4: // show disabled ads/users
                    //ProcessFourArgsCommands(splitCommand);
                    break;
                default:
                    Console.WriteLine($"There is no command that takes {splitCommand.Length - 1} arguments");
                    break;
            }
            return;
        }

        //private static void ProcessFourArgsCommands(string[] commands)
        //{
        //    string fn = commands[0];
        //    string adj = commands[1];
        //    string obj = commands[2];
        //    string argsJoined = commands[3];
        //    string[] args = argsJoined.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        //    switch (fn)
        //    {
        //        case "disabled":
        //            switch (adj)
        //            {
        //                case "users":

        //                case "ads":
        //            }
        //    }
        //}

        private static void ProcessThreeArgsCommands(string[] commands)
        {
            string fn = commands[0];
            string obj = commands[1];
            string argsJoined = commands[2];
            string[] args = argsJoined.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            switch (fn)
            {
                case "delete":
                    ProcessTwoArgFn(fn, obj, args, Api.DeleteUsers, Api.DeleteAds);
                    break;
                case "disable":
                    ProcessTwoArgFn(fn, obj, args, Api.DisableUsers, Api.HideAds);
                    break;
                case "enable":
                    ProcessTwoArgFn(fn, obj, args, Api.EnableUsers, Api.UnhideAds);
                    break;
                case "show":
                    ProcessShow(obj, args);
                    break;
                default:
                    Console.WriteLine($"Command '{fn}' not recognized.");
                    break;
            }
        }

        private static void ProcessShow(string obj, string[] args)
        {
            switch (obj)
            {
                case "user":
                    // need to actually show this
                    Show(Api.GetFullUser(args[0], username, password).Result);
                    break;
                case "ad":
                    Show(Api.GetAd(Convert.ToInt32(args[0])).Result);
                    break;
                case "ads":
                    int[] ids = new int[args.Length];
                    for(int i = 0; i < args.Length; i++)
                    {
                        ids[i] = Convert.ToInt32(args[i]);
                    }
                    ShowList(Api.GetAds(ids).Result);
                    break;
                default:
                    Console.WriteLine($"Command 'show {obj}' not recognized.");
                    break;
            }
        }

        private static void ShowList<T>(IList<T>list)
        {
            foreach(T obj in list)
            {
                Console.WriteLine(obj.ToString());
            }
        }

        private static void Show(object obj)
        {
            // for now
            Console.WriteLine(obj.ToString());
        }

        public static void ProcessTwoArgFn(string fn, string obj, string[] args, Func<string[], string, string, Task<Response>> stringArrMethod, Func<int[], string, string, Task<Response>> intArrMethod)
        {
            switch (obj)
            {
                case "users":
                    Console.WriteLine(stringArrMethod(args, username, password).Result);
                    break;
                case "ads":
                    int[] ids = new int[args.Length];
                    bool success = false;
                    for (int i = 0; i < args.Length; i++)
                    {
                        success = int.TryParse(args[i], out int a);
                        if (success)
                        {
                            ids[i] = a;
                        }
                        else
                        {
                            Console.WriteLine($"Id nr {i} = '{args[i]}' is not a number");
                            break;
                        }
                    }
                    if (success)
                    {
                        Console.WriteLine(intArrMethod(ids, username, password).Result);
                    }
                    break;
                default:
                    Console.WriteLine($"Command '{fn} {obj}' not recognized.");
                    break;
            }
        }

        private static void ProcessOneArgCommands(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        private static void ProcessNoArgsCommands(string command)
        {
            switch (command)
            {
                case "login":
                    if (LoggedIn)
                    {
                        Console.WriteLine("You have to log out first");
                    }
                    else
                    {
                        Login();
                    }
                    break;
                case "logout":
                    if (LoggedIn)
                    {
                        LoggedIn = false;
                        username = null;
                        password = null;
                    }
                    else
                    {
                        Console.WriteLine("You are not logged in");
                    }
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine($"Command '{command}' does not exist.");
                    break;
            }
        }

        private static void Login()
        {
            Console.WriteLine("username:");
            username = Console.ReadLine();
            Console.WriteLine("password:");
            password = Console.ReadLine();

            User user = Api.GetUser(username, password).Result;
            if (user == null)
            {
                Console.WriteLine("Bad username or password");
            }
            else
            {
                if (user.Role != UserRole.Admin)
                {
                    Console.WriteLine($"You are not an administrator. Your role is '{user.Role}'.");
                    username = null;
                    password = null;
                }
                else
                {
                    LoggedIn = true;
                    Console.WriteLine("Welcome, " + user.Username);
                }
            }
        }
    }
}