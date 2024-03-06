using PhoneBook.Crud2.Brokers.Loggings;
using PhoneBook.Crud2.Brokers.Loggings.Storages;
using PhoneBook.Crud2.Models;
using System;
namespace PhoneBook.Crud2.Serivces.Contacts
{
    internal class ContactService : IContactService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        public ContactService()
        {
            this.storageBroker = new FileStorageBroker();
            this.loggingBroker = new LoggingBroker();
        }
        public Contact AddContact(Contact contact)
        {
            return contact is null
                ? CreateAndLogInvalidContact()
                : ValidateAndAddContact(contact);
        }
        public void ShowContacts(Contact contact)
        {
            Contact[] contacts = this.storageBroker.ReadAllContact();

             DisplayAndLogInvalidContact(contacts, contact);
        }
        private Contact CreateAndLogInvalidContact()
        {
            this.loggingBroker.LogError("Contact is invalid");
            return new Contact();
        }
        private Contact ValidateAndAddContact(Contact contact)
        {
            if(contact.Id is 0 
               || String.IsNullOrWhiteSpace(contact.Name)
               || String.IsNullOrWhiteSpace(contact.Phone))
            {
                this.loggingBroker.LogError("Contact details missing.");
                return new Contact();
            }
            else
            {
                return this.storageBroker.AddContact(contact);
            }
        }
        private void DisplayAndLogInvalidContact(Contact[] contacts, Contact contact2)
        {
            if (contact2.Id is 0
              || String.IsNullOrWhiteSpace(contact2.Name)
              || String.IsNullOrWhiteSpace(contact2.Phone))
            {
                this.loggingBroker.LogError("Contact is empty ");
            }
            else
            {
                foreach (Contact contact in contacts)
                {
                    this.loggingBroker.LogInforamation($"{contact.Id}, {contact.Name} - {contact.Phone}");
                }
                this.loggingBroker.LogInforamation("===End of contacts");
            }

          
        }

      
    }
}

