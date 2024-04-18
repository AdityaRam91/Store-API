using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamestoreManagement.Domain
{
    public class Players
    {
        [Key] public string? PlayerTitle {  get; set; }
        public string? PlayerDescription { get; set; }
    }
}
