using System;
using Microsoft.EntityFrameworkCore;

public class MoveService : IMoveService
{
    private string _userId;
    private readonly ApplicationDbContext _context;

    public MoveService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateMoveAsync(MoveCreate model)
    {
        var moveEntity = new Move
        {
            Name = model.Name,
            TypeId = model.TypeId,
            Damage = model.Damage,
            PowerPoints = model.PowerPoints
        };
        _context.Moves.Add(moveEntity);
        var numberOfChanges = await _context.SaveChangesAsync();
        return numberOfChanges == 1;
    }
    public async Task<IEnumerable<MoveListItem>> GetAllMovesAsync()
    {
        var moveQuery = await _context.Moves
            .Select(n => new MoveListItem
            {
                Id = n.Id,
                Name = n.Name,
                TypeName = n.Type.Name,
                Damage = n.Damage
            }).ToListAsync();
        return moveQuery;
    }
    public async Task<bool> UpdateMoveAsync(MoveEdit model)
    {
        if (model == null)
        {
            return false;
        }
        
        var entity = await _context.Moves.FindAsync(model.Id);
        
        entity.Name = model.Name;
        entity.TypeId = model.TypeId;
        entity.Damage = model.Damage;
        entity.PowerPoints = model.PowerPoints;

        return await _context.SaveChangesAsync() == 1;
    }
    public async Task<bool> DeleteMoveAsync(int moveId)
    {
        var entity = await _context.Moves.FindAsync(moveId);
        _context.Moves.Remove(entity);
        return await _context.SaveChangesAsync() == 1;
    }
    public async Task<MoveDetail> GetMoveByNameAsync(string moveName)
    {
        var moveEntity = await _context.Moves
            .FirstOrDefaultAsync(n => n.Name.ToLower() == moveName.ToLower());
        if (moveEntity is null)
        {
            return null;
        }

        var detail = new MoveDetail
        {
            Id = moveEntity.Id,
            Name = moveEntity.Name,
            TypeId = moveEntity.TypeId,
            TypeName = moveEntity.Type.Name,
            Damage = moveEntity.Damage,
            PowerPoints = moveEntity.PowerPoints
        };
        return detail;
    }
    public async Task<IEnumerable<MoveListItem>> GetMovesByTypeAsync(int typeId)
    {
        var moveQuery = await _context.Moves
            .Where(n => n.TypeId == typeId)
            .Select(n => new MoveListItem
            {
                Id = n.Id,
                Name = n.Name,
                TypeName = n.Type.Name,
                Damage = n.Damage
            }).ToListAsync();
        return moveQuery;
    }
    public async Task<IEnumerable<MoveListItem>> GetMovesByDamageAsync(SearchMoveByDamage model)
    {
        var moveQuery = await _context.Moves
            .Where(n => n.Damage >= model.lowDamage && n.Damage <= model.highDamage)
            .Select(n => new MoveListItem
            {
                Id = n.Id,
                Name = n.Name,
                TypeName = n.Type.Name,
                Damage = n.Damage
            }).ToListAsync();
        return moveQuery;
    }

    public async Task<MoveDetail> GetMoveById(int Id)
    {
        var retrievedMove = await _context.Moves
            .Include(x => x.Type)
            .FirstOrDefaultAsync(x => x.Id == Id);
        if (retrievedMove is null)
        {
            return null;
        }
        MoveDetail moveEntity = new MoveDetail()
            {
                Id = retrievedMove.Id,
                Name = retrievedMove.Name,
                TypeId = retrievedMove.TypeId,
                TypeName = retrievedMove.Type.Name,
                Damage = retrievedMove.Damage,
                PowerPoints = retrievedMove.PowerPoints
            };

        return moveEntity;
    }
        //if (moveEntity == null)
        //{
        //    return null;
        //}

    public void SetUserId(string userId) => _userId = userId;
}

