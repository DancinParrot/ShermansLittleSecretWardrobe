using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ShermansLittleSecretWardrobe.Pages
{
    public class FeedbackModel : PageModel
    {

        public bool hasData = false;
        public string firstName = "";
        public string lastName = "";
        public string message = "";
        public void OnGet()
        { }

        public void OnPost()
        {
            hasData = true;
            firstName = Request.Form["firstname"];
            lastName = Request.Form["lastname"];
            message = Request.Form["subject"];
        }
    }
}