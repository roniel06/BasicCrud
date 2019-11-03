using DataLayer.Models;

namespace DataLayer.Models
{

    public class ApiUsers : BaseModel
    {
        public string ClientName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
