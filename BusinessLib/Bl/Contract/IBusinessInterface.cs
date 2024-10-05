

namespace BusinessLib.Bl.Contract
{
    public interface IBusinessInterface<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int elementId);
        bool Save(T element);
        bool Delete(int elementId);
    
    }

}
