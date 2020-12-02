using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AKSB.BookStore.Models;
using AKSB.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AKSB.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName,string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }

        public ViewResult AddNewBook(bool isSuccess = false,int bookId=0)
        {
            ViewBag.Laguage = new SelectList(new List<string> { "English","Chinese","Myanmar"});
            ViewBag.BookId = bookId;
            ViewBag.IsSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.Laguage = new SelectList(new List<string> { "English", "Chinese", "Myanmar" });
            ModelState.AddModelError("", "This is custom error");
            return View();
        }
    }
}
