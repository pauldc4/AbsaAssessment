using System.Collections.Generic;
using System.Threading.Tasks;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.Service
{
    public interface IPhoneBookService
    {
        Task AddPhoneBookEntry(PhoneBook phoneBook);
        Task DeletePhoneBookEntry(PhoneBook phoneBook);
        Task<IList<PhoneBook>> GetPhoneBoook();
        Task<IList<PhoneBook>> SearchPhoneBook(string searchTerm);
        Task<PhoneBook> GetEntry(int id);
        Task Update(PhoneBook phoneBook);
    }
}