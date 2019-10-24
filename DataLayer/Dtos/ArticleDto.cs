using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Dtos
{
   public class ArticleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public PersonDto PersonDto { get; set; }
    }
}
