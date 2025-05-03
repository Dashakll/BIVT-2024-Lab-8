using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output; // кортеж из символа и числа
        public (char, double)[] Output => _output;
        public Blue_3(string input) : base(input)
        {
            _output = null;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;
            string[] words = Input.Split(' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/');
            string result = "";
            int counter = 0;

            if (words.Length == 0) return;
            foreach (string w in words)
            {
                if (!string.IsNullOrEmpty(w))
                {
                    char first_let = w[0];
                    if (char.IsLetter(first_let))
                    {
                        result += char.ToLower(first_let);
                    }
                }
            }
            (char, double)[] letters = new (char, double)[result.Length];
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = ('\0', 0);
            }
            foreach (char r in result)
            {
                bool fnd = false;
                for (int i = 0; i < letters.Count(); i++)
                {
                    if (letters[i].Item1 == r)
                    {
                        letters[i] = (r, letters[i].Item2 + 1);
                        fnd = true;
                        break;
                    }
                }
                if (!fnd)
                {
                    for (int j = 0; j < letters.Length; j++)
                    {
                        if (letters[j].Item1 == '\0')
                        {
                            letters[j] = (r, 1);
                            counter++;
                            break;
                        }
                    }
                }
            }

            var result2 = new (char, double)[counter];
            int all_let = result.Count();
            int index = 0;

            foreach (var item in letters)
            {
                if (!(item.Item1 == '\0'))
                {
                    double perc = (item.Item2 / all_let) * 100;
                    result2[index] = (item.Item1, perc);
                    index++;
                }
            }
            (char, double)[] new_result = result2.OrderByDescending(t => t.Item2).ThenBy(t => t.Item1).ToArray();
            _output = new_result;
        }

        public override string ToString()
        {
            if (_output == null) return null;
            return string.Join(Environment.NewLine, _output.Select(p => $"{p.Item1} - {p.Item2:F4}"));
        }
    }
}
