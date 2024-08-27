using contacts2.Models;

namespace contacts2.Services
{
    public class ContactService(ContactsDbContext context) : IContactService
    {
        public List<Contact> GetContacts()
        {
            var contacts = context.Contacts.ToList();
            return contacts;
        }

        public Contact? GetContactById(int id)
        {
            return context.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public void AddorUpdateContact(Contact contact)
        {
            var existingContact = context.Contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.PhoneNumber = contact.PhoneNumber;
            }
            else
            {
                contact.Id = context.Contacts.Max(x => x.Id) + 1;
                context.Contacts.Add(contact);
                context.SaveChanges();
            }
        }
    }
}