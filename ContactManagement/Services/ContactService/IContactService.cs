using ContactManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Services.ContactService
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll();
        Task<Contact?> GetSingle(int id);
        Task<List<Contact>> Create(Contact contact);
        Task<List<Contact>?> Update(int id, Contact contact);
        Task<List<Contact>?> Delete(int id);
    }
}
