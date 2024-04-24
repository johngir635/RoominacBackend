using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoominacBackend.RequestModels
{
    public class ToptiesStayDto
    {

        public int Id { get; set; }

     
        public bool IsSuperHost { get; set; }

        
        public string[] HostLanguages { get; set; }

       
        public int PropertyDetailId { get; set; }

    }
}
