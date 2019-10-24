using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Models
{
    public class Person:BaseModel
    {
        [StringLength(80), Required]
        public string Name { get; set; }
        [StringLength(80), Required]
        public string SecondName { get; set; }
        [StringLength(80), Required]
        public string  LastName { get; set; }
        [StringLength(80),Required]
        public string SecondLastName { get; set; }

        public DateTime BirthDate { get; set; }

        public IEnumerable<Articles> Articles { get; set; }

    }
}
