using System;

namespace RepositoryPatternIntroduction.Frontend.Utilities
{
    public class CommandParser
    {
        public static Command ParseCommand(string stringToParse)
        {
            return (Command) Enum.Parse(typeof(Command), stringToParse.ToUpper());
        }
    }
}
