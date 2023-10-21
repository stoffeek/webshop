﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop5;


public record Admin(string Username) : IUser
{
    public void ShowMainMenu()
    {
      while (true)
      {
                    Catalog c = new Catalog();
        Console.WriteLine($"Current user: {Username}");
        Console.WriteLine("1: Add product to catalog");
        Console.WriteLine("2: Remove product from catalog");
        Console.WriteLine("3 :Display Product catalog");
        Console.WriteLine("4 : Edit or remove user");
       
        if(int.TryParse(Console.ReadLine(),out int choice))
        {

             switch (choice)
             {
                  case 1:
                         Catalog.AddToCatalog(); 
                              break;
                  case 2:
                         c.removeproducts();
                              break;
                  case 3:
                         Catalog.displaycatalog();
                              break;
                  case 4:
                         ChangeUser();
                              break;
             }
                      

        }
 
      }
        
        

    }

     public static void ChangeUser()
    {
        List<string> userNames = new List<string>(File.ReadAllLines("../../../users.csv"));
        List<string> Passwords = new List<string>(File.ReadAllLines("../../../users.csv"));

        for (int i = 0; i < userNames.Count; i++)
        {


            Console.WriteLine("Do you wish to remove or change? : Type: remove - To remove Type: change - To change");
            string change = Console.ReadLine();
            if (change == "remove")
            {
                for (int v = 0; i < userNames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {userNames[i]}");
                }

                Console.Write("Enter the number of the item you wish to remove: ");
                if (int.TryParse(Console.ReadLine(), out int removeNumb) && removeNumb <= userNames.Count)
                {
                    userNames.RemoveAt(removeNumb - 1);
                    File.WriteAllLines("../../../users.csv", userNames);
                    Console.WriteLine("User succesfully removed! Updated user list:");
                    foreach (string users in userNames)
                    {
                        Console.WriteLine(users);
                        Console.ReadKey();
                        Console.Clear();

                    }
                }
            }

            if (change == "change")
            {
                for (int v = 0; i < userNames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {userNames[i]}");
                }



                Console.WriteLine("What user do you want to change? Enter a number:");
                if (int.TryParse(Console.ReadLine(), out int changeNumb) && changeNumb <= userNames.Count)
                {
                    Console.WriteLine($"You choosed: {userNames[changeNumb - 1]}");
                    Console.WriteLine("Enter you change: ");
                    string changedUser = Console.ReadLine();
                    Console.WriteLine($"Previus password :{Passwords[changeNumb - 1]}");
                    Console.WriteLine("Enter your new");
                    string? newPassword = Console.ReadLine();

                    Passwords[changeNumb - 1] = newPassword;
                    userNames[changeNumb - 1] = changedUser;
                    File.WriteAllLines("../../../users.csv", userNames);
                    File.WriteAllLines("../../../users.csv", Passwords);

                    Console.WriteLine("User has succesfully been changed press any key to see your updates: ");
                    Console.ReadKey();
                    Console.Clear();
                    foreach (string userschange in userNames)
                    {
                        Console.WriteLine(userschange);
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }


        }


    }


}
    




