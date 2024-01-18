using CarBook.Application.Interfaces.BlogRepository;
using CarBook.Domain.Entities;
using CarBook.Peristence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Peristence.Repositories.BlogRepository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookDbContext _context;

        public BlogRepository(CarBookDbContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAuthorByBlogId(int id)
        {
            return await _context.Blogs.Include(x=>x.Author).Where(x=>x.ID == id).ToListAsync();
        }

        public async Task<List<Blog>> GetBlogWithAuthor()
        {
            return await _context.Blogs.Include(x=>x.Author).ToListAsync();
        }

        public async Task<List<Blog>> GetLast3BlogWithAuthor()
        {
            return await _context.Blogs.Include(b=>b.Author).OrderByDescending(b=>b.ID).Take(3).ToListAsync();
        }
    }
}
