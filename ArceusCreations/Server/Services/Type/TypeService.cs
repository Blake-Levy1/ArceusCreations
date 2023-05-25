using System;
using Microsoft.EntityFrameworkCore;

public class TypeService : ITypeService
{
	private readonly ApplicationDbContext _context;

	public TypeService(ApplicationDbContext context)
	{
		_context = context;
	}

    public async Task<bool> CreateTypeAsync(TypeCreate model)
	{
		var typeEntity = new Type
		{
			Name = model.Name
		};
		_context.Types.Add(typeEntity);
		var numberOfChanges = await _context.SaveChangesAsync();
		return numberOfChanges == 1;
	}

    public async Task<IEnumerable<TypeListItem>> GetAllTypesAsync()
	{
		var typeQuery = _context.Types
			.Select(n => new TypeListItem
			{
				Id = n.Id,
				Name = n.Name
			});
		return await typeQuery.ToListAsync();
	}

    public async Task<bool> UpdateTypeAsync(TypeEdit model)
	{
		if (model == null)
		{
			return false;
		}
		var entity = await _context.Types.FindAsync(model.Id);
		entity.Name = model.Name;
		return await _context.SaveChangesAsync() == 1;
	}

    public async Task<bool> DeleteTypeAsync(int typeId)
	{
		var entity = await _context.Types.FindAsync(typeId);
		_context.Types.Remove(entity);
		return await _context.SaveChangesAsync() == 1;
	}

	public async Task<TypeDetail> GetTypeById(int id)
	{
		var typeEntity = await _context.Types
			.FirstOrDefaultAsync(n => n.Id == id);
		if (typeEntity == null)
		{
			return null;
		}

		var detail = new TypeDetail
		{
			Id = typeEntity.Id,
			Name = typeEntity.Name
		};

		return detail;
	}
}

