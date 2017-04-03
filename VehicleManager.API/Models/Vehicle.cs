using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleManager.API.Models
{
	public class Vehicle
	{

		// scalar properties
		public int VehicleId { get; set; }

		public string Make { get; set; }

		public string Model { get; set; }

		public int Year { get; set; }

		public string Color { get; set; }

		public string VehicleType { get; set; }

		public decimal RetailPrice { get; set; }

//navigation properties

public virtual ICollection<Sale> Sales { get; set; }

	}

}