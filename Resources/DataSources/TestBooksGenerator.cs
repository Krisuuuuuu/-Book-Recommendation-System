using Model.Shop;
using System.Collections.Generic;

namespace Resources.DataSources
{
    public static class TestBooksGenerator
    {
        public static ICollection<Book> GenerateBooks()
        {
            ICollection<Book> books = new List<Book>();

            Book book1 = new Book()
            {
                Authors = "Andrzej Sapkowski",
                Title = "The Witcher: Blood of Elves",
                Genres = "Dark Fantasy|Action|Magic|Slav|Fiction|Non-Humans|Life-History"
            };

            Book book2 = new Book()
            {
                Authors = "John Ronald Reuel Tolkien",
                Title = "The Lord of the Rings: The Return of the King",
                Genres = "Fantasy|Action|Magic|Fiction|Adventure|Non-Humans"
            };

            Book book3 = new Book()
            {
                Authors = "George Raymond Richard Martin",
                Title = "The Song of the Ice and Fire",
                Genres = "Fantasy|Action|Magic|Fiction|Adventure|Non-Humans|Policy"
            };

            Book book4 = new Book()
            {
                Authors = "Jenson Button",
                Title = "Jenson Button: Life to the Limit: My Autobiography",
                Genres = "Autobiography|Life-History|Adventure|Sports|Policy|Inspiration|F1|Retrospection"
            };

            Book book5 = new Book()
            {
                Authors = "Adam Bielecki",
                Title = "From under Frozen Eyelids",
                Genres = "Autobiography|Life-History|Adventure|Sports|Mountains|Inspiration|Mountaineering|Retrospection"
            };

            Book book6 = new Book()
            {
                Authors = "Ashlee Vans",
                Title = "Elon Musk",
                Genres = "Autobiography|Life-History|Science|Power of the Mind|Inspiration|Genius|Retrospection"
            };


            Book book7 = new Book()
            {
                Authors = "Adam Mickiewicz",
                Title = "Pan Tadeusz",
                Genres = "History|Action|Policy|Epos|Art|Romanticism|Bard"
            };


            Book book8 = new Book()
            {
                Authors = "Illiad",
                Title = "Homer",
                Genres = "History|Action|Mythology|Epos|Art|Antique|Greece"
            };

            Book book9 = new Book()
            {
                Authors = "Make It Before God",
                Title = "Hanna Krall",
                Genres = "History|Action|War|Judes|Nazism|Retrospection|Extermination|Holocaust"
            };

            Book book10 = new Book()
            {
                Authors = "Band of Brothers",
                Title = "Stephen Ambrose",
                Genres = "History|Action|War|Nazism|Retrospection|Extermination|Soldiers"
            };

            Book book11 = new Book()
            {
                Authors = "Teutonic Knights",
                Title = "Henryk Sienkiewicz",
                Genres = "History|Action|War|Middle Ages|Love|Knights"
            };

            return books;
        }
    }
}
