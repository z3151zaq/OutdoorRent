using WebCoreApi.Data;

namespace WebCoreApi.Repository.Interfaces;

public interface IEquipmentRepository {
    Equipment GetById(int id);
    IEnumerable<Equipment> GetAll();
    void Add(Equipment product);
    void Update(Equipment product);
    void Delete(int id);
}