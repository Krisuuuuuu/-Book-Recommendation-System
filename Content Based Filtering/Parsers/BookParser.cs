using Content_Based_Filtering.Interfaces;
using Model.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Content_Based_Filtering.Parsers
{
    public class BookParser : IParser<Book>, ISplitter
    {
        private readonly string delimiter = "|";

        public ICollection<string> GetDistinguishingFeatures(ICollection<Book> books)
        {
            ICollection<string> bookDistinguishingFeatures = new List<string>();

            foreach (Book book in books)
            {
                if (book.Authors.Contains(delimiter))
                {
                    var result = SplitMultipleFeatures(delimiter, book.Authors);

                    foreach (string item in result)
                    {
                        if (!CheckIfItemExistInCollection(item, bookDistinguishingFeatures))
                            bookDistinguishingFeatures.Add(item);
                    }

                }
                else
                {
                    if (!CheckIfItemExistInCollection(book.Authors, bookDistinguishingFeatures))
                        bookDistinguishingFeatures.Add(book.Authors);
                }

                if (book.Genres.Contains(delimiter))
                {
                    var result = SplitMultipleFeatures(delimiter, book.Genres);

                    foreach (string item in result)
                    {
                        if (!CheckIfItemExistInCollection(item, bookDistinguishingFeatures))
                            bookDistinguishingFeatures.Add(item);
                    }

                }
                else
                {
                    if (!CheckIfItemExistInCollection(book.Genres, bookDistinguishingFeatures))
                        bookDistinguishingFeatures.Add(book.Genres);
                }

            }

            return bookDistinguishingFeatures;
        }

        public ICollection<string> SplitMultipleFeatures(string delimiter, string item)
        {
            ICollection<string> features = new List<string>();
            string temp;
            int index;

            if (!item.Contains(delimiter))
            {
                features.Add(item);
                return features;
            }
            else
            {
                while (item.Contains(delimiter))
                {
                    index = item.IndexOf(delimiter, 0);
                    temp = item.Substring(0, index + 1);
                    item = item.Substring(index + 1);
                    temp = temp.Replace(delimiter, "");

                    features.Add(temp);
                }

                item = item.Replace(delimiter, "");
                features.Add(item);
            }

            return features;
        }

        private bool CheckIfItemExistInCollection(string item, ICollection<string> collection)
        {
            return collection.Contains(item);
        }
    }
}
