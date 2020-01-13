using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyClean.Models
{
    public class EndClient
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string UserName { get; set; }

        [Required, StringLength(20)]
        public string UserSurname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int DateOfBirth { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public byte[] ImageArray { get; set; }
    }
}