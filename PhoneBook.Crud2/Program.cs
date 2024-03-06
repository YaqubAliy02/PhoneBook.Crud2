using PhoneBook.Crud2.Models;
using PhoneBook.Crud2.Serivces.Contacts;
using System;
namespace PhoneBook.Crud2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IContactService contactService = new ContactService();
            bool process = true;
            do
            {
                PrintMenu();

                Console.Write("Enter your choice:");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        Contact contact = new Contact();

                        Console.Write("Enter id: ");
                        string userIdStr = Console.ReadLine();
                        int userId = Convert.ToInt32(userIdStr);
                        contact.Id = userId; 

                        Console.Write("Enter name: ");
                        string nameOfItem = Console.ReadLine();
                        contact.Name = nameOfItem;
                        
                        Console.Write("Enter phoneNumber: ");
                        string phoneNumberOfItem = Console.ReadLine();
                        contact.Phone = phoneNumberOfItem;
                        contactService.AddContact(contact);
                        break;

                    case "2":
                        Console.Clear();
                        Contact contact2 = new Contact();
                        contactService.ShowContacts(contact2);
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Enter an id which you want to delete");
                        Console.Write("Enter id:");
                        string deleteWithIdStr = Console.ReadLine();
                        int deleteWithId = Convert.ToInt32(deleteWithIdStr);

                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Enter an id which you want  to edit");
                        Console.Write("Enter an id:");
                        string idStr = Console.ReadLine();
                        int id = Convert.ToInt32(idStr);
                        Console.Write("Enter name:");
                        string name = Console.ReadLine();
                        Console.Write("Enter phoneNumber:");
                        string phoneNumber = Console.ReadLine();

                        break;                                

                    case "0":
                        Console.Clear();
                        if (userChoice == "0")
                        {
                            process = false;
                            Console.WriteLine("Thank you for coming to our console app!!! '");
                        }
                        break;

                    default:
                        Console.WriteLine("You entered wrong input, Try again");
                        break;
                }
            }
            while (process);

        }
        public static void PrintMenu()
        {
            Console.WriteLine("1.Add phone books");
            Console.WriteLine("2.Display phoneBooks");
            Console.WriteLine("3.Delete phone book by id");
            Console.WriteLine("4.Update by id");
            Console.WriteLine("0.Exit");
        }
    }
}


