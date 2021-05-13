using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Library;

namespace Library
{
    public class SearchDish
    {
        String _s;
        public SearchDish(string s)
        {
            _s = s;
        }
        public bool StartWith(Dish e)
        {
            return e.Name.StartsWith(_s, StringComparison.InvariantCultureIgnoreCase);
        }
    }
    public class MenuClass
    {
        public List<Dish> menu = new List<Dish>();
        List<int> weight = new List<int>();
        List<int> price = new List<int>();
        List<Product> composeDish = new List<Product>();

        void dishCompose(List<string> composeNames, List<Product> composeDish, Dish dish)
        {
            foreach (string item in composeNames)
            {
                composeDish.Add(new Product(item));
            }
            dish.AddIngredient(composeDish);
            menu.Add(dish);

            weight.Clear();
            price.Clear();
            composeDish.Clear();
            composeNames.Clear();
        }
        public MenuClass()
        {
            //-------------------------------------------------------SOUPS--------------------------------------------------------------------------------

            weight.Add(100); weight.Add(300);
            price.Add(50); price.Add(130);
            SoupGroup Borshch = new SoupGroup("Борщ", weight, price);
            List<string> composeNames = new List<string>() {"яловичина", "цибуля", "вода", "морква", "петрушка", "сіль", "перець", "сметана", "буряк", "картопля",
                                                     "капуста", "помідор", "часник", "вода"}; 
            dishCompose(composeNames, composeDish, Borshch);

            weight.Add(100); price.Add(140);
            SoupGroup MushroomSoup = new SoupGroup("Грибний крем-суп", weight, price);
            composeNames.Add("картопля"); composeNames.Add("шампіньойни"); composeNames.Add("цибуля");
            composeNames.Add("вершки"); composeNames.Add("вода"); composeNames.Add("сіль");
            dishCompose(composeNames, composeDish, MushroomSoup);

            weight.Add(300); price.Add(180);
            SoupGroup TomatoesSeafoodSoup = new SoupGroup("Томатний суп з морепродуктами й шафраном", weight, price);
            composeNames.Add("томатний сік"); composeNames.Add("цибуля"); composeNames.Add("лимон"); composeNames.Add("болгарський перець"); composeNames.Add("помідор");
            composeNames.Add("масло"); composeNames.Add("яйце"); composeNames.Add("морепродукти"); composeNames.Add("базилік"); composeNames.Add("шафран");
            composeNames.Add("вода"); composeNames.Add("сіль");
            dishCompose(composeNames, composeDish, TomatoesSeafoodSoup);

            weight.Add(280); price.Add(210);
            SoupGroup Bisk = new SoupGroup("Біск з креветок", weight, price);
            composeNames.Add("вершки"); composeNames.Add("креветки"); composeNames.Add("біле вино"); composeNames.Add("цибуля");
            composeNames.Add("морква"); composeNames.Add("томати"); composeNames.Add("масло"); composeNames.Add("вода"); 
            composeNames.Add("чорний перець"); composeNames.Add("сіль");
            dishCompose(composeNames, composeDish, Bisk);

            weight.Add(130); weight.Add(350);
            price.Add(279); price.Add(95);
            SoupGroup TomYam = new SoupGroup("Тайський том-ям", weight, price);
            composeNames.Add("кокосове молоко"); composeNames.Add("курячий бульйон"); composeNames.Add("креветки"); composeNames.Add("масло");
            composeNames.Add("лимонграсс"); composeNames.Add("галанга"); composeNames.Add("лайм"); composeNames.Add("кальмар"); composeNames.Add("черрі");
            composeNames.Add("цибуля"); composeNames.Add("вода");
            dishCompose(composeNames, composeDish, TomYam);

            //---------------------------------------------------------SALADS----------------------------------------------------------------------------
            weight.Add(100); weight.Add(270);
            price.Add(65); price.Add(100);
            SaladGroup Churchill = new SaladGroup("Черчіль", weight, price);
            composeNames.Add("буряк"); composeNames.Add("миндаль"); composeNames.Add("яблуко"); composeNames.Add("салат"); composeNames.Add("часник");
            composeNames.Add("бальзамічний соус");
            dishCompose(composeNames, composeDish, Churchill);

            weight.Add(100); weight.Add(200);
            price.Add(70); price.Add(120);
            SaladGroup Greek = new SaladGroup("Грецький", weight, price);
            composeNames.Add("помідор"); composeNames.Add("огірок"); composeNames.Add("болгарський перець"); composeNames.Add("цибуля");
            composeNames.Add("сир фета"); composeNames.Add("маслини"); composeNames.Add("лимон"); composeNames.Add("оливкова олія");
            composeNames.Add("часник"); composeNames.Add("сіль"); composeNames.Add("чорний перець"); composeNames.Add("орегано");
            dishCompose(composeNames, composeDish, Greek);

            weight.Add(100); weight.Add(250);
            price.Add(90); price.Add(150);
            SaladGroup Nicoise = new SaladGroup("Нісуаз", weight, price);
            composeNames.Add("картопля"); composeNames.Add("тунець"); composeNames.Add("яйце"); composeNames.Add("черрі"); composeNames.Add("руккола");
            composeNames.Add("лимон"); composeNames.Add("гірчиця"); composeNames.Add("оливкова олія");
            dishCompose(composeNames, composeDish, Nicoise);

            weight.Add(100); weight.Add(270);
            price.Add(95); price.Add(150);
            SaladGroup Caesar = new SaladGroup("Цезар", weight, price);
            composeNames.Add("салат"); composeNames.Add("помідор"); composeNames.Add("куряче філе"); composeNames.Add("білий хліб"); composeNames.Add("соус \"Цезар\" ");
            composeNames.Add("масло"); composeNames.Add("часник"); composeNames.Add("сир пармезан");
            dishCompose(composeNames, composeDish, Caesar);

            weight.Add(100); weight.Add(280);
            price.Add(125); price.Add(300);
            SaladGroup Burratino = new SaladGroup("Буратіно з рукколою і черрі", weight, price);
            composeNames.Add("черрі"); composeNames.Add("моцарелла"); composeNames.Add("руккола"); composeNames.Add("твердий сир"); composeNames.Add("мед");
            composeNames.Add("чорний перець"); composeNames.Add("сіль"); composeNames.Add("оливкова олія");
            dishCompose(composeNames, composeDish, Burratino);
        }
    }
}
