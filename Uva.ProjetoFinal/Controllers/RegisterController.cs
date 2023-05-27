using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
            var clients = new ClientModel
            {
                Name = registerViewModel.Client.Name,
                BirthDate = registerViewModel.Client.BirthDate,
                Cpf = registerViewModel.Client.Cpf,
            };

            var c = _context.Clients.Add(clients);

            _context.SaveChanges();

            var address = new AddressModel
            {
                Cep = registerViewModel.Address.Cep,
                HomeNumber = registerViewModel.Address.HomeNumber,
                ClientId = c.Entity.Id,
            };

            _context.Addresses.Add(address);
            _context.SaveChanges();
            //_context.Addresses.Add(registerModel.Address);
            //_context.Emails.Add(registerModel.Email);



            return RedirectToAction("Index");
        }
    }
}
