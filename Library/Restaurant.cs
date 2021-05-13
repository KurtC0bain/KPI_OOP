using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;


namespace Library
{
    class Restaurant
    {
        //static void showMenu(MenuClass menu)
        //{
        //    for (int i = 0; i < menu.menu.Count; i++)
        //    {
        //        Console.Write($"{menu.menu[i].Name}\t\t");
        //        for (int j = 0; j < menu.menu[i]._weight.Count; j++)
        //        {
        //            if (j == menu.menu[i]._weight.Count - 1)
        //                Console.Write($"{menu.menu[i]._weight[j]}");
        //            else
        //                Console.Write($"{menu.menu[i]._weight[j]}/");
        //        }
        //        Console.Write("\t");
        //        for (int q = 0; q < menu.menu[i]._price.Count; q++)
        //        {
        //            if (q == menu.menu[i]._price.Count - 1)
        //                Console.Write($"{menu.menu[i]._price[q]}");
        //            else
        //                Console.Write($"{menu.menu[i]._price[q]}/");
        //        }
        //        Console.WriteLine("\b");
        //        showIngredients(menu.menu[i].ingredients);
        //    }

        //}
        //static void showIngredients(List <Product> ingr)
        //{
        //    for (int w = 0; w < ingr.Count; w++)
        //    {
        //        if (w == ingr.Count - 1)
        //            Console.Write($"{ingr[w].Name}\n\n");
        //        else
        //            Console.Write($"{ingr[w].Name}, ");

        //    }
        //}
        //static void showOrder(Order myOrder)
        //{
        //    for (int i = 0; i < myOrder.order.Count; i++)
        //    {
        //        Console.WriteLine($"{myOrder.order[i].Name}  {myOrder.order[i]._weight[0]}  {myOrder.order[i]._price[0]}");
        //    }
        //    Console.WriteLine($"Total price - {myOrder.Sum}");

        //}
        static void Main()
        {
            //Console.OutputEncoding = System.Text.Encoding.Unicode;

            //MenuClass menu = new MenuClass();
            ////showMenu(menu);

            //Order myOrder = new Order(menu.menu[0], 100);
            //myOrder.OrderAdd(menu.menu[7], 250);
            //myOrder.OrderAdd(menu.menu[6], 100);
            ////showOrder(myOrder);
            //myOrder.OrderRemove("Борщ"); Console.WriteLine();
            ////showOrder(myOrder);
            //myOrder.OrderAdd(menu.menu[2]); Console.WriteLine();
            //showOrder(myOrder);

            //var find = new SearchDish("Борщ");
            //Console.WriteLine(menu.menu.FindIndex(find.StartWith));
            //find = new SearchDish("Черчіль");
            //Console.WriteLine(menu.menu.FindIndex(find.StartWith));



            //string connStr = "server=localhost;user=root;database=uroborosmenu;password=admin;";
            //MySqlConnection conn = new MySqlConnection(connStr);
            //conn.Open();

            //string sql = $"SELECT Price FROM dish WHERE Name = 'Borshch' AND Weight = 300";
            //MySqlCommand command = new MySqlCommand(sql, conn);
            //string name = command.ExecuteScalar().ToString();
            //Console.WriteLine(name);
            //conn.Close();


            //Order order = new Order();
            //string Name = "Caesar";
            

        }
    }
}
