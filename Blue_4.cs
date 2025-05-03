using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;
        public int Output => _output;
        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;
            int nown = 0;
            bool dg = false; 
            foreach (char d in Input)
            {
                if (Char.IsDigit(d))
                {
                    if (!dg)
                    {
                        nown = (int)d - '0';
                        dg = true;
                    }
                    else { nown = nown * 10 + (int)d - '0'; } //'0' = 48, *10 добавление нового разряда
                }
                else if (!Char.IsDigit(d) && dg)
                {
                    dg = false;
                    _output += nown;
                    nown = 0;
                }
            }
            if (dg)
            {
                _output += nown;
            }
        }
        public override string ToString()
        {
            return $"{_output}";
        }
    }
}
