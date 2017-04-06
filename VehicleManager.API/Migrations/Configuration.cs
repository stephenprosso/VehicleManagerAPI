namespace VehicleManager.API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using VehicleManager.API.Models;

	internal sealed class Configuration : DbMigrationsConfiguration<VehicleManager.API.data.VehicleManagerDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VehicleManager.API.data.VehicleManagerDataContext context)
        {
			string[] colors = new string[] {"Green", "White", "Blue", "Red", "Black", "Yellow"};
			string[] makes = new string[] { "Toyota", "Honda", "Chevy", "Ford" };
			string[] models = new string[] { "Carolla", "Prius", "Civic", "Silverado", "F150" };
			string[] VehicleTypes = new string[] { "Sedan", "Truck" };

			if (context.Customers.Count() == 0)
			{
				//  This method will be called after migrating to the latest version.
				for (int i = 0; i < 25; i++)
				{
					context.Customers.Add(new Models.Customer
					{
						EmailAddress = Faker.InternetFaker.Email(),
						DateOfBirth = Faker.DateTimeFaker.BirthDay(),
						FirstName = Faker.NameFaker.FirstName(),
						LastName = Faker.NameFaker.LastName(),
						Telephone = Faker.PhoneFaker.Phone()
					});
				}

				context.SaveChanges();
			}

			if (context.Vehicles.Count() == 0)
			{
				for (int i = 0; i < 25; i++)
				{
					context.Vehicles.Add(new Vehicle
					{
						Make = Faker.ArrayFaker.SelectFrom(makes),
						Model = Faker.ArrayFaker.SelectFrom(models),
						Color = Faker.ArrayFaker.SelectFrom(colors),
						RetailPrice = Faker.NumberFaker.Number(1000, 100000),
						VehicleType = Faker.ArrayFaker.SelectFrom(VehicleTypes),
						Year = Faker.DateTimeFaker.DateTime().Year
					});
				}
				context.SaveChanges();
			}

			if (context.Sales.Count() == 0)
			{
				for (int i = 0; i < 25; i++)
				{
					var vehicle = context.Vehicles.Find(Faker.NumberFaker.Number(1, 100));
					var invoiceDate = Faker.DateTimeFaker.DateTime();

					context.Sales.Add(new Sale
					{
						Customer = context.Customers.Find(Faker.NumberFaker.Number(1, 100)),
						Vehicle = vehicle,
						InvoiceDate = invoiceDate,
						salePrice = vehicle.RetailPrice,
						PaymentReceivedDate = invoiceDate.AddDays(Faker.NumberFaker.Number(1, 14)),
				
					});

				}

				context.SaveChanges();
			}
        }
    }
}
