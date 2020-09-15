using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FinChat.ChatBots.StockQuotation.Interfaces;

namespace FinChat.ChatBots.StockQuotation.Tools
{
    public static class TextCommandHelper
    {
        private static readonly Regex Pattern = new Regex("(\\/)(\\w+)(=)(\\w+.\\w+)");
        private static readonly string[] AvailableCommands =  {"stock"};

        public static bool IsCommand(string input)
        {
            return Pattern.IsMatch(input);
        }

        public static string GetCommand(string input)
        {
            return Pattern.Match(input).Groups[2].Value;
        }

        public static string GetCommandValue(string input)
        {
            return Pattern.Match(input).Groups[4].Value;
        }

        public static bool IsCommandAvailable(string command)
        {
            return AvailableCommands.Contains(GetCommand(command));
        }

        public static string GetAvailableCommandsList()
        {
            return string.Join(',', AvailableCommands);
        }
    }
}