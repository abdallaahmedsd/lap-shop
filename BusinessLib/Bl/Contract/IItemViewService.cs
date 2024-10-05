namespace BusinessLib.Bl.Contract
{
    public interface IItemViewService<T>
    {

         IEnumerable<T> GetAllItemsData(int? categoryId, int? elementTypeId);
         T GetItemViewById(int entityId);
        List<T> GetRecommendItems(int count = 10);
        List<T> GetSpecialOfferItems(int count = 18);
        List<T> GetNewItems(int count=10);
        List<T> GetFreeDeliveryItems(int count = 10);
        List<T> GetRelatedItems(decimal value,int count = 6);


    }
    public interface IItemLight<T>
    {
        IQueryable<T> LightData(int value1=1,int value2=4);

    }

}
