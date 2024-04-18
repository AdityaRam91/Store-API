using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamestoreManagement.Domain
{
    public class Games
    {
        [Key] public string? GameTitle {  get; set; }
        public string? GameDescription { get; set; }    

    }
}
