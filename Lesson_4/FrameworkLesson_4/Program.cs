using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkLesson_4
{
    public class Program
    {
        static void Main(string[] args)
        {

#if DEBUG
            Console.Title = Properties.Settings.Default.ApplicationNameDebug;
#else
            Console.Title = Properties.Settings.Default.ApplicationName;
#endif

            if (string.IsNullOrEmpty(Properties.Settings.Default.Fio) ||
                Properties.Settings.Default.Age <= 0)
            {
                Console.Write("Введите Ф.И.О.: ");
                Properties.Settings.Default.Fio = Console.ReadLine();

                Console.Write("Укажите ваш возраст: ");

                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    Properties.Settings.Default.Age = age;
                }
                else
                {
                    Properties.Settings.Default.Age = 0;
                }

                Properties.Settings.Default.Save();
            }

            Console.WriteLine($"Ф.И.О.: {Properties.Settings.Default.Fio}. Возраст: {Properties.Settings.Default.Age.ToString()} лет.");


            //ConnectionString connectionString1 = new ConnectionString
            //{
            //    DatabaseName = "Database1",
            //    Host = "localhost",
            //    UserName = "User1",
            //    Password = "qwerty"
            //};

            //ConnectionString connectionString2 = new ConnectionString
            //{
            //    DatabaseName = "Database2",
            //    Host = "localhost",
            //    UserName = "User2",
            //    Password = "qwasar"
            //};

            //List<ConnectionString> connections = new List<ConnectionString>();
            //connections.Add(connectionString1);
            //connections.Add(connectionString2);

            //CacheProvider cacheProvider = new CacheProvider();
            //cacheProvider.CacheConnections(connections);

            CacheProvider cacheProvider = new CacheProvider();
            List<ConnectionString> connections  = cacheProvider.GetConnectionFromCache();

            foreach (ConnectionString connection in connections)
            {
                Console.WriteLine($"{connection.DatabaseName} {connection.Host} {connection.UserName} {connection.Password}");
            }

            Console.ReadKey();
        }
    }
}
