using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ShermansLittleSecretWardrobe.Pages
{
    public class FeedbackModel : PageModel
    {

        public bool hasData = false;
        public string name = "";
        public string message = "";
        public string email = "";
        public void OnGet()
        { }

        public void OnPost()
        {
            hasData = true;
            name = Request.Form["name"];
            message = Request.Form["subject"];
            email = Request.Form["email"];
        }
    }
}