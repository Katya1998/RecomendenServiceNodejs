using System;

namespace Inheritage
{
    class Program
    {
        static void Main()
        {
            
            var user1 = new User(25);
            user1.PrintInfo();

            var regUser = new RegisteredUser(21);
            regUser.PrintInfo();            

            var vipUser = new VipUser();
            vipUser.Account = 100;
            vipUser.Login = "Tiger";
            vipUser.Password = "qwerty";
            vipUser.PrintInfo();
            
            //var user2 = vipUser;
            var user3 = new Admin() 
            { 
                Name = "Mike", 
                Surname = "Smith", 
                Age = 30,
                Login = "admin",
                Password = "admin",
                AccessLevel = 2
            };

            user3.PrintInfo();
            //user3.GetID();

            //User user4 = user3;

            //user4.PrintInfo();
            //Console.WriteLine(user4.ToString());

            //RegisteredUser user5 = (Admin)user4;
            //Console.WriteLine(user5.GetType().Name);

            //VipUser user6;

            //if (user4 is VipUser)
            //    user6 = (VipUser)user4;
            //else
            //    user6 = new VipUser();

            
            

            //var user7 = new VipUser() { Name = "Paul", Surname = "Johnson", Age = 20, Account = 200 };
            //user7.Privs = new VipUser.Privelegies()
            //{
            //    Subscribing = VipUser.Privelegies.PrivStatus.Silver,
            //    BuyingGoods = VipUser.Privelegies.PrivStatus.Platinum
            //};

            //user7.PrintInfo();
            


            //var user6 = user4 as Admin;

            //if (user6 == null)
            //    Console.WriteLine("Приведение типа не удалось");
            //else
            //    Console.WriteLine("Логин: {0}, пароль: {1}",
            //                user6.Login, user6.Password);
            
            Console.ReadKey();
        }
    }
}
