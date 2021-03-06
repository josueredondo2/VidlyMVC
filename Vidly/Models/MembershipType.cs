﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFree { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        [Required]
        public string Name { get; set; }

        //Remplaza enums, hace codigo mas limpio
        public static readonly byte UnKnown = 0;
        public static readonly byte PayAsYouGo= 0;


    }
}