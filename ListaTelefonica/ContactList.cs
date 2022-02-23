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
            Head = null;
            Tail = null;
            ItensCount = 0;
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
                Sort();
            }
            ItensCount++;
        }

        public void Sort()
        {

            for (Contact contact1 = Head; contact1 != null; contact1 = contact1.Next)
            {
                for (Contact contact2 = contact1.Next; contact2 != null; contact2 = contact2.Next)
                {
                    if (contact1.Name.CompareTo(contact2.Name) > 0)
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

        public void Remove(Contact contact)
        {
            if (IsEmpty())
            {
                Console.WriteLine("A lista esta vazia");
            }
            else
            {
                
            }
        }

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("A lista esta vazia!!");
            }
            else
            {
                Contact aux = Head;
                do
                {
                    Console.WriteLine(aux);
                    aux = aux.Next;
                    Console.ReadLine();
                } while (aux != null);
            }
        }

        /* public static void Print(Contact contact)
         {
             if (contact != null)
             {
                 Console.WriteLine(contact);
                 Console.ReadKey();
             }
             else
             {
                 Console.WriteLine("Contato nao encontrado!!");
                 Console.ReadKey();
             }
         }*/

        internal void Edit(Contact contact)
        {
            Console.Clear();
            Console.WriteLine("-=-=-=-=-=-=-=-=- EDITOR =-=-=-=-=-=-=-=-=-=");
            Console.WriteLine(contact);
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Qual informacao deste contato deseja editar?");
            Console.WriteLine("1. Nome");
            Console.WriteLine("2. Email");
            Console.WriteLine("3. Telefone");
            Console.WriteLine("0. Voltar para o Menu");
            int option = 4;
            while (option != 0)
            {
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Digite o novo nome do contato: ");

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
            }
            Console.ReadKey();
        }

        internal Contact Search(string nameSearch)
        {
            Contact search = null;
            bool found = false;
            if (IsEmpty())
            {
                Console.WriteLine("A lista esta vazia!!");
                Console.ReadKey();
            }
            else
            {
                Contact aux = Head;
                do
                {
                    if (aux.Name.Equals(nameSearch.ToUpper()))
                    {
                        search = aux;
                        found = true;
                    }
                    else
                    {
                        search = null;
                        Console.WriteLine("CONTATO NAO ENCONTRADO!!");
                    }
                    aux = aux.Next;
                } while (aux != null && !found);
            }
            return search;
        }

        public bool IsEmpty() => Head == null && Tail == null
            ? true
            : false;
    }
}
