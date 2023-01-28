using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearch
{
    public class Substring
    {
        public int SearchSubstringByBrutalForce(string text, string substring)
        {
            int t = 0;
            while (t <= text.Length - substring.Length)
            {
                int s = 0;
                while (s < substring.Length && text[t + s] == substring[s])
                    s++;

                if (s >= substring.Length)
                    return t;

                t++;
            }
            return -1;
        }
        public int SearchBoyerMoore(string text, string substring)
        {
            Dictionary<char, int> shiftTable = CreateShiftTable(substring);

            int shift = 0;
            while (shift < text.Length - 1)
            {
                for (int s = substring.Length - 1; s >= 0; s--)
                {
                    if (substring[s] != text[shift + s])
                    {
                        if (s == substring.Length - 1)
                        {
                            char symb = text[shift + s];
                            shift += shiftTable.ContainsKey(symb) ? shiftTable[symb] : substring.Length;
                        }
                        else
                        {
                            shift += shiftTable[substring[s]];
                        }
                        break;
                    }
                    else
                    {
                        if (s == 0)
                        {
                            return shift;
                        }
                    }
                }
            }
            return -1;
        }

        Dictionary<char, int> CreateShiftTable(string substring)
        {
            Dictionary<char, int> shift = new Dictionary<char, int>();
            for (int i = substring.Length - 2; i >= 0; i--)
            {
                if (!shift.ContainsKey(substring[i]))
                {
                    shift.Add(substring[i], substring.Length - 1 - i);
                }
            }

            if (!shift.ContainsKey(substring[substring.Length - 1]))
            {
                shift.Add(substring[substring.Length - 1], substring.Length);
            }
            return shift;
        }

    }
}
