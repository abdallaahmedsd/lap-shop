

namespace BusinessLib
{
	public class clsHardDisk:IBusinessInterface<TbHardDisk>
    {
        private readonly AppDbContext _appDbContext;
        public clsHardDisk(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public IEnumerable<TbHardDisk> GetAll()
        {
            try
            {

              
                    return _appDbContext.TbHardDisks.AsNoTracking().OrderBy(x => x.HardDiskName);
            }
            catch (Exception ex)
            {

                return new List<TbHardDisk>();
            }

        }
        public TbHardDisk GetById(int elementId)
        {

            try
            {


            
                    return _appDbContext.TbHardDisks.SingleOrDefault(x => x.HardDiskId == elementId);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool Save(TbHardDisk element)
        {

            
                try
                {


                    if (element.HardDiskId == 0)
                    {

                        _appDbContext.TbHardDisks.Add(element);
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

                    TbHardDisk elementToDelete = GetById(elementId);
                    _appDbContext.TbHardDisks.Remove(elementToDelete);
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
