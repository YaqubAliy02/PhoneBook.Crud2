using PhoneBook.Crud2.Brokers.Loggings;
using PhoneBook.Crud2.Brokers.Storages;
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

     

        public void ShowContacts()
        {
            Contact[] contacts = this.storageBroker.ReadAllContact();

            foreach (Contact contact in contacts)
            {
                this.loggingBroker.LogInforamation($"{contact.Id}, {contact.Name} - {contact.Phone}");
            }
            this.loggingBroker.LogInforamation("===End of contacts");
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

        public void DeleteContact( int id)
        {
            Contact[] contacts = this.storageBroker.ReadAllContact();
            for (int i = 0; i < contacts.Length; i++)
            {
                if (contacts[i] != null && contacts[i].Id == id)
                {
                    contacts[i] = null;
                    this.loggingBroker.LogInforamation($"PhoneBook with ID {id} deleted successfully.");
                    return;
                }
            }
            this.loggingBroker.LogError($"PhoneBook with ID {id} not found.");
        }

        public void Update(Contact contact)
        {
            if (contact is null)
            {
                this.loggingBroker.LogError("Your contact is empty");
                return;
            }

            if (contact.Id == 0 || String.IsNullOrEmpty(contact.Name) || String.IsNullOrEmpty(contact.Phone))
            {
                this.loggingBroker.LogError("Your contact is invalid");
            }

            this.storageBroker.UpdateContact(contact);
        }

        public void Delete(int id)
        {
            this.storageBroker.DeleteContact(id);
        }
    }
}

