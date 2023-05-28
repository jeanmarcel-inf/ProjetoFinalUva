using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public IActionResult Index()
        {
            var tables = new ListClientsViewModel()
            {
                Clients = _context.Clients.ToList(),
                Addresses = _context.Addresses.ToList(),
                BrowsingHistory = _context.BrowsingHistory.ToList(),
                Emails = _context.Emails.ToList(),
            };

            return View(tables);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var client = _context.Clients.Where(c => c.Id == id).FirstOrDefault();
            var address = _context.Addresses.Where(a => a.ClientId == id).FirstOrDefault();
            var browsingHistory = _context.BrowsingHistory.Where(bh => bh.ClientId == id).FirstOrDefault();
            var email = _context.Emails.Where(e => e.ClientId == id).FirstOrDefault();

            _context.Clients.Remove(client);
            _context.Addresses.Remove(address);
            _context.BrowsingHistory.Remove(browsingHistory);
            _context.Emails.Remove(email);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
