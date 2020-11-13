using Content_Based_Filtering.Interfaces;
using System;

namespace Content_Based_Filtering
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRecommender recommenderSystem = new RecommenderSystem();
            recommenderSystem.Recommend();
            Console.ReadKey();
        }
    }
}
