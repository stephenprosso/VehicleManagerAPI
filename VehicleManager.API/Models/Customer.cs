﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleManager.API.Models
{
	public class Customer
	{
		// scalar properties
		public int CustomerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string Telephone { get; set; }
		public DateTime DateOfBirth { get; set; } 

		// navigation properties
	public virtual ICollection<Sale> Sales { get; set; }

	}
}