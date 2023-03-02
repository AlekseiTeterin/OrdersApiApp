using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.GeneralService
{
    //DAO - data access object (интерфейс для работы с клиентом)
    public interface IDao<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T instance);
        Task<bool> Update(T instance);
        Task<bool> Delete(int id);
    }
}
