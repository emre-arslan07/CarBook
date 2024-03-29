﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.BlogRepository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLast3BlogWithAuthor();
        Task<List<Blog>> GetBlogWithAuthor();
        Task<List<Blog>> GetAuthorByBlogId(int id);
    }
}
