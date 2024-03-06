using PhoneBook.Crud2.Models;
namespace PhoneBook.Crud2.Brokers.Storages
{
    internal interface IStorageBroker
    {
        Contact AddContact(Contact contact);
        Contact[] ReadAllContact();
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
    }
}
