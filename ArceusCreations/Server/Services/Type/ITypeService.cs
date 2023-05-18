using System;
public interface ITypeService
{
    Task<bool> CreateTypeAsync(TypeCreate model);
    Task<IEnumerable<TypeListItem>> GetAllTypesAsync();
    Task<bool> UpdateTypeAsync(TypeEdit model);
    Task<bool> DeleteTypeAsync(int typeId);
    Task<TypeDetail> GetTypeById(int id);
}

