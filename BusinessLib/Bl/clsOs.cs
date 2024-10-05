
namespace BusinessLib
{
    public class clsOs:IBusinessInterface<TbOs>
    {
        private readonly AppDbContext _appDbContext;
        public clsOs(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public IEnumerable<TbOs> GetAll()
        {
            try
            {

               
                    return _appDbContext.TbOs.AsNoTracking().OrderBy(x => x.OsName);
            }
            catch (Exception ex)
            {

                return new List<TbOs>();
            }

        }
        public TbOs GetById(int elementId)
        {

            try
            {


                    return _appDbContext.TbOs.SingleOrDefault(x => x.OsId == elementId);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool Save(TbOs element)
        {

      
                try
                {


                    if (element.OsId == 0)
                    {

                        element.CreatedBy = "Musab";
                        element.CreatedDate = DateTime.Now;
                        _appDbContext.TbOs.Add(element);
                        if (_appDbContext.SaveChanges() > 0)
                        {
                            return true;
                        }
                    }


                    else
                    {
                        _appDbContext.Entry(element).State = EntityState.Modified;

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

                    TbOs elementToDelete = GetById(elementId);
                    _appDbContext.TbOs.Remove(elementToDelete);
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
