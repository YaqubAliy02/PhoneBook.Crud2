﻿using PhoneBook.Crud2.Brokers.Loggings;
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

        // happy path
        public Contact AddContact(Contact contact) =>
          this.storageBroker.AddContact(contact);

        public void ShowContacts()
        {
            Contact[] contacts = this.storageBroker.ReadAllContact();

            foreach (Contact contact in contacts)
            {
                this.loggingBroker.LogInforamation($"{contact.Id}, {contact.Name} - {contact.Phone}");
            }
            this.loggingBroker.LogInforamation("===End of contacts");
        }
    }
}
