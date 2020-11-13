using Content_Based_Filtering.Interfaces;
using Content_Based_Filtering.Parsers;
using Model.Algorithm;
using Model.Shop;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Content_Based_Filtering.Vectorizers
{
    public class ItemProfileManager : ICreator<ItemProfile, string>
    {
        private readonly ISplitter _splitter;
        private readonly string delimiter = "|";
        public ItemProfileManager()
        {
            _splitter = new BookParser();
        }

        public ICollection<ItemProfile> CreateProfiles(ICollection<string> bookDistinguishingFeatures, Shop shop)
        {
            var books = shop.Warehouse.Books;

            ConcurrentBag<ItemProfile> itemsProfiles = new ConcurrentBag<ItemProfile>();

            Parallel.ForEach(books, (book) =>
            {
                double[] bookDistinguishingFeaturesBinaryRepresentation = new double[bookDistinguishingFeatures.Count];
                ICollection<string> itemProfileDistinguishingFeatures = new List<string>();
                bookDistinguishingFeaturesBinaryRepresentation = CreateBinaryRepresentation(bookDistinguishingFeatures, bookDistinguishingFeaturesBinaryRepresentation,
                    book.Authors, book.Genres, ref itemProfileDistinguishingFeatures);

                ItemProfile itemProfile = new ItemProfile(book, itemProfileDistinguishingFeatures, bookDistinguishingFeaturesBinaryRepresentation);
                itemsProfiles.Add(itemProfile);
            });

            return itemsProfiles.ToList();
        }

        private double[] CreateBinaryRepresentation(ICollection<string> distinguishingFeatures, double[] binaryRepresentation, string authors, 
            string genres, ref ICollection<string> itemProfileDistinguishingFeatures)
        {
            int counter = 0;

            List<string> resultDistinguishingFeatures = _splitter.SplitMultipleFeatures(delimiter, authors) as List<string>;
            List<string> genresDistinguishingFeatures = _splitter.SplitMultipleFeatures(delimiter, genres) as List<string>;

            resultDistinguishingFeatures.AddRange(genresDistinguishingFeatures);

            foreach (string item in distinguishingFeatures)
            {
                foreach (string feature in resultDistinguishingFeatures)
                {
                    if (item.Equals(feature))
                    {
                        binaryRepresentation[counter] = 1;
                        itemProfileDistinguishingFeatures.Add(feature);

                        break;
                    }
                    else
                    {
                        binaryRepresentation[counter] = 0;
                    }
                }

                counter++;
            }

            return binaryRepresentation;
        }
    }
}
