
using Domains.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace BusinessLib
{
    public class clsItem : IBusinessInterface<TbItem>, IItemViewService<VwItem>,IItemLight<TbItem>
    {
        private readonly AppDbContext _appDbContext;
        public clsItem(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public IEnumerable<TbItem> GetAll()
        {
            try
            {


                return _appDbContext.TbItems.AsNoTracking().Where(x => x.IsDeleted == false)
                    .OrderBy(x => x.ItemName);
            }
            catch (Exception ex)
            {

                return new List<TbItem>();
            }

        }
        public TbItem GetById(int elementId)
        {

            try
            {


                TbItem element = _appDbContext.TbItems.SingleOrDefault(x => x.ItemId == elementId && x.IsDeleted == false);

                return element;

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool Save(TbItem Item)
        {


            try
            {

                if (Item.ItemId == 0)
                {

                    Item.CreatedBy = "Musab";
                    Item.CreatedDate = DateTime.Now;
                    _appDbContext.TbItems.Add(Item);
                    if (_appDbContext.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
                else
                {

                    _appDbContext.Entry(Item).State = EntityState.Modified;
                    Item.UpdatedBy = "musab";
                    Item.UpdatedDate = DateTime.Now;
                    if (_appDbContext.SaveChanges() > 0)
                    {
                        return true;
                    }
                }



                return false;
            }
            catch (Exception ex) { return false; }

        }
        public bool Delete(int elementId)
        {

            try
            {

                TbItem ItemToDelete = GetById(elementId);
                _appDbContext.TbItems.Remove(ItemToDelete);
                if (_appDbContext.SaveChanges() > 0)
                    return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            return false;

        }
        public IEnumerable<VwItem> GetAllItemsData(int? categoryId, int? elementTypeId)
        {
            try
            {

                return _appDbContext.VwItems.AsNoTracking()
                       .Where(x =>
                           (x.CategoryId == categoryId||categoryId == null || categoryId == 0) 
                           &&
                           (x.ItemTypeId == elementTypeId || elementTypeId == null || elementTypeId == 0)
                            );

            }
            catch (Exception ex)
            {

                return new List<VwItem>();
            }
        }
        public List<VwItem> GetRecommendItems(int count=10)
        {
            try
            {

                return _appDbContext.VwItems
                    .AsNoTracking()
                    .Skip(60)
                    .Take(count)
                    .ToList();

            }
            catch (Exception ex)
            {

                return new List<VwItem>();
            }
        }
        public List<VwItem> GetSpecialOfferItems(int count=18)
        {
            try
            {

                return _appDbContext.VwItems
                    .AsNoTracking()
                   .Skip(20).Take(count)
                    .ToList();

            }
            catch (Exception ex)
            {

                return new List<VwItem>();
            }
        }
        public List<VwItem> GetNewItems(int count=10)
        {
            try
            {

                return _appDbContext.VwItems
                    .AsNoTracking().OrderByDescending(x=>x.CreatedDate )
                    .Take(count)
                    .ToList();

            }
            catch (Exception ex)
            {

                return new List<VwItem>();
            }
        }
        public List<VwItem> GetFreeDeliveryItems(int count=10)
        {
            try
            {
                return _appDbContext.VwItems
                    .AsNoTracking()
                   .Skip(140) .Take(count)
                    .ToList();

            }
            catch (Exception ex)
            {

                return new List<VwItem>();
            }
        }
        public List<VwItem> GetRelatedItems(decimal itemSalesPrice,int count=6)
        {
            try
            {
                // Define the price range: from 200 units below to 200 units above the current item price
                decimal lowerBound = itemSalesPrice - 300;
                decimal upperBound = itemSalesPrice + 300;

                // Query for items within the defined price range
                return _appDbContext.VwItems
                    .AsNoTracking()
                    .Where(i => i.PurchasePrice >= lowerBound && i.PurchasePrice <= upperBound).Take(count)
                    .ToList();
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "Error retrieving related items");

                // Return an empty list if an error occurs
                return new List<VwItem>();
            }
        }

        public VwItem GetItemViewById(int entityId)

        {
            try
            {

                return _appDbContext.VwItems.AsNoTracking()
                       .Where(x => x.ItemId == entityId).FirstOrDefault();
                
            }
            catch (Exception ex)
            {

                return new VwItem();
            }
        }

        public IQueryable<TbItem> LightData(int page=1,int pageSize=4)
        {
            try
            {
                var result= _appDbContext.TbItems
                    .AsNoTracking().Skip((page-1)*pageSize).Take(pageSize).AsQueryable();
                return result;

            }
            catch (Exception ex)
            {

                return new List<TbItem>().AsQueryable();
            }
        }

     
    }

}
