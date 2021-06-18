using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace TestRun
{
    /// <summary>
    /// This class contains the main program 
    /// </summary>
    class Program
    {


        static void Main(string[] args)
        {
            Users user = new Users();
            user.Encrypt();
            Login();
        }

        enum Menu
        {
            View = 1,
            Manage = 2,
            Exit = 3
        }
        enum Door
        {
            Lock = 1,
            Unlock = 2,
            Back = 3
        }
        static void SecuritreeDash()
        {
            Console.Clear();
            Console.WriteLine("**************************************************");
            Console.WriteLine("*        SECURITREE - Security Dashboard         *");
            Console.WriteLine("**************************************************");
        }
        static void Login()
        {
            string username;
            string password;

            SecuritreeDash();

            Console.WriteLine("Welcome to SecuriTree!\n");
            Console.WriteLine("Please enter your login credentials to begin\n");

            Users user = new Users();


            Console.WriteLine("Username: ");
            username = Console.ReadLine();

            Console.WriteLine("\nPassword: ");
            password = "";

            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring(0, password.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            bool status = false;
            while (status == false)
            {

                if (user.Validate(username, password) == true)
                {

                    Console.WriteLine("\n\nLogin Successfully");
                    Thread.Sleep(500);
                    status = true;
                    menu();
                    break;
                }
                else
                {
                    Console.WriteLine("\nLogin Failed. Incorrect Login Details\n");
                    Console.WriteLine("Pleas enter your login credentials to try again\n");
                    Console.WriteLine("Username:");
                    username = Console.ReadLine();
                    Console.WriteLine("\nEnter Password:");
                    ConsoleKeyInfo Info = Console.ReadKey(true);
                    password = "";
                    while (Info.Key != ConsoleKey.Enter)
                    {
                        if (Info.Key != ConsoleKey.Backspace)
                        {
                            Console.Write("*");
                            password += Info.KeyChar;
                        }
                        else if (Info.Key == ConsoleKey.Backspace)
                        {
                            if (!string.IsNullOrEmpty(password))
                            {
                                password = password.Substring(0, password.Length - 1);
                                int pos = Console.CursorLeft;
                                Console.SetCursorPosition(pos - 1, Console.CursorTop);
                                Console.Write(" ");
                                Console.SetCursorPosition(pos - 1, Console.CursorTop);
                            }
                        }
                        Info = Console.ReadKey(true);

                    }
                }


            }

        }


        static void menu()
        {
            int option;
            SecuritreeDash();

            Console.WriteLine("Main Menu Options: ");
            Console.WriteLine("1. View Security Entity Hierarchy");
            Console.WriteLine("2. Manage Doors");
            Console.WriteLine("3. log Out\n");

            Console.WriteLine("Option: ");
            option = int.Parse(Console.ReadLine());

            Menu MenuOption = new Menu();
            MenuOption = (Menu)option;

            switch (option)
            {
                case 1:
                    ViewSecurityHierarchy();
                    break;
                case 2:
                    ManageDoors();
                    break;
                case 3:
                    Login();
                    break;

            }

        }
        static void ViewSecurityHierarchy()
        {
            SecuritreeDash();
            Console.WriteLine("Entity Hierarchy:\n");
            Hierarchy hierarchy = new Hierarchy();
            hierarchy.ViewHierarchy();
            Console.WriteLine("\nPress ENTER to return to the main menu.");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                menu();
            }
            else
            {
                Environment.Exit(0);
            }

        }

        static void ManageDoors()
        {
            int option;
            SecuritreeDash();
            Console.WriteLine("Manage Doors Menu Options:");
            Console.WriteLine("1. Lock Door");
            Console.WriteLine("2. Unlock Door");
            Console.WriteLine("3. Back\n");
            Console.WriteLine("Option: ");
            option = int.Parse(Console.ReadLine());

            Door MenuOption = new Door();
            MenuOption = (Door)option;

            switch (option)
            {
                case 1:
                    LockDoor();
                    break;
                case 2:
                    UnlockDoor();
                    break;
                case 3:
                    menu();
                    break;

            }
        }

        static void LockDoor()
        {
            Doors door = new Doors();
            string doorID;

            SecuritreeDash();
            
            Console.WriteLine("Lock Door\n");

            Console.WriteLine("Please enter the ID of the door to lock");
            Console.WriteLine("Press ESC to return to the door management screen");
            Console.WriteLine("Door ID: ");
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                menu();
            }
            else
            {
                doorID = Console.ReadLine();

                SecuritreeDash();

                Console.WriteLine("Lock Door\n");
                Console.WriteLine(door.LockDoor(doorID));
            }
            Console.WriteLine("Press ENTER to return to the main menu.");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                menu();
            }
            else
            {
                Environment.Exit(0);
            }
        }
        static void UnlockDoor()
        {
            Doors door = new Doors();
            string doorID;

            SecuritreeDash();

            Console.WriteLine("Unlock Door\n");

            Console.WriteLine("Please enter the ID of the door to unlock");
            Console.WriteLine("Press ESC to return to the door management screen");
            Console.WriteLine("Door ID: ");
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                menu();
            }
            else
            {
                doorID = Console.ReadLine();

                //
                //
                //
                SecuritreeDash();

                Console.WriteLine("Unlock Door\n");
                Console.WriteLine(door.UnlockDoor(doorID));
            }
                Console.WriteLine("Press ENTER to return to the main menu.");

            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                menu();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}

