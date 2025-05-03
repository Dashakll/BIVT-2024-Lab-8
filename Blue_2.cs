using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _s;
        public string Output => _output;
        public Blue_2(string input, string s) : base(input)
        {
            _output = null;
            _s = s;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_s))
            {
                _output = string.Empty;
                return;
            }
            string[] words = Input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string result = "";
            _output = Input;
            foreach (string w in words)
            {
                if (w != null)
                {
                    if (w.Contains(_s))
                    {
                        if (w.Contains(".") || w.Contains(",") || w.Contains(";"))
                        {
                            char[] l = new char[w.Length];
                            for (int i = 0; i < w.Length; i++) { l[i] = w[i]; }
                            if (w.Contains("\"")) { result = _output.Replace(w + " ", "\"\"" + l[l.Length - 1] + " "); }
                            else { result = _output.Replace(" " + w, "" + l[l.Length - 1]); }
                            _output = result;
                        }
                        else
                        {
                            result = _output.Replace(w + " ", "");
                            _output = result;
                        }

                    }
                }
            }
        }

        public override string ToString()
        {
            return _output;
        }
    }
}
