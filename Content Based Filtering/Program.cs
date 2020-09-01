using Model.Shop;
using Resources;
using Resources.Interfaces;
using System;

namespace Content_Based_Filtering
{
    public class Program
    {
        static void Main(string[] args)
        {
            IResourcer<Book> resourceManager = new ResourceManager();
            var result = resourceManager.ReadSource();
        }
    }
}
