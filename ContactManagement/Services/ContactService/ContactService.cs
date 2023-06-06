using ContactManagement.Data;
using ContactManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly DataContext _context;

        public ContactService(DataContext context)
        {
            _context = context;
        }

        public async Task<Contact?> GetSingle(int id)
        {
            var c = await _context.Contacts.FindAsync(id);
            if (c is null)
            {
                return null;
            }

            return c;
        }

        public async Task<List<Contact>> GetAll()
        {
            var contacts = await _context.Contacts.ToListAsync();

            return contacts;
        }

        public async Task<List<Contact>> Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            var contacts = await _context.Contacts.ToListAsync();

            return contacts;
        }

        public async Task<List<Contact>?> Update(int id, Contact contact)
        {
            var c = await _context.Contacts.FindAsync(id);
            if (c is null)
            {
                return null;
            }

            c.FirstName = contact.FirstName;
            c.LastName = contact.LastName;
            c.PhoneNumber = contact.PhoneNumber;

            await _context.SaveChangesAsync();

            var contacts = await _context.Contacts.ToListAsync();

            return contacts;
        }

        public async Task<List<Contact>?> Delete(int id)
        {
            var c = await _context.Contacts.FindAsync(id);
            if (c is null)
            {
                return null;
            }

            _context.Contacts.Remove(c);
            await _context.SaveChangesAsync();

            var contacts = await _context.Contacts.ToListAsync();

            return contacts;
        }
    }
}
