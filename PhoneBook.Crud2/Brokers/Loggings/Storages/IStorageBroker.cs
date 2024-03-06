
using PhoneBook.Crud2.Models;
using System;
namespace PhoneBook.Crud2.Brokers.Loggings.Storages
{
    internal interface IStorageBroker
    {
       Contact AddContact(Contact contact);
        Contact[] ReadAllContact();
    }
}
