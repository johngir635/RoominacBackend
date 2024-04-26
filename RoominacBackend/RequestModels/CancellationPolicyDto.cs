using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.RequestModels
{


    public class CancellationPolicyDto
    {
        public int PropertyId { get; set; }
        public string CancellationPolicyText { get; set; }
    }

}