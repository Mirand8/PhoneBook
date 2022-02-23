using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTelefonica
{
    public class Phone
    {
        public string Number { get; set; }
        public int DDD { get; set; }
        public string Type { get; set; }
        public Phone Next { get; set; }

        public Phone(string number, int dDD, string type)
        {
            Number = FormatPhone(number);
            DDD = dDD;
            Type = type;
            Next = null;
        }

        public static string FormatPhone(string phone)
        {
            string phoneFormated, after = "", before = "", middle = "-";
            int i = 0;
            foreach (char number in phone)
            {
                if (i <= 3)
                {
                    after += number;
                }
                else
                {
                    before += number;
                }
                i++;
            }
            phoneFormated = after + middle + before;
            return phoneFormated;
        }

        public override string ToString()
        {
            return $"{Type} => ({DDD}) {Number}";
        }
    }
}
