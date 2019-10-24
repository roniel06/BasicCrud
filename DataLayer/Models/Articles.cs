using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataLayer.Models
{
    public class Articles:BaseModel
    {
        [StringLength(50),Required]
        public string Name { get; set; }
        [StringLength(200), Required]
        public string Description { get; set; }

        public Guid PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

    }
}
