using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Response.User
{
    public class DeletedUserResponse
    {
        public int Id { get; set; }
        public string Message { get; set; } = "User deleted successfully.";
    }
}
