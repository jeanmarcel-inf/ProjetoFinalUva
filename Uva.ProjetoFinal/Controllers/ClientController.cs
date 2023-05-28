using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
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

        public IActionResult Details(int id)
        {
            var client = _context.Clients.Where(c => c.Id == id).FirstOrDefault();
            var address = _context.Addresses.Where(a => a.ClientId == id).FirstOrDefault();
            var browsingHistory = _context.BrowsingHistory.Where(bh => bh.ClientId == id).FirstOrDefault();
            var email = _context.Emails.Where(e => e.ClientId == id).FirstOrDefault();

            var tables = new RegisterViewModel()
            {
                Client = client,
                Address = address,
                BrowsingHistory = browsingHistory,
                Email = email,
            };

            return View(tables);
        }

        [HttpPost]
        public IActionResult Update(RegisterViewModel register, int id)
        { 
            
            var clientEdit = _context.Clients.Where(c => c.Id == id).FirstOrDefault();
            var addressEdit = _context.Addresses.Where(a => a.ClientId == id).FirstOrDefault();
            var browsingHistoryEdit = _context.BrowsingHistory.Where(bh => bh.ClientId == id).FirstOrDefault();
            var emailEdit = _context.Emails.Where(e => e.ClientId == id).FirstOrDefault();

            clientEdit.Name = register.Client.Name;
            clientEdit.BirthDate = register.Client.BirthDate;
            clientEdit.Cpf = register.Client.Cpf;

            addressEdit.Cep = register.Address.Cep;
            addressEdit.Cep = register.Address.HomeNumber;

            browsingHistoryEdit.LastAccess = DateTime.Now;

            emailEdit.Email = register.Email.Email;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
