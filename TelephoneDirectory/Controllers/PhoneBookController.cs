using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TelephoneDirectory.Models;
using TelephoneDirectory.Service;

namespace TelephoneDirectory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService;
        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        [HttpGet()]
        [Route("GetPhoneBook")]
        public async Task<ActionResult<IEnumerable<PhoneBook>>> GetPhoneBook()
        {
            var phoneBook = await _phoneBookService.GetPhoneBoook();
            return  phoneBook.ToList();
        }

        [HttpGet]
        [Route("SearchPhoneBook/{searchString}")]
        public async Task<ActionResult<IList<PhoneBook>>> Get(string searchString)
        {
            var phoneBook = await _phoneBookService.SearchPhoneBook(searchString);
            return  phoneBook.ToList();
        }

        [HttpPost]
        [Route("AddPhoneBook")]
        public async Task<IActionResult> AddPhoneBookEntry([FromBody] PhoneBook phoneBook)
        {
            await _phoneBookService.AddPhoneBookEntry(phoneBook);

            return Ok();
        }

        [HttpPost]
        [Route("UpdatePhoneBook")]
        public async Task<IActionResult> UpdatePhoneBookEntry([FromBody] PhoneBook phoneBook)
        {
            await _phoneBookService.Update(phoneBook);

            return Ok();

        }


        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var phoneBook = await _phoneBookService.GetEntry(id);

            return Ok();
        }
    }
}
