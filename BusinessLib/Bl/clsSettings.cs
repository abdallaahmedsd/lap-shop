
namespace BusinessLib
{
    public class clsSettings : IBusinessInterface<TbSettings>
    {
        private readonly AppDbContext _appDbContext;
        public clsSettings(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public IEnumerable<TbSettings> GetAll()
        {
            try
            {


                return _appDbContext.TbSettings.AsNoTracking().OrderBy(x => x.Id);
            }
            catch (Exception ex)
            {

                return new List<TbSettings>();
            }

        }
        public TbSettings GetById(int elementId)
        {

            try
            {


                return _appDbContext.TbSettings.SingleOrDefault(x => x.Id == elementId);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool Save(TbSettings element)
        {


            try
            {


                if (element.Id == 0)
                {

                    _appDbContext.TbSettings.Add(element);
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

                TbSettings elementToDelete = GetById(elementId);
                _appDbContext.TbSettings.Remove(elementToDelete);
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
