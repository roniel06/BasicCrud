using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataLayer.Models
{
   public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(80)]
        public string CreatedBy { get; set; }
        [StringLength(80)]
        public string ModifiedBy { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public bool IsDeleted { get; set; }

        public BaseModel()
        {
            CreationDate=DateTime.Now;
        }
    }
}
