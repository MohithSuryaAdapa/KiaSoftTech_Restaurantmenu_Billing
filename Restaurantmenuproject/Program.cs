using System;


namespace Restaurantmenuproject
{
    class program
    {
        static void Main(string[] args)
        {
            string[] code = new string[10] { "F1", "F2", "F3","F4", "F5", "F6", "F7", "F8", "F9", "F10"};
            string[] menu = new string[10] {"Chicken Biryani",
                                           "Mutton Biryani",
                                           "Egg Biryani",
                                           "Chicken Curry",
                                           "Crispy Prawns Fry",
                                           "Mixed Veg Curry",
                                           "White Rice",
                                           "Roti",
                                           "Curd Rice",
                                           "Finish transaction"};

            decimal[] price = new decimal[10] { 400.00m, 450.00m, 250.00m, 200.00m, 350.00m, 200.00m, 60.00m, 15.00m, 100.00m, 0 };
            string strprice = "";

            string transact = "N";
            do
            {
                Console.Clear();
                Console.WriteLine("Code".PadRight(10) + "Menu".PadRight(30) + "Price");
                for(int i=0;i<menu.Length;i++) 
                {
                    if (price[i]>0) { strprice = price[i].ToString(); } else { strprice = "";}
                    Console.WriteLine(code[i].PadRight(10)+ menu[i].PadRight(30)+strprice);
                }

                string[] order_list=new string[1];
                int qty;
                string strQty;
                decimal subtotal = 0;
                string order;
                int code_index;
                int current_order_index = 0;
                decimal grand_total = 0;
                Console.WriteLine();
                do
                {
                    Console.Write("Enter menu code:");
                    order = Console.ReadLine().ToUpper();
                    code_index = Array.IndexOf(code, order);
                    if (code_index < 0)
                    {
                        Console.WriteLine("Invalid Code!!!!");
                    }
                    else
                    {
                        if (order != "F10")
                        {
                            do
                            {
                                Console.WriteLine("Enter Qty: ");
                                strQty = Console.ReadLine();
                                if (int.TryParse(strQty, out qty) == false)
                                {
                                    Console.WriteLine("Invalid quantity value!!!");
                                }
                            }
                            while (int.TryParse(strQty, out qty) == false);
                            
                                subtotal = price[code_index] * qty;
                                grand_total = grand_total + subtotal;
                                order_list[current_order_index] = order.PadRight(10) + menu[code_index].PadRight(30) +
                                    price[code_index].ToString().PadRight(10) + qty.ToString().PadRight(10) + subtotal.ToString().PadLeft(10);

                                Array.Resize(ref order_list, order_list.Length + 1);
                                current_order_index++;
                            }
                            else
                            {
                                if (grand_total == 0)
                                {
                                    Environment.Exit(0);
                                }
                            }
                        }
                    }while (order != "F10") ;


                    decimal amount_tentered = 0;
                    decimal change = 0;
                    string Str_amount;

                    if (grand_total > 0)
                    {
                        Console.WriteLine("\nCode".PadRight(11) + "Menu".PadRight(30) + "Price".PadRight(10) + "Qty".PadRight(10) + "Sub Total".PadLeft(10));
                        for (int i = 0; i < order_list.Length; i++)
                        {
                            Console.WriteLine(order_list[i]);
                        }

                        string str_total = "Total Amount: " + grand_total.ToString("#0.00");
                        Console.WriteLine(str_total.PadLeft(70));

                        do
                        {
                            do
                            {
                                Console.Write("\nEnter amount given by customer: ");
                                Str_amount = Console.ReadLine();
                            } while (decimal.TryParse(Str_amount, out amount_tentered) == false);

                            if (Convert.ToDecimal(Str_amount) < grand_total)
                            {
                                Console.WriteLine("Amount given must be greater than the total amount.....");

                            }
                        } while (Convert.ToDecimal(Str_amount) < grand_total);

                        change = amount_tentered - grand_total;
                        Console.WriteLine("Change: ".PadRight(23) + change.ToString("#,0.00"));
                    }

                    do
                    {
                        Console.Write("\nAnother transaction:(Y/N): ");
                        transact = Console.ReadLine().ToUpper();
                    } while (transact != "Y" && transact != "N");


            } while (transact != "N");
              Console.WriteLine("Press any Key to exit.........");

              Console.ReadKey();
            
            
        }
    }
}