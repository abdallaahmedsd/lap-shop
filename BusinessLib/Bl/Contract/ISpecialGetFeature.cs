

namespace BusinessLib.Bl.Contract
{
    public interface ISpecialGetFeature<T>
    {
        IEnumerable<T> GetAllById(int id );
      

    }
}
