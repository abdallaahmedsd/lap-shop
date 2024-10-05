
namespace BusinessLib
{
    public class clsCategory: IBusinessInterface<TbCategory>
    {
        private readonly AppDbContext _appDbContext;
        public clsCategory(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public IEnumerable<TbCategory> GetAll()
        {
            try
            {

                    return _appDbContext.TbCategories.AsNoTracking().OrderBy(x => x.CategoryName);
            }
            catch (Exception ex) {

                return new List<TbCategory>();
            }

        }
        public TbCategory GetById(int elementId)
        {
  
            try
            {

            
               
                    return _appDbContext.TbCategories.SingleOrDefault(x => x.CategoryId == elementId);
      
            }
          
            catch (Exception ex) {
                throw new Exception(ex.Message);
            
            }

        }
        public bool Save(TbCategory element)
        {

         
                try
                {


                    if (element.CategoryId == 0)
                    {

                        element.CreatedBy = "Musab";
                        element.CreatedDate = DateTime.Now;
                        _appDbContext.TbCategories.Add(element);
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

                    TbCategory categoryToDelete = GetById(elementId);
                    _appDbContext.TbCategories.Remove(categoryToDelete);
                    if(_appDbContext.SaveChanges()>0)
                        return true;

                }
                catch (Exception ex) {
                    return false;
                }
            return false;

        }

        public List<CategoryDto> GetAllDto()
        {

            {
                try
                {

                   return  _appDbContext.TbCategories
                       .AsNoTracking()
                       .Select(c => new CategoryDto
                       {
                           CategoryId = c.CategoryId,
                           CategoryName = c.CategoryName,
                       })
                        .OrderBy(x => x.CategoryName)
                        .ToList();
                }
                catch (Exception ex)
                {

                    return new List<CategoryDto>();
                }

            }
        }
    
        // DEPENCY INJECTION 
        //ISP Interface singleton speartion ..
    
    }

}
