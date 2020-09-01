using CsvHelper;
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
        private readonly string _mainPath;
        public ResourceManager()
        {
            _mainPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + @"\Resources\DataSources\";
        }
        public ICollection<Book> ReadSource()
        {
            string localPath = _mainPath + @"Google-Books-1,3K.csv";

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
    }
}
