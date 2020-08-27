namespace TelephoneDirectory.Models
{
    public class Entry : IEntity<int>
    {
        public int Id { get; set; }
        public int PhoneBookId { get; set; }
        public string Name { get; set; }
        public string TelephoneNumber { get; set; }

        public virtual PhoneBook PhoneBook { get; set; }

    }
}