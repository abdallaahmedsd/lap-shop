
namespace BusinessLib
{
    public class clsRAM:IBusinessInterface<TbRAM>
    {
        private readonly AppDbContext _appDbContext;
        public clsRAM(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public IEnumerable<TbRAM> GetAll()
        {
            try
            {

             
                    //Deceding fit 
                    return _appDbContext.TbRAMs.AsNoTracking().OrderBy(x => x.RAMSize);
            }
            catch (Exception ex)
            {

                return new List<TbRAM>();
            }

        }
        public TbRAM GetById(int elementId)
        {

            try
            {


                    return _appDbContext.TbRAMs.SingleOrDefault(x => x.RAMId == elementId);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool Save(TbRAM element)
        {

                try
                {


                    if (element.RAMId == 0)
                    {

                        _appDbContext.TbRAMs.Add(element);
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

                    TbRAM elementToDelete = GetById(elementId);
                    _appDbContext.TbRAMs.Remove(elementToDelete);
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
