using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShermansLittleSecretWardrobe.Pages
{
    public class FeedbackModel : PageModel
    {
        private readonly ILogger<FeedbackModel> _logger;

        public FeedbackModel(ILogger<FeedbackModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}