using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output => _output;

        public Blue_1(string input) : base(input)
        {
            _output = null;
        }

        // статический вспомогательный метод для добавления строки в массив строк
        private static void Add(ref string[] strings, string str)
        {
            if (strings == null || string.IsNullOrEmpty(str)) return;
            string[] new_strings = new string[strings.Length + 1];
            Array.Copy(strings, new_strings, strings.Length);
            new_strings[strings.Length] = str;
            strings = new_strings;
        }


        // Метод разбивает исходную строку на подстроки длиной не более 50 символов, не разрывая слова
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            _output = Input.Split(' ');
            string[] result = new string[0];
            int counter = 0;
            for (int i = 0; i < _output.Length;)
            {
                string f = "";
                counter = _output[i].Length;
                while (counter <= 50)
                {
                    f += _output[i++] + " "; 
                    if (i != _output.Length)
                        counter += _output[i].Length + 1; 
                    else break;
                }

                Add(ref result, f.Substring(0, f.Length - 1));

            }
            _output = result;

        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0) { return string.Empty; }
            return string.Join(Environment.NewLine, _output); 
        }

    }
}
