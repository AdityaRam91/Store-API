using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamestoreManagement.Domain
{
    public class Joysticks
    {
        [Key] public string? JoyTitle {  get; set; }
        public string? JoyDescription { get; set;}
    }
}
