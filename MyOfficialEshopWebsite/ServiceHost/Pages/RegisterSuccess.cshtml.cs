using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class RegisterSuccessModel : PageModel
    {
        public OperationResult Result;
        public void OnGet(OperationResult result)
        {
            Result = result;
        }
    }
}
