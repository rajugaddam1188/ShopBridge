using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryLibrary.BL;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShopBridge.Controllers
{
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public InventoryController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [Route("AddItem")]
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] Inventory inventory)
        {
            Inventory _inventory = new Inventory();
            
          if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
          
                _inventory = await InventoryBL.AddItem(inventory);
                if(_inventory !=null)
                {
                    return CreatedAtAction("AddItem", _inventory);
                }
                else
                {
                return BadRequest("Insertion failed");
                }
            
         
            //return null;
        }
        [Route("UpdateItem")]
        [HttpPatch]
        public async Task<IActionResult> UpdateItem(int ItemId,[FromBody] Inventory inventory)
        {
            Inventory _inventory = new Inventory();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            inventory.ItemId = ItemId;
            _inventory = await InventoryBL.UpdateItem( inventory);
            if (_inventory != null)
            {
                return Ok( _inventory);
            }
            else
            {
                return BadRequest("Insertion failed");
            }
        }
        [HttpGet]
        [Route("ListofItems")]
        public async Task<IActionResult> ListofItems()
        {
            List<Inventory> inventories = new List<Inventory>();
            inventories = await InventoryBL.ListofItems();
            if(inventories.Count>0)
            {
                return Ok(inventories);
            }
            else
            {
                return NoContent();
            }
            
        }
        [HttpDelete]
        [Route("DeleteItem")]
        public async Task<IActionResult> DeleteItem(int ItemId)
        {
        
            if(!await InventoryBL.AnyItemExists(ItemId))
            {
                return NoContent();
            }
            if (await InventoryBL.DeleteItem(ItemId))
            {
                return Ok();
            }
            return NotFound();

        }


    }

      
    }


    

