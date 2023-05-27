using Microsoft.AspNetCore.Mvc;
using Uva.ProjetoFinal.Data;
using Uva.ProjetoFinal.Models;

namespace Uva.ProjetoFinal.Controllers
{
    public class ClientController : Controller
    {
        readonly private ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<ClientModel> clients = _context.Clients;

            return View(clients);
        }
    }
}
