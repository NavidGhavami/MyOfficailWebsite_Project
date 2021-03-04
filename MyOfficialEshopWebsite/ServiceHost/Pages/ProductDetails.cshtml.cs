using _01_Query.Contract.Product;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging.Abstractions;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.Product;

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


        public void OnGet(string id, EditProductView edit)
        {
            Product = _productQuery.GetProductDetails(id);
            edit.View = Product.View += 1;
            edit.Id = Product.Id;
            var result = _productApplication.EditProductView(edit);

        }

        public IActionResult OnPost(AddComment command, string productSlug)
        {
            command.Type = CommentTypes.Product;
            var result = _commentApplication.Add(command);
            return RedirectToPage("./ProductDetails", new { id = productSlug });
        }
    }
}
