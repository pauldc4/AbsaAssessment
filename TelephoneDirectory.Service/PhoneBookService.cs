using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TelephoneDirectory.Data;
using TelephoneDirectory.Data.Repository;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.Service
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IRepository<PhoneBook, int> _repository;
        private readonly IRepository<Entry, int> _entryRepository;

        public PhoneBookService(IRepository<PhoneBook, int> repository, IRepository<Entry, int> entryRepository)
        {
            _repository = repository;
            _entryRepository = entryRepository;
        }

        public async Task<IList<PhoneBook>> GetPhoneBoook()
        {
            return (await _repository.GetAll(p => p.Entry)).ToList();
        }

        public async Task<IList<PhoneBook>> SearchPhoneBook(string searchTerm)
        {
            return (await _repository.Get(d => d.FirstName == searchTerm || d.Lastname == searchTerm, p => p.Entry)).ToList();
        }

        public async Task<PhoneBook> GetEntry(int id)
        {
            return (await _repository.Get(p => p.Id == id, p => p.Entry)).FirstOrDefault();
        }

        public async Task AddPhoneBookEntry(PhoneBook phoneBook)
        {
            await _repository.Insert(phoneBook);

        }

        public async Task Update(PhoneBook phoneBook)
        {
            await _repository.Update(phoneBook);

            foreach (var entry in phoneBook.Entry)
            {
                if (entry.Id > 0)
                {
                    await _entryRepository.Update(entry);
                }
                else
                {
                    await _entryRepository.Insert(entry);
                }
            }
        }

        public async Task DeletePhoneBookEntry(PhoneBook phoneBook)
        {
            foreach (var entry in phoneBook.Entry)
            {
                await _entryRepository.Delete(entry.Id);
            }

            await _repository.Delete(phoneBook.Id);
        }
    }
}
