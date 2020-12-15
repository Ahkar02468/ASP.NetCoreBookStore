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
        private readonly LanguageRepository _languageRepository = null;
        public BookController(BookRepository bookRepository,LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
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

        public async Task<ViewResult> AddNewBook(bool isSuccess = false,int bookId=0)
        {
            var model = new BookModel();
            //ViewBag.Laguage = new SelectList(GetLanguage(),"Id","Text");
            ViewBag.Laguage = new SelectList(await _languageRepository.GetLanguages(),"Id","Name");
            ViewBag.BookId = bookId;
            ViewBag.IsSuccess = isSuccess;
            return View(model);
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
            ViewBag.Laguage = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name"); 
            return View();
        }
        
    }
}
