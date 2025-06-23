using WebCoreApi.Data;
using WebCoreApi.Repository.Interfaces;

namespace WebCoreApi.Services;

public class EquipmentService
{
    private readonly IEquipmentRepository _repo;

    public EquipmentService(IEquipmentRepository repo) {
        _repo = repo;
    }

    public Equipment GetEquipment(int id) {
        return _repo.GetById(id);
    }
    
    public void AddEquipment(Equipment equipment) {
        _repo.Add(equipment);
    }
}