namespace WebAppShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersRole : DbMigration
    {
        public override void Up()
        {
//            Sql(@"
//INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'711a91f2-6af2-4e47-8cad-364e472aa453', N'Miszel@o2.pl', 0, N'AIcHCzHHuW2s/TwSeYJnXD6/CPz/4BvYFAdLmJiPbGnk2Y7tdmqAJQN8twXV3IheEQ==', N'fa8a647c-9e30-4252-af09-d0d5ea79699c', NULL, 0, 0, NULL, 1, 0, N'Miszel@o2.pl')
//INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8dafa5e3-858f-4cd0-be71-beef9f24d6b7', N'admin@webshop.com', 0, N'ADOFU+baWRNUiPg4CwTR8CREa2SwMYWA1xZSLylm1Tn5NXhD8WtHiEYn8yBHw93hJg==', N'420ca654-8d84-40a0-96a7-97577779fbf1', NULL, 0, 0, NULL, 1, 0, N'admin@webshop.com')
//INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'baabc905-a4a8-4bae-a158-ec4399f42660', N'michal@o2pl', 0, N'AFJSPF02TLIQUp4TIR87kqKzF/glLHTFk0rzl44dLUxPhqV/024sr1eMv0mmL0nn2Q==', N'482371dd-2a06-4428-bf36-d75346898713', NULL, 0, 0, NULL, 1, 0, N'michal@o2pl')

//INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9cdba8cd-df02-4a09-b536-efcd451c2621', N'CanManageMovie')

//INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'711a91f2-6af2-4e47-8cad-364e472aa453', N'64f6a012-2253-4a69-882e-1a532224ea0c')
//");
        }
        
        public override void Down()
        {
        }
    }
}
