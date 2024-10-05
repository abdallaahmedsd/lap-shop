


namespace BusinessLib
{
    public class clsItemType: IBusinessInterface<TbItemType>
    {
        private readonly AppDbContext _appDbContext;
        public clsItemType(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public IEnumerable<TbItemType> GetAll()
        {
            try
            {

               
                    return _appDbContext.TbItemTypes.AsNoTracking().OrderBy(x => x.ItemTypeName);
            }
            catch (Exception ex)
            {

                return new List<TbItemType>();
            }

        }
        public TbItemType GetById(int elementId)
        {

            try
            {


               
                    return _appDbContext.TbItemTypes.SingleOrDefault(x => x.ItemTypeId == elementId);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool Save(TbItemType Item)
        {

             try
                {


                    if (Item.ItemTypeId == 0)
                    {

                        Item.CreatedBy = "Musab";
                        Item.CreatedDate = DateTime.Now;
                        _appDbContext.TbItemTypes.Add(Item);
                        if (_appDbContext.SaveChanges() > 0)
                        {
                            return true;
                        }
                    }


                    else
                    {
                        _appDbContext.Entry(Item).State = EntityState.Modified;

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

                    TbItemType ItemToDelete = GetById(elementId);
                    _appDbContext.TbItemTypes.Remove(ItemToDelete);
                    if (_appDbContext.SaveChanges() > 0)
                        return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
           
            return false;

        }
    }
}
