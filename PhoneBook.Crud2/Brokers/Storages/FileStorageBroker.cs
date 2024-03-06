using PhoneBook.Crud2.Models;
using System;
using System.IO;
namespace PhoneBook.Crud2.Brokers.Storages
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
            string contactLine = $"{contact.Id}*{contact.Name}*{contact.Phone}\n";

            File.AppendAllText(FILEPATH, contactLine);
            return contact;
        }
        public void UpdateContact(Contact contact)
        {
            Contact[] contacts = ReadAllContact();
            for (int i = 0; i < contacts.Length; i++)
            {
                if (contacts[i].Id == contact.Id)
                {
                    contacts[i] = contact;
                    break;
                }
            }
            File.WriteAllText(FILEPATH, string.Empty);
            foreach (Contact contact1 in contacts)
            {
                AddContact(contact1);
            }
        }
        public Contact[] ReadAllContact()
        {
            string[] contactLines = File.ReadAllLines(FILEPATH);
            int contactLength = contactLines.Length;
            Contact[] contacts = new Contact[contactLength];

            for (int iteration = 0; iteration < contactLength; iteration++)
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

        public void DeleteContact(int id)
        {
            Contact[] contacts = this.ReadAllContact();
            File.WriteAllText(FILEPATH, string.Empty);

            for (int i = 0; i < contacts.Length; i++)
            {
                if (contacts[i].Id != id)
                {
                    this.AddContact(contacts[i]);
                }
            }
        }
    }
}
