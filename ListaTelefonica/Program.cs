using System;

namespace ListaTelefonica
{
    internal class Program
    {
        // implemente uma lista de contatos, cada contato devera seguir as seguintes informacoes 
        // nome, email e telefones. Os telefones devem conter o tipo(residencial, comercial) o DDD e o numero
        // O programa deve ser capaz de inserir, localizar, remover, editar e imprimir os contatos

        static void Main(string[] args)
        {
            ContactList contactList = new();
            int option = 6;

            do
            {
                option = Menu();
                switch (option)
                {
                    case 0:
                        break;

                    // Inserir
                    case 1:
                        Console.Clear();
                        Console.WriteLine("=============== INSERIR ==============\n");
                        contactList.Insert(ReadContact());
                        BackToMenuMessage();
                        break;
                    // Buscar
                    case 2:
                        Console.Clear();
                        Console.WriteLine("============== PROCURAR ==============\n");
                        Console.WriteLine("\n-- DIGITE O NOME DO CONTATO QUE DESEJA PROCURAR --");

                        Contact contactToPrint = contactList.Search(ReadContactName());

                        if (contactToPrint != null)
                            Console.WriteLine(contactToPrint.ToString());
                        else
                            Console.WriteLine(" Contato não encontrado. ");


                        BackToMenuMessage();
                        break;
                    // Remover
                    case 3:
                        Console.Clear();
                        Console.WriteLine("=============== REMOVER ==============\n");
                        Console.WriteLine("\n-- DIGITE O NOME CONTATO QUE DESEJA REMOVER --");

                        Contact contactToRemove = contactList.Search(ReadContactName());

                        if (contactToRemove != null)
                            contactList.Remove(contactToRemove);
                        else
                            Console.WriteLine(" Contato não encontrado. ");

                        BackToMenuMessage();
                        break;
                    // Editar
                    case 4:
                        Console.WriteLine("=============== EDITAR ===============\n");
                        Console.Clear();
                        Console.WriteLine("\n-- DIGITE O NOME CONTATO QUE DESEJA EDITAR --");

                        Contact contactToEdit = contactList.Search(ReadContactName());

                        if (contactToEdit != null)
                            contactList.Edit(contactToEdit);
                        else
                            Console.WriteLine(" Contato não encontrado. ");
                        BackToMenuMessage();
                        break;
                    // Imprimir todos um por vez
                    case 5:
                        Console.Clear();
                        Console.WriteLine("========= TODOS OS CONTATOS ==========\n");
                        contactList.Print();

                        BackToMenuMessage();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Digite uma das opcoes!!");
                        BackToMenuMessage();
                        break;
                }
            } while (option != 0);
        }

        private static string ReadContactName()
        {
            Console.Write("Nome: ");
            return Console.ReadLine();
        }

        private static int Menu()
        {
            Console.Clear();
            Console.WriteLine("================= MENU PRINCIPAL ===============");
            Console.WriteLine("1. Inserir contato");
            Console.WriteLine("2. Buscar contato");
            Console.WriteLine("3. Remover contato");
            Console.WriteLine("4. Editar contato");
            Console.WriteLine("5. Mostrar todos os contatos");
            Console.WriteLine("0. Sair ");
            Console.Write("--> Opcao: ");
            int option = int.Parse(Console.ReadLine());

            return option;
        }

        private static void BackToMenuMessage()
        {
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nPressione qualquer coisa para voltar para o menu...");
            Console.ReadKey();
        }

        private static Contact ReadContact()
        {
            Console.WriteLine("INFORMACOES DE CONTATO ----");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Telefone=> ");
            PhoneList phoneList = ReadPhoneList();
            return new Contact(name.ToUpper(), email.ToUpper(), phoneList);
        }

        private static PhoneList ReadPhoneList()
        {
            PhoneList phoneList = new();

            int option = 1;

            while (option != 0)
            {
                Console.Write("\tTipo: ");
                string type = Console.ReadLine();
                Console.Write("\tDDD: ");
                int ddd = int.Parse(Console.ReadLine());
                Console.Write("\nNumero: ");
                string number = Console.ReadLine();

                Phone phone = new(number, ddd, type.ToUpper());
                phoneList.Insert(phone);

                Console.Write("Deseja adicionar mais um numero?\n[1] Sim\n[0] Não\n: ");
                option = int.Parse(Console.ReadLine());
            }

            return phoneList;
        }

    }
}
