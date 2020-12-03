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
                Title = "Wiedźmin: Ostatnie Życzenie",
                Genres = "Magia|Akcja|Fantasy"
            };

            Book book2 = new Book()
            {
                Authors = "Clive Staples Lewis",
                Title = "Opowieści z Narnii: Książe Kaspian",
                Genres = "Magia|Akcja|Fantasy"
            };

            Book book3 = new Book()
            {
                Authors = "Jenson Button",
                Title = "Życie na Maksa: Moja Autobiografia",
                Genres = "Sport|Biografia|Inspiracja"
            };

            Book book4 = new Book()
            {
                Authors = "Zlatan Ibrahimović",
                Title = "Ja, Ibra",
                Genres = "Sport|Biografia|Inspiracja"
            };

            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            return books;
        }
    }
}
