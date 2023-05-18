using System;
using System.ComponentModel.DataAnnotations;

public class MoveCreate
{
	[Required]
	public string Name { get; set; }
	[Required]
	public int TypeId { get; set; }
	[Required]
	public int Damage { get; set; }
	[Required]
	public int PowerPoints { get; set; }

	public MoveCreate()
	{
	}
}

