using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine.Strategy
{
    public class GELoption : IVM
    {
        public void CurrencyInfo(List<ItemInfo> List)
        {
            foreach (var i in List)
                Console.WriteLine($"{i.Code} - {i.Type} - {i.Name} - {i.Price} GEL - {i.Quantity} left");
        }

        public void CurrencyOption(List<ItemInfo> Items)
        {
            Controller C = new Controller();

            decimal TempMoney = 0; 
            decimal money = 0;
            
            CurrencyInfo(Items);

            bool cont = true;
            while (cont)
            {
                bool cont1 = true; 
                while (cont1)
                {
                    Console.Write("\nEnter Money: ₾");
                    money = Convert.ToDecimal(Console.ReadLine());
                    money += TempMoney;
                    if (money <= 0) Console.WriteLine("\nERROR: Enter correct amount!\n");
                    else cont1 = false;
                }

                bool cont2 = true;
                while (cont2)
                {
                    bool cont3 = true;
                    while (cont3)
                    {
                        Console.WriteLine("\nEnter Product Code: ");
                        C.Code = Convert.ToString(Console.ReadLine());
                        if (C.Code != Items[0].Code & C.Code != Items[1].Code & C.Code != Items[2].Code &
                            C.Code != Items[3].Code & C.Code != Items[4].Code & C.Code != Items[5].Code &
                            C.Code != Items[6].Code & C.Code != Items[7].Code & C.Code != Items[8].Code &
                            C.Code != Items[9].Code & C.Code != Items[10].Code & C.Code != Items[11].Code)
                            Console.WriteLine("\nERROR: Enter correct Code!\n");
                        else
                        {
                            for (int i = 0; i < 12; i++)
                                if (C.Code == Items[i].Code)
                                {
                                    C.Name = Items[i].Name;
                                    C.Type = Items[i].Type;
                                    C.Quantity = Items[i].Quantity;
                                }
                            cont3 = false;  
                        }
                        if (C.Quantity == 0)
                        {
                            Console.WriteLine($"\nThe quantity of {C.Name} {C.Type} has run out!\n");
                            cont3 = true; 
                        }
                    }

                        ItemName PurchasedName = new ItemName();
                    ItemType PurchasedType = new ItemType();
                    decimal PurchasedPrice = 0;
                    foreach (var item in Items)
                        if (C.Code == item.Code)
                        {
                            PurchasedName = item.Name;
                            PurchasedType = item.Type;
                            PurchasedPrice = item.Price;
                        }

                    bool cont4 = true;
                    while (cont4)
                    {
                        if (money < PurchasedPrice)
                        {
                            Console.WriteLine("\nYou don't have enough money!\n1. Add more money\n2. Buy anything else\n");
                            string choice = Convert.ToString(Console.ReadLine());
                            if (choice == "1")
                            {
                                TempMoney += money;
                                cont = true;  
                                cont2 = false;
                                cont4 = false;
                            }
                            else if (choice == "2")
                            {
                                cont2 = true; 
                                cont4 = false;
                            }
                            else Console.WriteLine("\nERROR: Incorrect answer, use '1' or '2' for options!\n");
                        }
                        else
                        {
                            money -= PurchasedPrice;
                            Console.WriteLine($"\nYou purchased {PurchasedName} {PurchasedType}. Your balance is ₾{money}.\n");
                            cont = false; 
                            cont2 = false;
                            cont4 = false;
                        }
                    }
                }
            }
        }
    }
}