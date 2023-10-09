﻿using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace WebShop5
{
    public class Admin
    {


        public List<string> newCart = new List<string>(); // Deklarera newCart som en instansvariabel


        static public void AdminLogIn()
        {
            string AdminUserName = "1";
            string AdminPassword = "1";

            Console.WriteLine("Admin Home");

            Console.Write("Enter your admin log in: ");
            string inputLogin = Console.ReadLine();
            Console.Write("Enter your password: ");
            string inputPassword = Console.ReadLine();

            if (inputLogin == AdminUserName && inputPassword == AdminPassword)
            {
                bool AdminMenu = true;
                while (AdminMenu)
                {
                    Console.WriteLine("ADMIN MENY: ");
                    Console.WriteLine("1 : Lägg till produkt");
                    Console.WriteLine("2 : Visa Produkter");
                    Console.WriteLine("3 : Ta bort produkter");
                    Console.WriteLine("0 : EXIT");
                    int AdminChoice = Convert.ToInt32(Console.ReadLine());


                    switch (AdminChoice)
                    {
                        case 0:
                            AdminMenu = false;
                            break;

                        case 1:
                            updateCart();
                            break;

                        case 2:
                            showProducts();
                            break;

                        case 3:
                            removeproducts();
                            break;
                            
                    }

                }

            }

            else
            {
                Console.WriteLine("Please make sure you entered the right username or password");
                return;
            }
        }

        public static void updateCart()
        {
            List<string> newCart = new List<string>(File.ReadAllLines("../../../Cart.csv"));


            Console.WriteLine("Add to cart :");
            string? addProduct = Console.ReadLine();
            Console.WriteLine("Price :");
            string? addPrice = Console.ReadLine();


            if (addPrice == string.Empty || addProduct == string.Empty)
            {
                Console.WriteLine("Enter Either a product or the price");
            }

            else
            {
                string productToAdd = string.Format("{0},{1}", addProduct, addPrice);
                newCart.Add(productToAdd);
                File.WriteAllLines("../../../Cart.csv", newCart);
            }

        }

       public static void removeproducts()
        {
            {
                
                Admin Remove = new Admin();
               Remove.newCart = new List<string>(File.ReadAllLines("../../../Cart.csv"));

                Console.WriteLine("Items in the cart:");
                for (int i = 0; i < Remove.newCart.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Remove.newCart[i]}");
                }

                Console.Write("Enter the number of the item you wish to remove: ");
                if (int.TryParse(Console.ReadLine(), out int choice) &&  choice <=Remove.newCart.Count)
                 
                {
                       Remove.newCart.RemoveAt(choice - 1);
                       File.WriteAllLines("../../../Cart.csv", Remove.newCart);
                       Console.WriteLine("Item has been removed from the cart.");
                   
                }
                           else
                           {
                               Console.WriteLine("Invalid selection. No items were removed.");
                           }
            }
        }

    
        public static void showProducts()
        {
            {
                Admin admin = new Admin(); 
                admin.newCart = new List<string>(File.ReadAllLines("../../../Cart.csv"));

                foreach (var item in admin.newCart)
                {
                    Console.WriteLine(item);
                }
            }

        }

    }



}

