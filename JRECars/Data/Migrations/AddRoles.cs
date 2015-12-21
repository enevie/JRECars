using FluentMigrator;
using Data.Context;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace Data.Migrations
{
	public class AddRoles : DropCreateDatabaseIfModelChanges<JRECars.Models.JREMotorsDB>
	{
		protected override void Seed(JRECars.Models.JREMotorsDB dataBase)
		{

			var roleStore = new RoleStore<IdentityRole>(dataBase);
			var roleManager = new RoleManager<IdentityRole>(roleStore);
			//var userStore = new UserStore<JRECars.Models.JREMotorsDB.ApplicationUser>(dataBase);
			//var userManager = new UserManager<JRECars.Models.JREMotorsDB.ApplicationUser>(userStore);

			var role = roleManager.FindByName("Admin");
			if (role == null)
			{
				role = new IdentityRole("Admin");
				roleManager.Create(role);
			}

			dataBase.SaveChanges();

			//Insert.IntoTable("AspNetRoles").Row(new {Name = })
		}
	}
}
