using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Library;

namespace RestaurantMenu
{
    /// <summary>
    /// A partial class <c>Form</c> that is a menu of the restaurant
    /// </summary>
    /// <remarks>
    /// <para>It presents GUI and combine all previous classes</para>
    /// <para>Also it helps to operate with actions like button clicks, number choosing and other</para>
    /// </remarks>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Current number of dishes in the order
        /// </summary>
        int countOfDishes = 0;
        /// <summary>
        /// Index of listBox1 chosen item. Main orientation
        /// </summary>
        int indexOfDish = -1;
        /// <summary>
        /// Index of selected item in comboBox. Controls the listBox2 element's position
        /// </summary>
        int indexOfComboBoxSelection = 0;
        /// <summary>
        /// A flag of changing selected items in comboBoxes and numericalUpDowns
        /// </summary>
        bool ifChange = false;
        /// <summary>
        /// A flag that controls showing a message about discount only once for all the program working time
        /// </summary>
        bool once = true;
        /// <summary>
        /// A variable of random-generated chance of a discount
        /// </summary>
        int sale;
        /// <summary>
        /// An order to which dishes will be added
        /// </summary>
        Order order;
        /// <summary>
        /// A database class instance; to get the info of dish from local MySQL database
        /// </summary>
        DB dB;
        /// <summary>
        /// An imitation of customer's balance, money to pay for the order
        /// </summary>
        Wallet wallet;
        /// <summary>
        /// An ID of dishes in database
        /// </summary>
        int id;
        /// <summary>
        /// A temporary list of possible weight of the dish
        /// </summary>
        List<int> weight = new List<int>();
        /// <summary>
        /// A temporary list of possible price of the dish
        /// </summary>
        List<int> price = new List<int>();
        /// <summary>
        /// A temporary list of ingredients of the dish, helps to create a <typeparamref name="Product"/> list
        /// </summary>
        List<string> productsTemp = new List<string>();
        /// <summary>
        /// A temporary list of <typeparamref name="Product"/> ingredients of the dish 
        /// </summary>
        List<Product> products = new List<Product>();
        /// <summary>
        /// A list of existing <typeparamref name="ComboBox"/>  on a form
        /// </summary>
        List<ComboBox> comboBoxes = new List<ComboBox>();
        /// <summary>
        /// A list of existing <typeparamref name="NumericUpDown"/>  on a form
        /// </summary>
        List<NumericUpDown> upDowns = new List<NumericUpDown>();
        /// <summary>
        /// A method that determine an index of a <typeparamref name="NumericUpDown"/> in a list
        /// </summary>
        /// <param name="element">A numericUpDown index of which we want to know</param>
        /// <returns>An index of a <typeparamref name="NumericUpDown"/> in a list</returns>
        private int Index(NumericUpDown element)
        {
            string indexOfEl = "";
            for (int i = 0; i < element.Name.Length; i++)
            {
                //search by the name of comboBox, e.g. "comboBox1" 
                if (Char.IsDigit(element.Name[i]))
                {
                    indexOfEl += element.Name[i].ToString();
                }
            }
            return Convert.ToInt32(indexOfEl) - 1;
        }
        /// <summary>
        /// A method that determine an index of a <typeparamref name="ComboBox"/> in a list
        /// </summary>
        /// <param name="element">A comboBox index of which we want to know</param>
        /// <returns>An index of a <typeparamref name="ComboBox"/> in a list</returns>
        private int Index(ComboBox element)
        {
            string indexOfEl = "";
            for (int i = 0; i < element.Name.Length; i++)
            {
                if (Char.IsDigit(element.Name[i]))
                {
                    indexOfEl += element.Name[i].ToString();
                }
            }
            return Convert.ToInt32(indexOfEl) - 1;
        }
        /// <summary>
        /// A method that adds all comboBoxes and numericUpDowns to an appropriate list
        /// </summary>
        private void MakeLists()
        {
            comboBoxes.Add(comboBox1); comboBoxes.Add(comboBox2); comboBoxes.Add(comboBox3);
            comboBoxes.Add(comboBox4); comboBoxes.Add(comboBox5); comboBoxes.Add(comboBox6);
            comboBoxes.Add(comboBox7); comboBoxes.Add(comboBox8); comboBoxes.Add(comboBox9);
            comboBoxes.Add(comboBox10); upDowns.Add(numericUpDown1); upDowns.Add(numericUpDown2);
            upDowns.Add(numericUpDown3); upDowns.Add(numericUpDown4); upDowns.Add(numericUpDown5);
            upDowns.Add(numericUpDown6); upDowns.Add(numericUpDown7); upDowns.Add(numericUpDown8);
            upDowns.Add(numericUpDown9); upDowns.Add(numericUpDown10);
        }
        /// <summary>
        /// A method that hides all specified elements from the form
        /// </summary>
        private void HideAllElements()
        {
            if (comboBoxes.Count > 0 && upDowns.Count > 0)
            {
                for (int i = 0; i < comboBoxes.Count; i++)
                {
                    comboBoxes[i].Hide();
                    upDowns[i].Hide();
                }
            }
            button3.Hide(); button4.Hide(); label36.Hide();
        }
        /// <summary>
        /// A method that modifies listBox2 according to the changes made in some of comboBoxes
        /// </summary>
        /// <param name="comboBox">Current comboBox</param>
        private void ComboBoxChange(ComboBox comboBox)
        {
            if (countOfDishes > 0 && ifChange)
            {
                int indexOfComboBox = Index(comboBox);
                indexOfComboBoxSelection = comboBox.SelectedIndex;
                listBox2.Items[indexOfComboBox] = order.order[indexOfComboBox]._price[indexOfComboBoxSelection] * upDowns[indexOfComboBox].Value;
                indexOfComboBoxSelection = 0;
                button3.Hide();
            }
        }
        /// <summary>
        /// A method that modifies listBox2 according to the changes made in some of numericUpDowns
        /// </summary>
        /// <param name="upDown">Current numericUpDown</param>
        private void UpDownChange(NumericUpDown upDown)
        {
            if (countOfDishes > 0 && ifChange)
            {
                int indexOfUpDown = Index(upDown);
                indexOfComboBoxSelection = comboBoxes[indexOfUpDown].SelectedIndex;
                listBox2.Items[indexOfUpDown] = order.order[indexOfUpDown]._price[indexOfComboBoxSelection] * upDowns[indexOfUpDown].Value;
                indexOfComboBoxSelection = 0;
                button3.Hide();
            }
        }
        /// <summary>
        /// A method that is called when a customer click on a dish in menu
        /// <remarks>It connects to the database and put info in appropriate place</remarks>
        /// </summary>
        /// <param name="linklabel">Current linklabel which customer clicked on</param>
        private void DishChosen(LinkLabel linklabel)
        {
            try
            {
                //connect to the local database
                dB.OpenConnection();
                //command string
                string sqlWeight = $"SELECT * FROM dish WHERE Name = '{linklabel.Text}'";
                MySqlCommand command = new(sqlWeight, dB.connection);
                MySqlDataReader reader = command.ExecuteReader();
                //read while there is an info for the reader condition
                while (reader.Read())
                {
                    //reading info about dish: weight, price, ingredients and ID
                    weight.Add(Convert.ToInt32(reader["Weight"]));
                    price.Add(Convert.ToInt32(reader["Price"]));
                    productsTemp.Add(reader["Ingredients"].ToString());
                    id = Convert.ToInt32(reader["ID"]);
                }
                //close reader and connections
                reader.Close();
                dB.CloseConnection();

                foreach (var item in productsTemp)
                {
                    //creating product-class ingredients
                    products.Add(new Product(item));
                }
                productsTemp.Clear();
            }
            catch (Exception)
            {
                throw;
            }
            try
            {
                //check the restaurant limitation of max. 10 dishes for one order
                if (listBox1.Items.Count < 10)
                {
                    //check if the dish exists in the order
                    if (listBox1.Items.Contains(linklabel.Text))
                    {
                        //variable to store a dish and index of them
                        string countOfExistingDish = "";
                        int indexOfExistingDish = 0;
                        for (int i = 0; i < order.order.Count; i++)
                        {
                            if (order.order[i].Name == linklabel.Text)
                            {
                                indexOfExistingDish = i;
                                countOfExistingDish += i.ToString();
                            }
                        }
                        //check if it possible for the dish to exist more than once in the order
                        if (order.order[indexOfExistingDish]._weight.Count == countOfExistingDish.Length)
                            throw new AlreadyExistException();
                    }
                    //make the number of dish in order greater
                    countOfDishes++;
                    //block using changing methods for comboBoxes and numUpDowns
                    ifChange = false;
                    //show appropriate elements on the form
                    comboBoxes[countOfDishes - 1].Show(); upDowns[countOfDishes - 1].Show();
                    button4.Show();
                    //the listBox1 and listBox2 bigger if it is necessary
                    if (listBox1.Items.Count > 0)
                    {
                        listBox1.Height += 35;
                        listBox2.Height += 35;
                    }
                    //if a customer added one of the special dish group, refer dish to them
                    Dish dish;
                    if (id >= 1 && id <= 7)
                        dish = new SoupGroup(linklabel.Text, weight, price);
                    else if (id >= 18 && id <= 22)
                        dish = new MeatGroup(linklabel.Text, weight, price);
                    else if (id >= 28 && id <= 31)
                        dish = new DrinksGroup(linklabel.Text, weight, price);
                    else
                        dish = new(linklabel.Text, weight, price);
                    //forming ingredients of the dish and add it to the order
                    dish.AddIngredient(products);
                    order.OrderAdd(dish);

                    listBox1.Items.Add(linklabel.Text);

                    if (comboBoxes[countOfDishes - 1].Items.Count > 0)
                        comboBoxes[countOfDishes - 1].Items.Clear();
                    //adding new data to current comboBox
                    foreach (var item in weight)
                    {
                        comboBoxes[countOfDishes - 1].Items.Add(item);
                    }
                    //show the first possible value of weight in comboBox
                    comboBoxes[countOfDishes - 1].SelectedItem = weight[0];
                    //count the sum of current dish according to the weight and price
                    listBox2.Items.Add(order.order[countOfDishes - 1]._price[0] * upDowns[countOfDishes - 1].Value);

                    //allow using changing methods for comboBoxes and numUpDowns
                    ifChange = true;
                    //clear temporary elements
                    id = 0;
                    weight.Clear();
                    price.Clear();
                    products.Clear();
                }
                else
                    throw new LimitReachedException();
            }
            //catch all necessary exceptions
            catch (LimitReachedException arg1)
            {
                MessageBox.Show(arg1.Message);
            }
            catch (AlreadyExistException arg2)
            {
                MessageBox.Show(arg2.Message);
            }
        }
        /// <summary>
        /// A method for adding special free item for the order
        /// </summary>
        private void AdditionalForFree()
        {
            for (int i = 0; i < order.order.Count; i++)
            {
                if (order.order[i] is SoupGroup)
                    //add bread for the soup dishes
                    order.order[i].needBread = true;
                else if (order.order[i] is MeatGroup)
                    //add sauce for meat or fish
                    order.order[i].needSauce = true;
                else if (order.order[i] is DrinksGroup)
                    //add sugar for warm drinks
                    order.order[i].needSugar = true;
            }
        }
        /// <summary>
        /// Starting form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            order = new Order();
            dB = new();
            Random random = new();
            //setting start value for costumer's money and if-discount
            wallet = new(random.Next(2000, 5000));
            sale = random.Next(1, 100);
            //forming lists and hide all elements
            MakeLists();
            HideAllElements();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Normal;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (indexOfDish == -1)
                {
                    ifChange = false;
                    if (listBox1.Items.Count != 0)
                    {
                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        foreach (var item in order.order)
                        {
                            item._price.Clear();
                            item._weight.Clear();
                        }
                        order.order.Clear();
                        order.Sum = 0;
                        foreach (var item in comboBoxes)
                        {
                            item.Items.Clear();
                        }
                        foreach (var item in upDowns)
                        {
                            item.Value = 1;
                        }
                        HideAllElements();
                        listBox1.Height = 36;
                        listBox2.Height = 36;
                        countOfDishes = 0;
                    }
                    else
                        throw new Exception("Please, choose the dish first");
                    ifChange = true;
                    indexOfDish = -1;
                }
                if (indexOfDish >= 0 && listBox1.Items.Count != 0)
                {
                    ifChange = false;
                    for (int i = indexOfDish; i < listBox1.Items.Count - 1; i++)
                    {
                        
                        upDowns[i].Value = upDowns[i + 1].Value;
                        comboBoxes[i].Items.Clear();
                        int selectedIndex = comboBoxes[i + 1].SelectedIndex;
                        foreach (var item in comboBoxes[i + 1].Items)
                        {
                            comboBoxes[i].Items.Add(item);
                        }
                        comboBoxes[i].SelectedItem = comboBoxes[i].Items[selectedIndex];
                    }
                    comboBoxes[listBox1.Items.Count-1].Items.Clear();
                    upDowns[listBox1.Items.Count - 1].Value = 1;
                    comboBoxes[listBox1.Items.Count-1].Hide();
                    upDowns[listBox1.Items.Count - 1].Hide();
                    button3.Hide();

                    order.OrderRemove(indexOfDish);
                    listBox2.Items.RemoveAt(indexOfDish);
                    listBox1.Items.RemoveAt(indexOfDish);

                    if (listBox1.Items.Count >= 1)
                    {
                        listBox1.Height -= 10;
                        listBox2.Height -= 10;
                    }
                    ifChange = true;
                    countOfDishes--;
                }
            }
            catch (Exception exDelete)
            {
                MessageBox.Show(exDelete.Message);
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (indexOfDish == -1)
                {
                    throw new Exception("Please, choose the dish first");
                }
                if (indexOfDish >= 0 && listBox1.Items.Count > 0)
                {
                    MessageBox.Show("Ingredients:\n\n" + order.order[indexOfDish].ingredients[0].Name);
                }
            }
            catch (Exception exIngred)
            {
                MessageBox.Show(exIngred.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox2.Items.Count > 0)
                {
                    order.Sum = 0;
                    foreach (var item in listBox2.Items)
                    {
                        order.Sum += Convert.ToInt32(item.ToString());
                    }
                    if (sale % 3 == 0)
                    {
                        order.Sum -= order.Sum / 10;
                        if (once)
                        {
                            MessageBox.Show($"Today we have a discount for our guests!\nDo not pay for 1/10 part of your order!");
                            once = false;
                        }
                    }
                    label36.Show();
                    label36.Text = $"TOTAL\n{order.Sum}";
                    button3.Show();
                    AdditionalForFree();

                }
                else
                    throw new Exception("Please, make your order first");
            }
            catch (Exception emptyOrder)
            {
                MessageBox.Show(emptyOrder.Message);
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (wallet.Money >= order.Sum)
            {
                wallet.Money -= order.Sum;
                MessageBox.Show("Purchase successful!\nWait for your order");
                this.Close();
            }
            else
            {
                MessageBox.Show("Sorry, you do not have enough money!");
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexOfDish = listBox1.SelectedIndex;
        }


        #region LinkLabelsClicks
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel1);
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel2);

        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel3);
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel4);
        }
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel5);
        }
        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel6);
        }
        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel7);
        }
        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel8);
        }
        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel9);
        }
        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel10);
        }
        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel11);
        }
        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel12);
        }
        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel13);
        }
        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel14);
        }
        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel15);
        }
        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel16);
        }
        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel17);
        }
        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel18);
        }
        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel19);
        }
        private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel20);
        }
        private void linkLabel21_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel21);
        }
        private void linkLabel22_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel22);
        }
        private void linkLabel23_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel23);
        }
        private void linkLabel24_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel24);
        }
        private void linkLabel25_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel25);
        }
        private void linkLabel26_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel26);
        }
        private void linkLabel27_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel27);
        }
        private void linkLabel28_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel28);
        }
        private void linkLabel29_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel29);
        }
        private void linkLabel30_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DishChosen(this.linkLabel30);
        }
        #endregion

        #region ComboBoxesChange
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxChange(comboBox1);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxChange(comboBox2);
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxChange(comboBox3);
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxChange(comboBox4);

        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxChange(comboBox5);

        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxChange(comboBox6);
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxChange(comboBox7);

        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxChange(comboBox8);
        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxChange(comboBox9);

        }
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxChange(comboBox10);
        }
        #endregion

        #region UpDownsChange
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpDownChange(numericUpDown1);
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            UpDownChange(numericUpDown2);
        }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            UpDownChange(numericUpDown3);
        }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            UpDownChange(numericUpDown4);
        }
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            UpDownChange(numericUpDown5);
        }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            UpDownChange(numericUpDown6);
        }
        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            UpDownChange(numericUpDown7);
        }
        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            UpDownChange(numericUpDown8);
        }
        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            UpDownChange(numericUpDown9);
        }
        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            UpDownChange(numericUpDown10);
        }
        #endregion

    }
}
