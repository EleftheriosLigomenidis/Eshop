using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseApiController


    {
        private readonly IBasketRepository _baskerRepository;

        public BasketController(IBasketRepository baskerRepository)
        {
             _baskerRepository = baskerRepository;
        }
        // GET: api/<BasketController>
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>>GetBasketById(string id)
        {
            var basket = await _baskerRepository.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }



        // POST api/<BasketController>
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> Update (CustomerBasket basket )
        {
            var updatedBasket = await _baskerRepository.UpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }

      

        // DELETE api/<BasketController>/5
        [HttpDelete("{id}")]
        public async Task DeleteBasketAsybc (string id)
        {
          await  _baskerRepository.DeleteBasketAsync(id);
        }
    }
}
