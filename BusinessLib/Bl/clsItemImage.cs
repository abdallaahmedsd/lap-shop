

using BusinessLib.Bl.Contract;

namespace BusinessLib
{
    public class clsItemImage : IBusinessInterface<TbItemImage>, ISpecialGetFeature<TbItemImage>
    {
        private readonly AppDbContext _appDbContext;
        public clsItemImage(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public IEnumerable<TbItemImage> GetAll()
        {
            try
            {


                return _appDbContext.TbItemImages.AsNoTracking();
            }
            catch (Exception ex)
            {

                return new List<TbItemImage>();
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"> Item id ,to get images for item </param>
        /// <returns></returns>
        public IEnumerable<TbItemImage> GetAllById(int id)

        {
            try
            {


                return _appDbContext.TbItemImages.AsNoTracking()
                    .Where(x=>x.ItemId==id);
            }
            catch (Exception ex)
            {

                return new List<TbItemImage>();
            }

        }
        public TbItemImage GetById(int elementId)
        {

            try
            {



                return _appDbContext.TbItemImages.SingleOrDefault(x => x.ImageId == elementId);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool Save(TbItemImage element)
        {


            try
            {


                if (element.ImageId == 0)
                {

                    _appDbContext.TbItemImages.Add(element);
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

                TbItemImage elementToDelete = GetById(elementId);
                _appDbContext.TbItemImages.Remove(elementToDelete);
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
