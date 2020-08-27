using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneDirectory.Models
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
