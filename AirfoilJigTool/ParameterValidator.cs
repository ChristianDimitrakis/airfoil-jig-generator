using System;
using System.Collections.Generic;

namespace AirfoilJigTool
{
    public class ParameterValidator
    {
        private readonly HashSet<string> validParameters = new HashSet<string> { "--chordlength", "--thickness" };
        private readonly Dictionary<string, string> parameters = new Dictionary<string, string>
        {
            { "--chordlength", "defaultChordLength" }, // Default value
            { "--thickness", "defaultThickness" }      // Default value
        };

        public Dictionary<string, string> ValidateAndParse(string[] args)
        {
            var invalidParameters = new List<string>();

            for (int i = 0; i < args.Length; i++)
            {
                if (validParameters.Contains(args[i]) && i + 1 < args.Length)
                {
                    parameters[args[i]] = args[i + 1];
                    i++; // Skip the next argument as it's the value
                }
                else
                {
                    invalidParameters.Add(args[i]);
                }
            }

            if (invalidParameters.Count > 0)
            {
                Console.WriteLine("Invalid parameters:");
                foreach (var param in invalidParameters)
                {
                    Console.WriteLine(param);
                }
            }

            return parameters;
        }
    }
}