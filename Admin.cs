﻿namespace WebShop5
{
    public class Admin
    {

        static public void AdminLogIn()
        {

            string AdminUserName = "Admin";
            string AdminPassword = "WebShop5";

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
                    Console.WriteLine("0 = EXIT");
                    int AdminChoice = Convert.ToInt32(Console.ReadLine());

                    switch (AdminChoice)
                    {
                        case 0:
                            AdminMenu = false;
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




    }

}


