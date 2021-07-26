// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;

// using BlogAPI.Models;
// using BlogAPI.Services;

// namespace BlogAPI.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class SetupController : ControllerBase
//     {
//         readonly BlogContext _context;

//         static Author Billy = new Author
//         {
//             AuthorId = 1,
//             Name = "Billy",
//             Description = "I am Billy"
//         };

//         static Category Programming = new Category
//         {
//             CategoryId = 1,
//             Name = "Programming"
//         };

//         static BlogPost Post = new BlogPost
//         {
//             BlogPostId = 1,
//             Title = "Hello World",
//             Summary = "This is a summary",
//             Body = "This is the body",
//             AuthorId = Billy.AuthorId,
//             Author = Billy,
//             CategoryId = Programming.CategoryId,
//             Category = Programming,
//             Tags = new string[] 
//             { 
//                 "tag1", 
//                 "tag2", 
//                 "tag3" 
//             }

//         };

//         public SetupController(BlogContext context)
//         {
//             _context = context;
//         }

//         //GET /api/blogpost
//         [HttpGet]
//         public ActionResult<string> Get()
//         {
//             // _context.Authors.Add(Billy);
//             // _context.Categories.Add(Programming);
//             // _context.BlogPosts.Add(Post);
//             if(!_context.Authors.Any())
//             {
//                 _context.Authors.Add(Billy);
//                 _context.Categories.Add(Programming);
//                 _context.BlogPosts.Add(Post);

//                 _context.SaveChanges();
//             }

//             if(_context.Authors.Any())
//                 return $"There is an author there:{_context.Authors.First().Name}";

//             return "No author there...";
//         }
//     }
// }