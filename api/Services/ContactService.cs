using contacts2.Models;

namespace contacts2.Services
{
    public class ContactService
    {
        private static List<Contact> _contacts = new List<Contact>()
        {
            { new Contact { Id = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "123-456-7890" } },
            { new Contact { Id = 2, FirstName = "Jane", LastName = "Smith", PhoneNumber = "987-654-3210" } }
        };

        public List<Contact> GetContacts()
        {
            return _contacts.ToList(); // Return a copy to avoid modification of internal list
        }

        public Contact GetContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateContact(Contact contact)
        {
            var existingContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.PhoneNumber = contact.PhoneNumber;
            }
        }
    }
}