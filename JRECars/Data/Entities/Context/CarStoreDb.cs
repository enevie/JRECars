using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JRECars.Models
{
	public class JREMotorsDB : IdentityDbContext<JREMotorsDB.ApplicationUser>
	{
		public JREMotorsDB()
			: base("name=JREMotorsDB")
		{
		}

		

		public DbSet<Manufacturer> Manufacturers { get; set; }
		public DbSet<Car> Cars { get; set; }
		public DbSet<ShopingCartItem> ShopingCartItems { get; set; }

		public class ApplicationUser : IdentityUser
		{
			public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
			{
				// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
				var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
				// Add custom user claims here
				return userIdentity;
			}
		}

		//public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
		//{
		//	public ApplicationDbContext()
		//		: base("JREMotorsD")
		//	{
		//		Database.SetInitializer((new System.Data.Entity.CreateDatabaseIfNotExists<IdentityDbContext>()));
		//	}

		//	public static ApplicationDbContext Create()
		//	{
		//		return new ApplicationDbContext();
		//	}
		//}
		public static JREMotorsDB Create()
		{
			return new JREMotorsDB();
		}
	}
}