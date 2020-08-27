using System;
using System.Collections.Generic;

namespace TelephoneDirectory.Models
{
    public class PhoneBook :IEntity<int>
    {
        public PhoneBook()
        {
            Entry = new HashSet<Entry>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public virtual ICollection<Entry> Entry { get; set; }
    }
}
