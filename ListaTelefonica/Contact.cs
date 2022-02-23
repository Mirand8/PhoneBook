using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTelefonica
{
    public class Contact
    {
        public Contact Previous { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public PhoneList PhoneList { get; set; }
        public Contact Next { get; set; }

        public Contact() { }

        public Contact(string name, string email, PhoneList phoneList)
        {
            Name = name;
            Email = email;
            PhoneList = phoneList;
            Next = null;
            Previous = null;
        }

        public override string ToString()
        {
            return $"\tNome: {Name}\n\tEmail: {Email}\n\tTelefone: {PhoneList}";
        }
    }
}
