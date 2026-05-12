using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Models;
using RepositoryPattern.Core.Services;

namespace RepositoryPattern.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletsController : ControllerBase
    {
        private readonly WalletService _walletService;

        public WalletsController(WalletService service)
        {
            _walletService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_walletService.Get());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var wallet = _walletService.GetById(id);

            if (wallet == null)
                return NotFound();

            return Ok(wallet);
        }

        [HttpPost]
        public IActionResult Create(Wallet wallet)
        {
            _walletService.Create(wallet);

            return Ok(wallet);
        }
    }
}