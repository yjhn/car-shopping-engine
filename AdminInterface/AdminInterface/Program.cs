using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdminInterface
{
    class Program
    {
        private static swaggerClient _api;
        private static bool LoggedIn = false;
        private static string username;
        private static string password;

        static void Main()
        {
            _api = new swaggerClient("https://car-shopping-engine.azurewebsites.net", new System.Net.Http.HttpClient());
            Console.WriteLine("Welcome to Car Shopping Engine administrator console");
            while (!LoggedIn)
                Login();
         
            while (true)
                CommandProcessor();
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
                    ProcessTwoArgsCommands(splitCommand);
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

        private static void ProcessTwoArgsCommands(string[] commands)
        {
            string fn = commands[0];
            string obj = commands[1];
            string argsJoined = commands[2];
            string[] args = argsJoined.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            switch (fn)
            {
                case "delete":
                    ProcessTwoArgFn(fn, obj, args, _api.DeleteUsersAsync, _api.DeleteAdsAsync, "Deleted ");
                    break;
                case "disable":
                    ProcessTwoArgFn(fn, obj, args, _api.DisableUsersAsync, _api.HideAdsAsync, "Disabled ");
                    break;
                case "enable":
                    ProcessTwoArgFn(fn, obj, args, _api.EnableUsersAsync, _api.UnhideAdsAsync, "Enabled ");
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
                    try
                    {
                        var result = _api.GetFullUserAsync(args[0]).Result;
                        Show(result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                    break;
                case "ad":
                    try
                    {
                        var result = _api.GetAdAsync(Convert.ToInt32(args[0])).Result;
                        Show(result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                    break;
                case "ads":
                    int[] ids = new int[args.Length];
                    bool success = false;
                    for (int i = 0; i < args.Length; i++)
                    {
                        success = int.TryParse(args[i], out int a);
                        if (success)
                            ids[i] = a;
                        else
                        {
                            Console.WriteLine($"Id nr {i} = '{args[i]}' is not a number");
                            success = false;
                            break;
                        }
                    }
                    if (success)
                    {
                        try
                        {
                            var result = _api.GetAdsAsync(ids).Result;
                            Show(result);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                        }
                    }
                    break;
                default:
                    Console.WriteLine($"Command 'show {obj}' not recognized.");
                    break;
            }
        }

        private static void Show<T>(IEnumerable<T> list)
        {
            Console.WriteLine(list.ToString<T>());
            //foreach(T obj in list)
            //{
            //    Console.WriteLine(obj.ToString());
            //}
        }

        private static void Show(object obj)
        {
            Console.WriteLine(obj.ToString());
        }

        public static void ProcessTwoArgFn(string fn, string obj, string[] args, Func<string[], Task<int>> stringArrMethod, Func<int[], Task<int>> intArrMethod, string textToWrite)
        {
            switch (obj)
            {
                case "users":
                    try
                    {
                        int result = stringArrMethod(args).Result;
                        Console.WriteLine($"{textToWrite}{result}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                    break;
                case "ads":
                    int[] ids = new int[args.Length];
                    bool success = false;
                    for (int i = 0; i < args.Length; i++)
                    {
                        success = int.TryParse(args[i], out int a);
                        if (success)
                            ids[i] = a;
                        else
                        {
                            Console.WriteLine($"Id nr {i} = '{args[i]}' is not a number");
                            success = false;
                            break;
                        }
                    }
                    if (success)
                    {
                        try
                        {
                            int result = intArrMethod(ids).Result;
                            Console.WriteLine($"{textToWrite}{result}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                        }
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
                        Console.WriteLine("You have to log out first");
                    else
                        Login();
                    break;
                case "logout":
                    if (LoggedIn)
                    {
                        LoggedIn = false;
                        username = null;
                        password = null;
                        _api.RemoveUser();
                    }
                    else
                        Console.WriteLine("You are not logged in");
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
            _api.SetUser(username, password);
            try
            {
                OutgoingFullUserDTO user = _api.GetFullUserAsync(username).Result;
                if (user.Role != "admin")
                {
                    Console.WriteLine($"You are not an administrator. Your role is '{user.Role}'.");
                    username = null;
                    password = null;
                    _api.RemoveUser();
                }
                else
                {
                    LoggedIn = true;
                    Console.WriteLine("Welcome, " + user.Username);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }

    public static class ListExtensionMethods
    {
        public static string ToString<T>(this IEnumerable<T> list)
        {
            StringBuilder s = new StringBuilder();
            foreach (T a in list)
            {
                s.Append($" {a}\n");
            }
            return s.ToString();
        }
    }
}