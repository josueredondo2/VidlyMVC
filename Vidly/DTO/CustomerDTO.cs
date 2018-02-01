using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        //No puede ser null
        [Required(ErrorMessage = "Please enter customer's name.")]
        //Define la longitud del campo
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSuscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }
        //Esta propiedad se debe de llamar igual al modelo
        public MembershipTypeDto MembershipType { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}