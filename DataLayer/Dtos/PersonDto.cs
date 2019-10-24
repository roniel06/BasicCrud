using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Dtos
{
    public class PersonDto
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public string  Address { get; set; }

        public IEnumerable<ArticleDto> ArticleDto { get; set; }
    }
}
