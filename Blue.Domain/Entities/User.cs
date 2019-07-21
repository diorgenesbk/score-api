using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.Domain.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Cpf { get; set; }
    }
}
