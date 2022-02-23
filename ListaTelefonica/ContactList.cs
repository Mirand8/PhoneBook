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

        public void Insert(Contact newContact)
        {
            if (!IsEmpty())
            {
                Tail.Next = newContact;
                Tail = newContact;
                Head.Previous = null;
                Sort();
            }
            else
            {
                Head = Tail = newContact;
            }
            ItensCount++;
        }

        public void Sort()
        {
            for (Contact aux = Head; aux != null; aux = aux.Next)
            {
                Contact temp;
                for (Contact aux2 = Head.Next; aux2 != null; aux2 = aux2.Next)
                {
                    if (aux.Name.CompareTo(aux2.Name) > 0)
                    {
                        temp = aux;
                        aux = aux2;
                        aux2 = temp;
                    }
                }
            }
        }

        public void Remove(Contact contact)
        {
            if (!IsEmpty())
            {

            }
            else
            {
                Console.WriteLine("A lista esta vazia");
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

        public static void Print(Contact contact)
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
        }

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

        public bool IsEmpty() => Head == null;
    }
}
