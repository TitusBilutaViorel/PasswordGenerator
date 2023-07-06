﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Globalization;

namespace PasswordGenerator
{
    internal class Program
    {
        private static System.Timers.Timer expTimer;
        private static bool PassExp;
        static void Main(string[] args)
        {

            Console.Write("Enter the userID, current date and time (username yyyy-MM-dd HH:mm:ss): ");
            string input = Console.ReadLine();

            // Despartim intrarea in 3 string-uri (se despart dupa fiecare spatiu)
            string[] inputParts = input.Split(' ');

            if (inputParts.Length >= 3)
            {
                string userID = inputParts[0];
                string dateString = inputParts[1];
                string timeString = inputParts[2];

                // Verificam daca data si ora sunt scrise corect (dupa ce am despartit input-ul, trebuie sa concatenam data si ora)
                if (DateTime.TryParseExact(dateString + " " + timeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime inputDateTime))
                {
                    GeneratePass();

                    // Setam timerul pentru 30 sec
                    expTimer = new System.Timers.Timer(30000);
                    expTimer.Elapsed += PasswordExpired;
                    expTimer.AutoReset = false;
                    expTimer.Enabled = true;

                    // Afisam mesaj dupa ce trec 20, respectiv 10 secunde de cand am generat parola
                    System.Timers.Timer SecondTimer = new System.Timers.Timer(20000);
                    SecondTimer.Elapsed += SecondTimerMessage;
                    SecondTimer.AutoReset = false;
                    SecondTimer.Enabled = true;

                    System.Timers.Timer ThirdTimer = new System.Timers.Timer(10000);
                    ThirdTimer.Elapsed += ThirdTimerMessage;
                    ThirdTimer.AutoReset = false;
                    ThirdTimer.Enabled = true;

                    while (true)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        Console.WriteLine();
                        if (key.Key == ConsoleKey.Enter)
                        {
                            GeneratePass();
                            expTimer.Start();
                            PassExp = false;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    // Input-ul nu este scris corect
                    Console.WriteLine("Invalid input. Enter the date and time like this: yyyy-MM-dd HH:mm:ss.");
                }
            }

            Console.ReadKey();
        }

        private static void GeneratePass()
        {
            // Generam o parola aleatoare
            string password = Generator.RandomPassword();

            Console.WriteLine("Generated password is: " + password);
            Console.WriteLine("The password will expire in 30 sec.");
        }

        private static void PasswordExpired(object sender, ElapsedEventArgs e)
        {
            PassExp = true;
            Console.WriteLine("Password has expired.");
            Console.WriteLine("Press Enter key to generate another password.");
        }

        private static void SecondTimerMessage(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Twenty seconds have passed.");
        }

        private static void ThirdTimerMessage(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Ten seconds have passed.");
        }
    }

    internal class Generator
    {
        public static string RandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-=_+[]{}|;:,.<>?";

            // Alegem o parola cu lungimea de 15 caractere
            const int passwordLength = 15;

            // Generam numere aleatoare si stocam caracterele parolei 
            Random random = new Random();
            char[] password = new char[passwordLength];

            for (int i = 0; i < passwordLength; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }

            return new string(password);
        }
    }
}