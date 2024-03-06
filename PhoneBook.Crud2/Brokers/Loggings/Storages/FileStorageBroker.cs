using PhoneBook.Crud2.Models;
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
