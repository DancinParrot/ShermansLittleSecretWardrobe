using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShermansLittleSecretWardrobe.Pages
{
    [Authorize(Roles = "User, Admin")]
    public class RatingsModel : PageModel
    {
        private readonly ILogger<RatingsModel> _logger;

        public RatingsModel(ILogger<RatingsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}