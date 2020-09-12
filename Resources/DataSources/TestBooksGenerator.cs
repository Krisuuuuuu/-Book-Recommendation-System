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
                Genres = "Dark Fantasy|Action|Magic|Slav|Fiction|Non-Humans"
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
                Authors = "Homer",
                Title = "Illiad",
                Genres = "History|Action|Mythology|Epos|Art|Antique|Greece"
            };

            Book book9 = new Book()
            {
                Authors = "Hanna Krall",
                Title = "Make It Before God",
                Genres = "History|Action|War|Judes|Nazism|Retrospection|Extermination|Holocaust"
            };

            Book book10 = new Book()
            {
                Authors = "Stephen Ambrose",
                Title = "Band of Brothers",
                Genres = "History|Action|War|Nazism|Retrospection|Extermination|Soldiers"
            };

            Book book11 = new Book()
            {
                Authors = "Henryk Sienkiewicz",
                Title = "Teutonic Knights",
                Genres = "History|Action|War|Middle Ages|Love|Knights"
            };

            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.Add(book5);
            books.Add(book6);
            books.Add(book7);
            books.Add(book8);
            books.Add(book9);
            books.Add(book10);
            books.Add(book11);
            return books;
        }
    }
}
