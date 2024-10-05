
namespace BusinessLib
{
    public class clsProcessor: IBusinessInterface<TbProcessor>
    {
        private readonly AppDbContext _appDbContext;
        public clsProcessor(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public IEnumerable<TbProcessor> GetAll()
        {
            try
            {

                
                    return _appDbContext.TbProcessors.AsNoTracking().OrderBy(x => x.ProcessorName);
            }
            catch (Exception ex)
            {

                return new List<TbProcessor>();
            }

        }
        public TbProcessor GetById(int elementId)
        {

            try
            {


              
                    return _appDbContext.TbProcessors.SingleOrDefault(x => x.ProcessorId == elementId);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool Save(TbProcessor element)
        {

                try
                {


                    if (element.ProcessorId == 0)
                    {

                        _appDbContext.TbProcessors.Add(element);
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

                    TbProcessor elementToDelete = GetById(elementId);
                    _appDbContext.TbProcessors.Remove(elementToDelete);
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
