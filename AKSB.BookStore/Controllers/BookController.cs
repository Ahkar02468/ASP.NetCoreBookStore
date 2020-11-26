using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AKSB.BookStore.Controllers
{
    public class BookController : Controller
    {
        public string GetAllBooks()
        {
            return "All books.";
        }

        public string GetBook(int id)
        {
            return $"Book with id of {id}.";
        }

        public string SearchBooks(string bookName,string authorName)
        {
            return $"Book with name {bookName} and author is {authorName}";
        }
    }
}
