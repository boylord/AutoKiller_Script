using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKiller_Script
{
    public class DataContextProvider
    {
        private readonly string _userInput;
        private readonly char _delimiter;

        public IList<dynamic> OutData { get; private set; }
        public int OutDataCount { get; private set; }

        public DataContextProvider(string userInput, char delimiter = ';')
        {
            _userInput = userInput;
            _delimiter = delimiter;
            OutData = new List<dynamic>();
            OutDataCount = ParseUserInput();
        }

        private int ParseUserInput()
        {
            if (string.IsNullOrEmpty(_userInput))
                return 0;

            var tmpResult = _userInput.Split(_delimiter).ToList();

            tmpResult.ToList().ForEach(item =>
            {
                if (item.Contains("0x"))
                {
                    item = item.Replace(" ", "");
                    item = item.Substring(2);
                    ushort tmpShort = 0;
                    ushort.TryParse(item, NumberStyles.HexNumber,
                        CultureInfo.CurrentCulture,
                        out tmpShort);
                    if (tmpShort > 0)
                    {
                        OutData.Add(tmpShort);
                    }
                }
                else
                    OutData.Add(item);
            });

            return OutData.Count;
        }
    }

}
