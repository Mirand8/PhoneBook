using System;

namespace ListaTelefonica
{
    public class PhoneList
    {
        public Phone Head { get; set; }
        public Phone Tail { get; set; }
        public int Count { get; set; }

        public PhoneList()
        {
            Head = Tail = null;
        }

        public void Insert(Phone aux)
        {
            if (IsEmpty())
            {
                Head = Tail = aux;
            }
            else
            {
                Tail.Next = aux;
                Tail = aux;
            }
        }

        public void Edit(Phone phone)
        {
            Console.Clear();
            Console.WriteLine("-=-=-=-=-=-=-=-=- EDITOR =-=-=-=-=-=-=-=-=-=");
            Console.WriteLine(phone);
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Qual informacao deste telefone deseja editar?");
            Console.WriteLine("1. Numero");
            Console.WriteLine("2. DDD");
            Console.WriteLine("3. Tipo");
            Console.WriteLine("0. Voltar para o Menu");
            int option = 4;
            while (option != 0)
            {
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Digite o novo numero do contato: ");
                        string number = Console.ReadLine();
                        phone.Number = number;
                        Console.WriteLine($"{phone.Number} mudado para {number}");
                        break;
                    case 2:
                        Console.WriteLine("Digite o novo numero do contato: ");
                        int ddd = int.Parse(Console.ReadLine());
                        phone.DDD = ddd;
                        Console.WriteLine($"{phone.DDD} mudado para {ddd}");
                        break;
                    case 3:
                        Console.WriteLine("Digite o novo numero do contato: ");
                        string type = Console.ReadLine();
                        phone.Type = type;
                        Console.WriteLine($"{phone.Type} mudado para {type}");
                        break;
                }
            }
            Console.ReadKey();
        }

        public Phone Search(string phoneSearch)
        {
            Phone search = null;
            bool found = false;
            if (!IsEmpty())
            {
                Phone aux = Head;
                do
                {
                    if (aux.Number.Equals(phoneSearch.ToUpper()))
                    {
                        search = aux;
                        found = true;
                    }
                    else
                    {
                        Console.WriteLine("O telefone nao esta na lista!");
                    }
                    aux = aux.Next;
                } while (aux != null && !found);
            }
            else
            {
                Console.WriteLine("Nenhum telefone cadastrado!");
            }
            return search;
        }

        bool IsEmpty()
        {
            return Head == null && Tail == null;
        }

        public override string ToString()
        {
            string text = "[";
            if (IsEmpty())
            {
                Console.WriteLine("[Lista de Telefones esta vazia!]");
            }
            else
            {
                Phone aux = Head;
                do
                {
                    if (aux.Next == null)
                    {
                        text += $"{aux}";
                    }
                    else
                    {
                        text += $"{aux} // ";
                    }
                    aux = aux.Next;
                    Console.ReadKey();
                } while (aux != null);
            }
            text += "]";
            return text;
        }

    }
}