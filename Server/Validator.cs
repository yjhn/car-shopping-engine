using System;
using System.Configuration;
using System.Collections.Generic;

namespace Server
{
    static class Validator
    {
        public static Validation ValidateRequest(Request req)
        {
            switch (req.Method)
            {
                case "GET":
                    break;
                case "POST":
                    break;
                case "DELETE":
                    break;
                default:
                    return Validation.UnknownMethod;
            }
            if (req.HttpVersion != "HTTP/1.1")
                return Validation.HttpVersionNotSupported;
            string resource = req.Resource;
            //bool isUrlValid = ValidateString(@"^[\/]+$", resource);
            //bool isUrlValid = ValidateString(@"^(https?:\/\/)?(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})$", resource);
            bool isUrlValid = ValidateString(@"^(https?:\/\/)?(([a-zA-Z\d\.\-_]+\.)*[a-zA-Z](:\d{1,5})?)?\/([a-zA-Z\/\d]*)$", resource);
            if (!isUrlValid)
                return Validation.InvalidUrl;
            int temp = resource.IndexOf("://") + 3;
            if (temp == 2)
                temp = 0;
            int resNameStart = resource.IndexOf("/", temp);
            string resName = resource.Substring(resNameStart + 1, resource.Length - resNameStart - 1);
            req.Resource = resName;

            Dictionary<string, string> queries = req.Queries;
            foreach (KeyValuePair<string, string> kvp in queries)
                if (string.IsNullOrEmpty(kvp.Value))
                    return Validation.EmptyQuery;

            // check Host header
            List<Header> headers = req.Headers;
            if (!Header.Contains(headers, "HOST"))
                return Validation.NoHost;
            foreach (Header h in req.Headers)
                if (string.IsNullOrEmpty(h.Value))
                    return Validation.EmptyHeader;

            // Host header validity
            string hostValue = Header.GetValueByName(headers, "HOST");
            bool isHostValid = ValidateString(@"^([a-zA-Z\d\.\-_]+\.)?[a-zA-Z]+(:\d{1,5})?$", hostValue);
            if (!isHostValid)
                return Validation.InvalidHost;

            // if full URL was set in resource part, its Host header should match it
            if (resource.StartsWith("http"))
            {
                int hostFromUrlIndex = resource.IndexOf("://") + 3;
                string hostFromUrl = resource.Substring(hostFromUrlIndex, resource.IndexOf("/") - hostFromUrlIndex);
                if (hostFromUrl != hostValue)
                    return Validation.HostMismatch;
            }

            if (req.Method == "POST" && !Header.Contains(headers, "CONTENT-LENGTH"))
                return Validation.NoContentLength;

            return Validation.OK;
        }

        private static bool ValidateString(string regex, string checking)
        {
            RegexStringValidator validator = new RegexStringValidator(regex);
            try
            {
                validator.Validate(checking);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }
    }

    enum Validation
    {
        UnknownMethod,
        HttpVersionNotSupported,
        InvalidUrl,
        EmptyQuery,
        EmptyHeader,
        InvalidHost,
        HostMismatch,
        NoContentLength,
        NoHost,
        OK
    };
}