using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessService;

namespace CarSaleWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserService _service;

        public IndexModel(UserService service)
        {
            _service = service;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _service.GetUserList();
        }
    }
}
