using Content_Based_Filtering.Interfaces;
using Model.Algorithm;
using Model.Shop;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Content_Based_Filtering.Printers
{
    public class Printer : IPrinter
    {
        public void PrintResults(ICollection<UserPredictions> usersPredictions, int number)
        {
            Console.WriteLine("***** Results *****");

            foreach(UserPredictions userPredictions in usersPredictions)
            {
                Console.WriteLine("");
                Console.WriteLine("Client: " + userPredictions.UserProfile.Client.FullName);
                Console.WriteLine("Purchased Products: ");

                foreach(Order order in userPredictions.UserProfile.Client.Orders)
                {
                    foreach(Book book in order.Products)
                    {
                        Console.WriteLine(book.Authors.Replace("|", ", ") + " - " + book.Title);
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("Recommendations: ");

                foreach(KeyValuePair<Book, double> results in userPredictions.Results.Take(number))
                {
                    double score = results.Value;
                    Console.WriteLine(results.Key.Authors.Replace("|", ", ") + " - " + results.Key.Title + " - score - " + score.ToString("F5"));
                }

                Console.WriteLine("");
            }
        }
        public void PrintSimulationTime(TimeSpan time)
        {
            Console.WriteLine("\nSimulation time[s]: " + time.TotalSeconds);
            Console.WriteLine();
        }
    }
}
