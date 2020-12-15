using AKSB.BookStore.Data;
using AKSB.BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKSB.BookStore.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext _languageContext = null;
        public LanguageRepository(BookStoreContext bookStoreContext)
        {
            _languageContext = bookStoreContext;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _languageContext.Languages.Select(x => new LanguageModel
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
