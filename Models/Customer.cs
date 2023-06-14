﻿using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Vidly2.Models
{
	public class Customer
	{
		public int Id { get; set; }
		
		[Required(ErrorMessage = "Please enter customer's name")]
		[StringLength(255)]
		public string Name { get; set; }
		
		public bool IsSubscribedToNewsletter { get; set; }
		
		public MembershipType MembershipType { get; set; }

		[Display(Name = "Membership Type")]
		public byte MembershipTypeId { get; set; }

		[Display(Name = "Birth date")]
		[Min18YrsIfAMember]
		public DateTime? Birthdate { get; set; }
	}
}
