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

			if (context.Customers.Count() == 0)
			{
				//  This method will be called after migrating to the latest version.
				for (int i = 0; i < 1000; i++)
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

			string[] colors = new string[]
			{
				"Green", "White", "Blue", "Red", "Black", "Yellow"
			};
			
			//if (context.Vehicles.Count() == 0)
			//{
			//	for (int i = 0; i < 1000; i++)
			//	{
			//		context.Vehicles.Add(new Vehicle
			//		{
			//			Color = colors[0],
			//			Make = Faker.StringFaker.SelectFrom()

			//		});
			//	}
			//}
        }
    }
}
