using AKSB.BookStore.Data;
using AKSB.BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKSB.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _bookStoreContext = null;
        public BookRepository(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext; 
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow
            };
            await _bookStoreContext.AddAsync(newBook);
            await _bookStoreContext.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _bookStoreContext.Books.ToListAsync();
            if (allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPages = book.TotalPages
                    });
                }
            }
            return books;
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title,string authorName)
        {
            return DataSource().Where(s => s.Title.Contains(title) && s.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){ Id=1,Title="MVC",Author="AKSB",Description="This is the description of MVC book.",Category="Programming",Language="English",TotalPages=1000},
                new BookModel(){Id=2,Title="C#",Author="John" ,Description="This is the description of C# book.",Category="C sharp",Language="English",TotalPages=400},
                new BookModel(){Id=3,Title="Java",Author="Mayer" ,Description="This is the description of Java book.",Category="Framework",Language="French",TotalPages=700},
                new BookModel(){Id=4,Title="PHP",Author="Laracast" ,Description="This is the description of PHP book.",Category="Interface",Language="India",TotalPages=200},
                new BookModel(){Id=5,Title="Dot Net Core",Author="PluralSight" ,Description="This is the description of Dot Net Core book.",Category="Microsoft",Language="Polish",TotalPages=340}
            };
        }
    }
}
