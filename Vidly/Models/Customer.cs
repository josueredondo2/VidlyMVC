using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //No puede ser null
        [Required]
        //Define la longitud del campo
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSuscribedToNewsletter { get; set; }
        public MembershipType MembershipType{ get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}