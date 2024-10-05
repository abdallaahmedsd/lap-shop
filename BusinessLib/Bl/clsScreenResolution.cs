
namespace BusinessLib
{
    public class clsScreenResolution: IBusinessInterface<TbScreenResolution>
    {
        private readonly AppDbContext _appDbContext;
        public clsScreenResolution(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public IEnumerable<TbScreenResolution> GetAll()
        {
            try
            {

                 return _appDbContext.TbScreenResolutions.AsNoTracking().OrderBy(x => x.ScreenResolutionName);
            }
            catch (Exception ex)
            {

                return new List<TbScreenResolution>();
            }

        }
        public TbScreenResolution GetById(int elementId)
        {

            try
            {


                  return _appDbContext.TbScreenResolutions.SingleOrDefault(x => x.ScreenResolutionId == elementId);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool Save(TbScreenResolution element)
        {

           
                try
                {


                    if (element.ScreenResolutionId == 0)
                    {

                        _appDbContext.TbScreenResolutions.Add(element);
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

                    TbScreenResolution elementToDelete = GetById(elementId);
                    _appDbContext.TbScreenResolutions.Remove(elementToDelete);
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
