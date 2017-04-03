using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VehicleManager.API.Models;

namespace VehicleManager.API.data
{
	public class VehicleManagerDataContext : DbContext
	{
		// constructor
		public VehicleManagerDataContext() : base("VehicleManager") { }

		// DbSets
		public IDbSet<Customer> Customers { get; set; }
		public IDbSet<Sale> Sales { get; set; }
		public IDbSet<Vehicle> Vehicles { get; set; }
		//...myster section aka model confiruration

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// vehcile has many sales
			modelBuilder.Entity<Vehicle>()
						.HasMany(vehicle => vehicle.Sales)
						.WithRequired(sale => sale.Vehicle)
						.HasForeignKey(sale => sale.VehicleId);


			// customer has many sales
			modelBuilder.Entity<Customer>()
							.HasMany(customer => customer.Sales)
							.WithRequired(sale => sale.Customer)
							.HasForeignKey(sale => sale.CustomerId);


		}

	}
}