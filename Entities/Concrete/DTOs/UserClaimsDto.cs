using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
    public class UserClaimsDto
    {
        public int UserId { get; set; }
        public List<int> OperationClaims { get; set; }
    }
}
