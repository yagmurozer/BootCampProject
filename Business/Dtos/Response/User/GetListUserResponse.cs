using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Response.User
{
    public class GetListUserResponse
    {
        public List<GetUserByIdResponse> Users { get; set; }
    }
}
