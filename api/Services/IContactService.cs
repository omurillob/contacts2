using contacts2.Models;

namespace contacts2.Services
{
    public interface IContactService
    {
        List<Contact> GetContacts();
        Contact? GetContactById(int id);
        void AddorUpdateContact(Contact contact);
    }
}