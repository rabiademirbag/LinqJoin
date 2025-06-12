using LinqJoin;

public class Program
{
    public static void Main(string [] args)
    {
        List<Authors> authors = new List<Authors>();
        List<Books> books = new List<Books>();
        authors.Add(new Authors()
        {
            AuthorId = 1,
            Name = "Orhan Pamuk"
        });
        authors.Add(new Authors()
        {
            AuthorId = 2,
            Name = "Elif Şafak"
        });
        authors.Add(new Authors()
        {
            AuthorId= 3,
            Name="Ahmet Ümit"
        });
        books.Add(new Books()
        {
            AuthorId = 1,
            BookId = 1,
            Title = "Kar"
        });
        books.Add(new Books()
        {
            AuthorId = 1,
            BookId = 2,
            Title = "İstanbul"
        });
        books.Add(new Books()
        {
            AuthorId = 2,
            BookId = 3,
            Title = "10 Minutes 38 Seconds in This Strange World"
        });
        books.Add(new Books()
        {
            AuthorId = 3,
            BookId = 4,
            Title = "Beyoğlu Rapsodisi"
        });

        var booksWithAuthors = books.Join(authors, author => author.AuthorId, book => book.AuthorId,
            (book, author) => new
            {
                bookTitle = book.Title,
                authorName = author.Name
            });

        foreach(var book in booksWithAuthors)
        {
            Console.WriteLine(book.bookTitle + "," + book.authorName);
        }
    }
}