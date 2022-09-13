using Microsoft.AspNetCore.Identity;

namespace XpandIT.Challenge.DataLayer.Seeders.Initializers
{
    internal class IdentityUserInitializer : DbInitializerBase<IdentityUserInitializer>
    {
        public override void Execute()
        {
            EnsureDbContextExists();

            if (DbContext!.Users?.Any() == true)
                return;

            List<IdentityUser> identityUsers = new();
            PasswordHasher<IdentityUser> passwordHasher = new();

            IdentityUser adminUser = new()
            {
                Id = "a7909d8a-6b8a-4c62-9085-687b71eb6b61",
                UserName = "admin",
                Email = "admin@xpandit.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
            };

            passwordHasher.HashPassword(adminUser, "Admin!2#4");
            identityUsers.Add(adminUser);

            IdentityUser testUser = new()
            {
                Id = "e436d5a1-35ec-4708-9c30-d9032dc54b76",
                UserName = "testuser",
                Email = "test@xpandit.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
            };

            passwordHasher.HashPassword(testUser, "Password@12#");
            identityUsers.Add(testUser);

            DbContext.Users?.AddRange(identityUsers);
            DbContext.SaveChanges();
        }
    }
}
