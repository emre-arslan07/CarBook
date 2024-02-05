using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Domain.Entities;
using CarBook.Peristence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Peristence.Repositories.CommentRepositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CarBookDbContext _context;

        public CommentRepository(CarBookDbContext context)
        {
            _context = context;
        }

        public Task<List<Comment>> GetCommentsByBlogId(int id)
        {
            return _context.Comments.Include(x=>x.Blog).Where(y=>y.BlogId==id).ToListAsync();
        }

        public async Task<int> GetCommentsCountByBlogId(int id)
        {
            return await _context.Comments.Where(x=>x.BlogId==id).CountAsync();
        }
    }
}
