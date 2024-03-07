using PhoneBook.Crud2.Models;
namespace PhoneBook.Crud2.Serivces.Contacts
{
    internal interface IContactService
    {
       Contact AddContact(Contact contact);
        void ShowContacts();
        void Update(Contact contact);
        void Delete(int id);

    }
}
