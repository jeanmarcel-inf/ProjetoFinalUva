using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using Uva.ProjetoFinal.Data;
using Uva.ProjetoFinal.Models;

namespace Uva.ProjetoFinal.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(RegisterViewModel registerViewModel)
        {
            
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var client = new ClientModel
            {
                Name = registerViewModel.Client.Name,
                BirthDate = registerViewModel.Client.BirthDate,
                Cpf = registerViewModel.Client.Cpf,
            };

            var c = _context.Clients.Add(client);
            _context.SaveChanges();


            var address = new AddressModel
            {
                Cep = registerViewModel.Address.Cep,
                HomeNumber = registerViewModel.Address.HomeNumber,
                ClientId = c.Entity.Id,
            };

            string ipAddress = Response.HttpContext.Connection.RemoteIpAddress.ToString();

            if(ipAddress == "::1")
            {
                ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
            }

            var browsingHistory = new BrowsingHistoryModel
            {
                Ip = ipAddress,
                LastAccess = DateTime.Now,
                ClientId = c.Entity.Id,
            };

            var email = new EmailModel
            {
                Email= registerViewModel.Email.Email,
                ClientId = c.Entity.Id,
            };

            _context.Addresses.Add(address);
            _context.BrowsingHistory.Add(browsingHistory);
            _context.Emails.Add(email);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
