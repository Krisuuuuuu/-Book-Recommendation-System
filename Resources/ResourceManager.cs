using CsvHelper;
using Model.Algorithm;
using Model.Shop;
using Resources.Interfaces;
using Resources.Mappers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Resources
{
    public class ResourceManager : IResourcer<Book>
    {
        private readonly string _sourcePath;
        private readonly string _resultPath;
        public ResourceManager()
        {
            _sourcePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + @"\Resources\DataSources\";
            _resultPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + @"\Resources\Results\";
        }
        public ICollection<Book> ReadSource()
        {
            string localPath = _sourcePath + @"GoodreadsBooks.csv";

            try
            {
                using (var reader = new StreamReader(localPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<GoodreadsBookMapper>();
                    var books = csv.GetRecords<Book>().ToList();
                    return books;
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Data Source is not available. Try again later!");
                return null;
            }
        }

        public void SaveResults(ICollection<UserPredictions> userPredictions)
        {
            string localPath = _resultPath + @"Results.csv";

            try
            {
                using (var writer = new StreamWriter(localPath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(userPredictions);
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Results has been not saved. Try again later!");
            }

        }
    }
}
