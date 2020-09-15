using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using FinChat.ChatBots.StockQuotation.Interfaces;

namespace FinChat.ChatBots.StockQuotation.Tools
{
    public class StockQuotationBot: IBot
    {
        public StockQuotationBot(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }

        public string Execute(string stockCode)
        {
            using var client = new WebClient();
            using var stream =  new MemoryStream(client.DownloadData($"https://stooq.com/q/l/?s={stockCode}&f=sd2t2ohlcv&h&e=csv,"));
            using var reader = new StreamReader(stream);
            var header = true;
            string stock = null;
            string stockValue = null;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (header)
                {
                    header = false;
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] values = line.Split(',');
                    stock = values[0];
                    stockValue = values[3];
                }
            }
            
            var output = stockValue == "N/D" ? $"{stock} has no quotation" : $"{stock} quote is ${stockValue} per share";

            return output;
        }
    }
}