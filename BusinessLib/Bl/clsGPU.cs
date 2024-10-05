namespace BusinessLib
{
    public class clsGPU: IBusinessInterface<TbGPU>
    {
        private readonly AppDbContext _appDbContext;
        public clsGPU(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public IEnumerable<TbGPU> GetAll()
        {
            try
            {

                    return _appDbContext.TbGPUs.AsNoTracking().OrderBy(x => x.GPUName);
            }
            catch (Exception ex)
            {

                return new List<TbGPU>();
            }

        }
        public TbGPU GetById(int elementId)
        {

            try
            {


              
                    return _appDbContext.TbGPUs.SingleOrDefault(x => x.GPUId == elementId);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool Save(TbGPU element)
        {

                try
                {


                    if (element.GPUId == 0)
                    {

                        _appDbContext.TbGPUs.Add(element);
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

                    TbGPU ItemToDelete = GetById(elementId);
                    _appDbContext.TbGPUs.Remove(ItemToDelete);
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
