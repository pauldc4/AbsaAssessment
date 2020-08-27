using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelephoneDirectory.Service;
using TelephoneDirectory.Models;
using TelephoneDirectory.Data;
using System;
using System.Collections.Generic;
using System.Text;
using TelephoneDirectory.Data.Repository;
using System.Threading.Tasks;

namespace TelephoneDirectory.Service.Tests
{
    [TestClass()]
    public class PhoneBookServiceTests
    {
        
        [TestMethod()]
        public void GetPhoneBoookTest()
        {
            try
            {
                PhoneBookService service = new PhoneBookService(new GenericRepository<PhoneBook, int>(), new GenericRepository<Entry, int>());
                
                var phoneBook = service.GetPhoneBoook().Result;
                Assert.IsNotNull(phoneBook);                

            }
            catch (Exception)
            {
                Assert.Fail();
            }

            
        }

        [TestMethod()]
        public void SearchPhoneBookTest()
        {
            try
            {
                PhoneBookService service = new PhoneBookService(new GenericRepository<PhoneBook, int>(), new GenericRepository<Entry, int>());
                var phoneBook = service.SearchPhoneBook("Grant").Result;

                Assert.IsNotNull(phoneBook);

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


        [TestMethod()]
        public void GetEntryTest()
        {
            try
            {
                PhoneBookService service = new PhoneBookService(new GenericRepository<PhoneBook, int>(), new GenericRepository<Entry, int>());
                var phoneBook = service.GetEntry(1).Result;

                Assert.IsNotNull(phoneBook);

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public async Task AddPhoneBookEntryTest()
        {
            try
            {
                PhoneBookService service = new PhoneBookService(new GenericRepository<PhoneBook, int>(), new GenericRepository<Entry, int>());
                var phoneBook = new PhoneBook
                {
                    FirstName = "Tim",
                    Lastname = "Van der Merwe",
                    Entry = new List<Entry>
                    {
                      new Entry  {
                            Name = "Cell",
                            TelephoneNumber = "0921234567"
                        },
                      new Entry
                      {
                            Name = "Fax",
                            TelephoneNumber = "0114671234"
                      }
                    }
                };

                 await service.AddPhoneBookEntry(phoneBook);
                

                Assert.IsTrue(true);

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public async Task DeleteEntry()
        {
            try
            {
                PhoneBookService service = new PhoneBookService(new GenericRepository<PhoneBook, int>(), new GenericRepository<Entry, int>());

                var phoneBooks = await service.SearchPhoneBook("Van der Merwe");
                foreach (var phoneBook in phoneBooks)
                {
                    await service.DeletePhoneBookEntry(phoneBook);
                }

                Assert.IsTrue(true);
            }
            catch (Exception)
            {

                Assert.Fail();
            }



        }
    }
}