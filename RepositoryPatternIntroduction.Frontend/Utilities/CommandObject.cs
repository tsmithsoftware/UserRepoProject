namespace RepositoryPatternIntroduction.Frontend.Utilities
{
    public static class CommandObjectGenerator
    {
        public static CommandObject ReturnCommandObject(string stringToParse)
        {
            return new CommandObject(stringToParse);
        }
    }
    public class CommandObject
    {
        public Command Command { get; set; }

        public string PersonName { get; set; }

        public string PersonAge { get; set; } = "";

        public CommandObject(string stringToParse)
        {
            string[] splitString = stringToParse.Split(" ".ToCharArray());
            Command = CommandParser.ParseCommand(splitString[0]);
            for (int i = 0; i < splitString.Length; i++)
            {
                if (i == 1)
                {
                    PersonName = splitString[i];
                }
                if (i == 2)
                {
                    PersonAge = splitString[i];
                }
            }
            Command = CommandParser.ParseCommand(splitString[0]);
        }
    }
}
