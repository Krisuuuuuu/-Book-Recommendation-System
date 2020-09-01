using CsvHelper.Configuration;
using Model.Shop;

namespace Resources.Mappers
{
    sealed class GoodreadsBookMapper : ClassMap<Book>
    {
        public GoodreadsBookMapper()
        {
            Map(m => m.Authors).Name("book_authors");
            Map(m => m.Title).Name("book_title");
            Map(m => m.Genres).Name("genres");
            Map(m => m.Description).Name("book_desc");
            Map(m => m.Format).Name("book_format");
            Map(m => m.PageNumber).Name("book_pages");
            Map(m => m.Rating).Name("book_rating");
        }
    }
}
