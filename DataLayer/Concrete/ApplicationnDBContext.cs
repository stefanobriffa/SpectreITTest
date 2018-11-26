using DataLayer.Interfaces;
using DataModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DataLayer.Concrete
{
    //public class EFContext : DbContext, IDBContext
    //{
    //    public EFContext() : base("SpectreDB")
    //    {

    //    }

    //    public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
    //    {
    //        return base.Set<TEntity>();
    //    }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    //        modelBuilder.Entity<UserRegistration>();
    //        base.OnModelCreating(modelBuilder);
    //    }
    //}



    public class ApplicationDbContext : IdentityDbContext<AppUser>, IDBContext
    {
        public virtual DbSet<AppUserTransaction> AppUserTransaction { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //AspNetUsers -> User
            modelBuilder.Entity<AppUser>()
                .ToTable("AppUser");

            modelBuilder.Entity<AppUser>().Ignore(au => au.Password);
            modelBuilder.Entity<AppUser>().Ignore(au => au.CurrentBalanceForeignCurrency);

            modelBuilder
                .Entity<AppUserTransaction>()
                .ToTable("AppUserTransaction");
            modelBuilder.Entity<AppUserTransaction>().HasKey(x => x.PK).Property(x => x.PK).HasColumnName("PK");
            modelBuilder.Entity<AppUserTransaction>().HasRequired<AppUser>(t => t.AppUser).WithMany(au => au.Transactions).Map(x => x.MapKey("AppUser_FK"));
            modelBuilder.Entity<AppUserTransaction>().Property(x => x.Amount).HasColumnName("Amount");
            modelBuilder.Entity<AppUserTransaction>().Property(x => x.TransDate).HasColumnName("TransactionDate");
            ////AspNetRoles -> Role
            //modelBuilder.Entity<IdentityRole>()
            //    .ToTable("Role");
            ////AspNetUserRoles -> UserRole
            //modelBuilder.Entity<IdentityUserRole>()
            //    .ToTable("UserRole");
            //AspNetUserClaims -> UserClaim
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaim");
            //AspNetUserLogins -> UserLogin
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogin");
        }
    }
}
