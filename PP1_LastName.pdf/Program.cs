using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string[]> d1 = new Dictionary<int, string[]>();
            int userCount = 0;
            int userKeySafe = 0;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"____________________________________\n\nThere are {userCount} ID(s) in the Dictionary\n\nPlease input the choices a-f only\n\n____________________________________\n");
                int searchBy;

                List<string> userInfo = new List<string>();
                userInfo.Add("Last Name\t:\t");
                userInfo.Add("First Name\t:\t");
                userInfo.Add("Email Add\t:\t");
                userInfo.Add("Contact Number\t:\t");

                Console.WriteLine($"What would you like to do?\n\na. ADD USER\nb. UPDATE USER\nc. VIEW\nd. DELETE USER\ne. VIEW ALL\nf. QUIT");
                string userChoice = Console.ReadLine();

                if (userChoice.ToLower() == "a")
                {
                    userCount++;
                    userKeySafe++;
                    d1[userKeySafe] = new string[4];
                }
                else if (userChoice.ToLower() == "f")
                {
                    Console.WriteLine($"Exiting Program...");
                    break;
                }

                Console.WriteLine();

                if (userCount > 0)
                {

                    switch (userChoice.ToLower())
                    {
                        case "a":
                            for (int i = 0; i < userInfo.Count(); i++)
                            {
                                Console.Write($"{userInfo[i]}");
                                d1[userKeySafe][i] = Console.ReadLine();
                            }
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"\nUSER ID {userKeySafe}:  {d1[userKeySafe][0]}, {d1[userKeySafe][1]} has been added to the Dictionary.");
                            break;

                        case "b":
                            Console.Write("Please input the ID of the user to update :  ");
                            int idUpdate = int.Parse(Console.ReadLine());
                            if (d1.ContainsKey(idUpdate))
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"\nRecord of user ID found!\n\nID {idUpdate}:");
                                for (int i = 0; i < userInfo.Count(); i++)
                                {
                                    Console.Write($"{userInfo[i]}");
                                    Console.Write(d1[idUpdate][i] + "\n");
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"\nU P D A T I N G");
                                for (int i = 0; i < userInfo.Count(); i++)
                                {
                                    Console.Write($"{userInfo[i]}");
                                    d1[idUpdate][i] = Console.ReadLine();
                                }
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"\nUSER ID {userKeySafe}:  {d1[userKeySafe][0]}, {d1[userKeySafe][1]} has been updated.");

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Record of user ID not found!");
                            }
                            break;

                        case "c":
                            Console.WriteLine("Search by: [1] ID\t[2] Surname");
                            searchBy = int.Parse(Console.ReadLine());
                            if (searchBy == 2)
                            {
                                Console.Write("Surname of user you want to search:  ");
                                string searchUsername = Console.ReadLine();
                                int x = 0;
                                Console.WriteLine();
                                foreach (KeyValuePair<int, string[]> kvp in d1)
                                {
                                    if (d1[kvp.Key][0].ToLower() == searchUsername.ToLower())
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine($"Record of user ID found! \nID {userKeySafe}:");
                                        for (int i = 0; i < userInfo.Count(); i++)
                                        {
                                            Console.Write($"{userInfo[i]}");
                                            Console.Write(d1[kvp.Key][i] + "\n");
                                        }
                                        x++;
                                    }
                                    Console.WriteLine();
                                }

                                if (x == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"There are no users with the surname \"{searchUsername}\"");
                                }
                            }
                            else if (searchBy == 1)
                            {
                                Console.Write("Please write the ID of the User you want to search:  ");
                                int userIdSearch = int.Parse(Console.ReadLine());
                                if (d1.ContainsKey(userIdSearch) == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"\nRecord of user ID found! \nID {userIdSearch}:");
                                    for (int i = 0; i < userInfo.Count(); i++)
                                    {
                                        Console.Write($"{userInfo[i]}");
                                        Console.Write(d1[userIdSearch][i] + "\n");
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Record of user ID not found!");
                                }
                            }
                            break;

                        case "d":
                            Console.WriteLine("Search by: [1] ID\t[2] Surname");
                            searchBy = int.Parse(Console.ReadLine());
                            if (searchBy == 2)
                            {
                                Console.Write("Surname of user you want to search:  ");
                                string searchUsername = Console.ReadLine();
                                int x = 0;

                                List<int> nameDelete = new List<int>();
                                List<int> nameFinal = new List<int>();

                                Console.WriteLine();
                                foreach (KeyValuePair<int, string[]> kvp in d1)
                                {
                                    if (d1[kvp.Key][0].ToLower() == searchUsername.ToLower())
                                    {
                                        nameDelete.Add(kvp.Key);
                                        x++;
                                    }
                                }
                                Console.WriteLine($"User IDs with the Surname \"{searchUsername}\"");
                                foreach (int name in nameDelete)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"\nID {name}:");
                                    for (int i = 0; i < userInfo.Count(); i++)
                                    {
                                        Console.Write($"{userInfo[i]}");
                                        Console.Write(d1[name][i] + "\n");
                                    }
                                    Console.WriteLine();
                                }

                                if (nameDelete.Count() > 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"\nHow many \"{searchUsername}\"s would you like to remove:  ");
                                    int howMany = int.Parse(Console.ReadLine());
                                    Console.WriteLine($"\nIDs of \"{searchUsername}\"s you would like to remove (Enter each ID individually):  ");
                                    for (int i = 0; i < howMany; i++)
                                    {
                                        nameFinal.Add(int.Parse(Console.ReadLine()));
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"\nID of \"{searchUsername}\" you would like to remove:  ");
                                    for (int i = 0; i < 1; i++)
                                    {
                                        nameFinal.Add(int.Parse(Console.ReadLine()));
                                    }
                                }


                                foreach (int name in nameFinal)
                                {
                                    d1.Remove(name);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"{searchUsername} has successfully been removed...");
                                    userCount--;
                                }

                                if (x == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"\nThere are no users with the surname \"{searchUsername}\"");
                                }
                            }
                            else if (searchBy == 1)
                            {
                                Console.Write("Please write the ID of the User you want to search:  ");
                                int userIdDelete = int.Parse(Console.ReadLine());
                                if (d1.ContainsKey(userIdDelete) == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"Record of user ID to DELETE found! ID {userIdDelete}:");
                                    for (int i = 0; i < userInfo.Count(); i++)
                                    {
                                        Console.Write($"{userInfo[i]}");
                                        Console.Write(d1[userIdDelete][i] + "\n");
                                    }
                                    Console.WriteLine($"ID {userIdDelete} has successfully been removed...");
                                    d1.Remove(userIdDelete);
                                    userCount--;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Record of user ID not found!");
                                }
                            }
                            break;

                        case "e":
                            Console.WriteLine($"Displaying {userCount} ID(s) from the dictionary\n");
                            foreach (KeyValuePair<int, string[]> kvp in d1)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"ID{kvp.Key}:");
                                for (int i = 0; i < userInfo.Count(); i++)
                                {
                                    Console.Write($"{userInfo[i]}");
                                    Console.Write(d1[kvp.Key][i] + "\n");
                                }
                                Console.WriteLine();
                            }
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("There are currently no user ID records...");
                }
                Console.ReadLine();
                Console.Clear();
            }

        }
    }
}
