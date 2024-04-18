﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamestoreManagement.Domain
{
    public class Register
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email {  get; set; }
        public string? Address {  get; set; }
        public string? MoblieNumber {  get; set; }
        public string? Password {  get; set; }



    }
}
