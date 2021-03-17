using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryLibrary.Models;
namespace InventoryLibrary.BL
{
  public  class InventoryBL
  {

        public static async  Task<Inventory> AddItem(Inventory inventory )
        {
           

            try
            {
                using (var entity = new ShopBridgeContext())
                {
                    tbl_Item_Inventory _tbl_Item_Inventory = new tbl_Item_Inventory()
                    {
                        ItemName = inventory.ItemName,
                        ItemDescription = inventory.ItemDescription,
                        ItemPrice = inventory.ItemPrice
                        
                    };
                    entity.tbl_Item_Inventories.Add(_tbl_Item_Inventory);
                       await   entity.SaveChangesAsync();
                    inventory.ItemId = _tbl_Item_Inventory.ItemId;
                    return inventory;
                    //_tbl_Item_Inventory.ItemName = inventory.ItemName;
                }
            }
            catch (Exception ex)
            {
               
                throw;
                
            }


           // return await Task.FromResult(new Inventory());
        }

        public static async Task<Inventory> UpdateItem(Inventory inventory)
        {
         
            try
            {
                using (var entity = new ShopBridgeContext())
                {
                    tbl_Item_Inventory _tbl_Item_Inventory = new tbl_Item_Inventory()
                    {
                        ItemName = inventory.ItemName,
                        ItemDescription = inventory.ItemDescription,
                        ItemPrice = inventory.ItemPrice
                        
                    };

                    var obj = entity.tbl_Item_Inventories.Where(x => x.ItemId == inventory.ItemId).FirstOrDefault();
                    if(obj !=null)
                    {
                        obj.ItemName = inventory.ItemName;
                        obj.ItemDescription = inventory.ItemDescription;
                        obj.ItemPrice = inventory.ItemPrice;
                        
                       await entity.SaveChangesAsync();
                        inventory.ItemId = obj.ItemId;
                        return inventory;


                    }
                    else
                    {
                        return  await Task.FromResult(new Inventory());
                    }
                   
                    //_tbl_Item_Inventory.ItemName = inventory.ItemName;
                }
            }
            catch (Exception ex)
            {

                throw;
            }


           
        }

        public static Task<bool> DeleteItem(int ItemId)
        {
            var flag = false;
            try
            {
                using (var entity = new ShopBridgeContext())
                {
                 
                    var obj = entity.tbl_Item_Inventories.Where(x => x.ItemId == ItemId).FirstOrDefault();
                    if (obj != null)
                    {

                        entity.tbl_Item_Inventories.Remove(obj);
                        entity.SaveChangesAsync();
                        flag = true;
                    }

                    //_tbl_Item_Inventory.ItemName = inventory.ItemName;
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return  Task.FromResult(flag);
        }

        public static Task<bool> AnyItemExists(int ItemId)
        {
            var flag = false;
            try
            {
                using (var entity = new ShopBridgeContext())
                {


                    return Task.FromResult( entity.tbl_Item_Inventories.Any(x => x.ItemId == ItemId));
                        
                   

                    //_tbl_Item_Inventory.ItemName = inventory.ItemName;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static async Task<List<Inventory>> ListofItems()
        {
            List<Inventory> inventories = new List<Inventory>();
          
            try
            {
                using (var entity = new ShopBridgeContext())
                {
                    inventories = entity.tbl_Item_Inventories.Select(x=> new Inventory { 
                    ItemName=x.ItemName,
                    ItemDescription=x.ItemDescription,
                    ItemPrice=x.ItemPrice,
                    
                    ItemId=x.ItemId
                    
                    }).ToList();
                    
                
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return  await Task.FromResult(inventories);
        }
    }
}
