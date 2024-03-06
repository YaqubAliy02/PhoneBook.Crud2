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
            Contact contact = new Contact
            {
                Id = 1,
                Name = "YaqubAliy Majamolov",
                Phone = "2345678"
            };
            contactService.AddContact(new Contact());
        }
    }
}

