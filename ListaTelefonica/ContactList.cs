using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTelefonica
{
    internal class ContactList
    {
        public Contact Head { get; set; }
        public Contact Tail { get; set; }
        public int ItensCount { get; set; }

        public ContactList()
        {
            Head = Tail = null;
            ItensCount = 0;
        }



        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("A lista esta vazia!!");
                return;
            }

            Contact aux = Head;

            do
            {
                Console.WriteLine(aux);
                Console.ReadKey();
                aux = aux.Next;
            } while (aux != null);
        }

        public Contact Search(string nameSearch)
        {
            if (IsEmpty())
            {
                return null;
            }

            Contact contact = Head;

            do
            {
                if (contact.Name.Equals(nameSearch.ToUpper()))
                    return contact;

                contact = contact.Next;

            } while (contact != null);

            return null;
        }

        public void Insert(Contact newContact)
        {
            if (IsEmpty())
            {
                Head = newContact;
                Tail = newContact;
            }
            else
            {
                Tail.Next = newContact;
                newContact.Previous = Tail;
                Tail = newContact;
            }

            ItensCount++;

            Sort();
        }

        public void Edit(Contact contact)
        {
            int option = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("-=-=-=-=-=-=-=-=- EDITOR =-=-=-=-=-=-=-=-=-=");
                Console.WriteLine(contact.ToString());
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("Qual informacao deste contato deseja editar?");
                Console.WriteLine("1. Nome");
                Console.WriteLine("2. Email");
                Console.WriteLine("3. Telefone");
                Console.WriteLine("0. Voltar para o Menu");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Digite o novo nome do contato: ");
                        contact.Name = Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("Digite o novo email: ");
                        contact.Email = Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("Digite o qual telefone deseja trocar: ");
                        string numberSearch = Console.ReadLine();
                        contact.PhoneList.Edit(contact.PhoneList.Search(Phone.FormatPhone(numberSearch)));
                        break;
                }

            } while (option != 0);

            Console.ReadKey();

            Sort();
        }
        
        public void Remove(Contact contact)
        {
            if (Head.Name.Equals(contact.Name))
            {
                Head = Head.Next;
            }
            else if (Tail.Name.Equals(contact.Name))
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            else
            {
                

                for (Contact aux = Head; aux != null; aux = aux.Next)
                {
                    if (aux.Name.Equals(contact.Name))
                    {
                        aux.Next.Previous = aux.Previous;
                        aux.Previous.Next = aux.Next;

                        break;
                    }

                    aux = aux.Next;
                }
            }

            if (Head == null) Tail = null;

            ItensCount--;
        }

        public void Sort()
        {

            if (ItensCount <= 1) return;

            for (Contact contact1 = Head; contact1 != null; contact1 = contact1.Next)
            {
                for (Contact contact2 = contact1.Next; contact2 != null; contact2 = contact2.Next)
                {
                    if (String.Compare(contact1.Name, contact2.Name, StringComparison.CurrentCultureIgnoreCase) > 0)
                    {
                        Contact aux = new Contact();

                        aux.Name = contact1.Name;
                        aux.Email = contact1.Email;
                        aux.PhoneList = contact1.PhoneList;

                        contact1.Name = contact2.Name;
                        contact1.Email = contact2.Email;
                        contact1.PhoneList = contact2.PhoneList;

                        contact2.Name = aux.Name;
                        contact2.Email = aux.Email;
                        contact2.PhoneList = aux.PhoneList;
                    }
                }
            }
        }

        public bool IsEmpty() => Head == null && Tail == null ? true : false;
    }
}
