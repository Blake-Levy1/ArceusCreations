using System;
public interface IMoveService
{
    Task<bool> CreateMoveAsync(MoveCreate model);
    Task<IEnumerable<MoveListItem>> GetAllMovesAsync();
    Task<bool> UpdateMoveAsync(MoveEdit model);
    Task<bool> DeleteMoveAsync(int moveId);
    Task<MoveDetail> GetMoveByNameAsync(string moveName);
    Task<IEnumerable<MoveListItem>> GetMovesByTypeAsync(int typeId);
    Task<IEnumerable<MoveListItem>> GetMovesByDamageAsync(SearchMoveByDamage model);
    Task<MoveDetail> GetMoveById(int id);
}

