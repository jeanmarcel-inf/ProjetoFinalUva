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

        public RegisterViewModel GetById(int id)
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

            return tables;
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
            var tables = GetById(id);

            _context.Clients.Remove(tables.Client);
            _context.Addresses.Remove(tables.Address);
            _context.BrowsingHistory.Remove(tables.BrowsingHistory);
            _context.Emails.Remove(tables.Email);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var tables = GetById(id);
            return View(tables);
        }

        [HttpPost]
        public IActionResult Update(RegisterViewModel register, int id)
        {
            var tables = GetById(id);

            // Edit Client table
            tables.Client.Name = register.Client.Name;
            tables.Client.BirthDate = register.Client.BirthDate;
            tables.Client.Cpf = register.Client.Cpf;
            
            // Edit Address table
            tables.Address.Cep = register.Address.Cep;
            tables.Address.HomeNumber = register.Address.HomeNumber;

            // Edit BrowsingHistory table
            tables.BrowsingHistory.LastAccess = DateTime.Now;

            // Edit Email table
            tables.Email.Email = register.Email.Email;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
