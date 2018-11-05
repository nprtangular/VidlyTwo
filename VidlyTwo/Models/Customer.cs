using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyTwo.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        [Display(Name= "Date of Birth")]
        [Min18YearsIfAMember ]
        public DateTime? Birthdate { get; set; }

        //^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~
        //  NAVIGATION PROPERTY - MEMBERSHIPTTYPE
        //^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~

        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; } 

        //^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~^*~

    }
}