namespace Directionary.Data.Migrations
{
    using Directionary.Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Directionary.Data;
    using Directionary.Data.Repositories;
    using Directionary.Data.Infrastructure;

    internal sealed class Configuration : DbMigrationsConfiguration<Directionary.Data.DirectionaryDbContext>
    {
        IDbFactory dbFactory;
        MenuRepository menuRepository;
        MenuGroupRepository menuGroupRepository;
        IUnitOfWork unitOfWork;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Directionary.Data.DirectionaryDbContext";
        }

        protected override void Seed(Directionary.Data.DirectionaryDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            //  This method will be called after migrating to the latest version.
            dbFactory = new DbFactory();
            menuRepository = new MenuRepository(dbFactory);
            menuGroupRepository = new MenuGroupRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
            MenuGroup menuGroup = new MenuGroup();
            menuGroup.Name = "MenuSite";
            menuGroupRepository.Add(menuGroup);
            unitOfWork.Commit();


            Menu menu1 = new Menu();
            menu1.Name = "Trang chủ";
            menu1.URL = "#";
            menu1.Target = "blank";
            menu1.ParentID = 0;
            menu1.GroupID  = 1;
            menu1.I18n = "Home";
            menu1.Status = true;
            menu1.FirstIcon = "<i class='fas fa-home'></i>";
            menu1.DisplayOrder = 1;
            menuRepository.Add(menu1);
          

            Menu menu2 = new Menu();
            menu2.Name = "Giới thiệu";
            menu2.URL = "#";
            menu2.Target = "blank";
            menu2.ParentID = 0;
            menu2.GroupID = 1;
            menu2.I18n = "About";
            menu2.Status = true;
            menu2.FirstIcon = "<i class='far fa-address-card'></i>";
            menu2.DisplayOrder = 2;
            menuRepository.Add(menu2);
       

            Menu menu3 = new Menu();
            menu3.Name = "Từ điển";
            menu3.URL = "#";
            menu3.Target = "blank";
            menu3.ParentID = 0;
            menu3.GroupID = 1;
            menu3.I18n = "Directionary";
            menu3.Status = true;
            menu3.FirstIcon = "<i class='fas fa-spell-check'></i>";
            menu3.DisplayOrder = 3;
            menuRepository.Add(menu3);
         

            Menu menu4 = new Menu();
            menu4.Name = "Anh-Việt";
            menu4.URL = "#";
            menu4.Target = "blank";
            menu4.ParentID = 3;
            menu4.GroupID = 1;
            menu4.I18n = "Directionary";
            menu4.Status = true;
            menu4.FirstIcon = "<i class='fas fa-spell-check'></i>";
            menu4.DisplayOrder = 4;
            menuRepository.Add(menu4);
          

            Menu menu5 = new Menu();
            menu5.Name = "Việt-Anh";
            menu5.URL = "#";
            menu5.Target = "blank";
            menu5.ParentID = 3;
            menu5.GroupID = 1;
            menu5.I18n = "Directionary";
            menu5.Status = true;
            menu5.FirstIcon = "<i class='fas fa-spell-check'></i>";
            menu5.DisplayOrder = 5;
            menuRepository.Add(menu5);
            unitOfWork.Commit();
        }


        private void CreateUser(DirectionaryDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DirectionaryDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new DirectionaryDbContext()));
            var user = new ApplicationUser()
            {
                UserName = "vovantung",
                Email = "vovantungdt123@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Vo Van Tung"
            };
            if (manager.Users.Count(x => x.UserName == "vovantung") == 0)
            {
                manager.Create(user, "123456$");
                if (!roleManager.Roles.Any())
                {
                    roleManager.Create(new IdentityRole { Name = "Admin" });
                    roleManager.Create(new IdentityRole { Name = "ProjectManagement" });
                    roleManager.Create(new IdentityRole { Name = "User" });
                }
                var adminUser = manager.FindByEmail("vovantungdt123@gmail.com");
                manager.AddToRoles(adminUser.Id, new string[] { "Admin", "ProjectManagement", "User" });
            }
        }
    }
}
