using _01_Query.Contract.Product;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.Product;

namespace ServiceHost.Pages
{
    
    public class ProductDetailsModel : PageModel
    {
        public ProductQueryModel Product;
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;
        private readonly IProductApplication _productApplication;


        public ProductDetailsModel(IProductQuery productQuery, ICommentApplication commentApplication, IProductApplication productApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
            _productApplication = productApplication;
        }

        
        public void OnGet(string id)
        {
            Product = _productQuery.GetProductDetails(id);
        }

        
        public IActionResult OnPost(AddComment command, string productSlug)
        {
            command.Type = CommentTypes.Product;
            var result = _commentApplication.Add(command);
            return RedirectToPage("./ProductDetails", new { id = productSlug });
        }
    }
}
