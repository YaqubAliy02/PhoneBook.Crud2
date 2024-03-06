using PhoneBook.Crud2.Models;
using System;
using System.IO;

namespace PhoneBook.Crud2.Brokers.Loggings.Storages
{
    internal class FileStorageBroker : IStorageBroker
    {
        private const string FILEPATH = "../../../Assets/Contacts.txt";
        public FileStorageBroker()
        {
            EnsureFileExists();
        }
        public Contact AddContact(Contact contact)
        {
            string contactLine = $"{contact.Id}* {contact.Name}*{contact.Phone}\n";

            File.AppendAllText(FILEPATH, contactLine);
            return contact;

        }

        public Contact[] ReadAllContact()
        {
            string[] contactLines = File.ReadAllLines(FILEPATH);
            int contactLenth = contactLines.Length;
            Contact[] contacts = new Contact[contactLenth];

            for(int iteration = 0; iteration < contactLenth; iteration++)
            {
                string contactLine = contactLines[iteration];
                string[] contactProperties = contactLine.Split("*");

                Contact contact = new Contact
                {
                    Id = Convert.ToInt32(contactProperties[0]),
                    Name = contactProperties[1],
                    Phone = contactProperties[2]
                };
                contacts[iteration] = contact;
            }
            return contacts;
        }

        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FILEPATH);

            if (fileExists is false)
            {
                File.Create(FILEPATH).Close();
            }
        }
           
    }
}
