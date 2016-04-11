using System;
using System.IO;

namespace Inheritage
{
    class User
    {
        public string Name {get; set;}
        public string Surname { get; set;}

        private static int NumberOfUsers = 0;

        protected readonly int ID;
        
        private int age;

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value < 0)
                    throw new Exception("Отрицательный возраст");
                else age = value;
            }
        }

        public User(string myName, string mySurname, int myAge)
        {
            Name = myName;
            Surname = mySurname;
            Age = myAge;
            ID = ++NumberOfUsers;
        }

        public User() : this("John", "Doe", 0) { }

        public User(string myName, string mySurname) 
            : this(myName,mySurname,0) { }

        public User(int myAge) : this("John", "Doe", myAge) { }

        ~User()
        {
            string[] messages = new [] {String.Format("Удален пользователь {0} {1}", Name, Surname)};
            File.AppendAllLines("log.txt", messages);
        }


        protected string FullName()
        {
            return Name + " " + Surname;
        }

        public virtual void PrintInfo()
        {
            string years;
            int rest = age % 10;
            if (rest == 1)
                years = "год";
            else if (rest == 2 || rest == 3 || rest == 4)
                years = "года";
            else
                years = "лет";
            Console.WriteLine("{0}, возраст {1} {2}, ID {3}", FullName(), age, years, ID);
        }
    }

    class RegisteredUser : User
    {
        public string Login { get; set; }
        public string Password {get; set;}

        public RegisteredUser(string myName, string mySurname, 
            int myAge, string myLogin, 
            string myPass) : base(myName, mySurname, myAge)
        {
            //Name = myName;
            //Surname = mySurname;
            //Age = myAge;
            Login = myLogin;
            Password = myPass;
            
        }

        public RegisteredUser() : this("John", "Doe", 0, "anonymous", "12345") { }
        
        public RegisteredUser(int myAge)
            : this("John", "Doe", myAge, "anonymous", "12345") {}


        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Логин: {0}, пароль: {1}", Login, Password);
        }

    }


    class VipUser : RegisteredUser
    {
        public class Privelegies
        {
            public enum PrivStatus { None, Silver, Gold, Platinum }
            
            public PrivStatus Subscribing;
            public PrivStatus BuyingGoods;
        }

        public Privelegies Privs = new Privelegies();

        public int Account { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Баланс: {0} руб.", Account);
            Console.WriteLine("Привилегии: подписка - {0}, покупка - {1}",
                Privs.Subscribing, Privs.BuyingGoods);
        }
    }

    class Admin : RegisteredUser
    {
        public int AccessLevel { get; set; }

        public void GetID()
        {
            Console.WriteLine("Меня зовут {0}, мой ID {1}", FullName(), ID);
        }

        public sealed override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Уровень доступа " + AccessLevel);
        }
    }

    sealed class SuperAdmin : Admin
    {
        public string SuperPassword { get; set; }

    }

}
