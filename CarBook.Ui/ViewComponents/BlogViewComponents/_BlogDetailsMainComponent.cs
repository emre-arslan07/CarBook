﻿using CarBook.DTO.BlogDTOs;
using CarBook.DTO.CommentDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var count = await GenericApiProvider<ResultCommentCountByBlogIdDTO>.GetAsyncById("Comment", "GetCommentCountByBlogId", id);
            ViewBag.CommentCount=count.CommentCount;
            return View(await GenericApiProvider<ResultGetBlogByIdDTO>.GetAsyncById("Blog", "GetBlog", id));
        }
    }
}
