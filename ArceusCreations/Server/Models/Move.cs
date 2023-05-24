using System;
using System.ComponentModel.DataAnnotations;

public class Move
{
	[Key]
	public int Id { get; set; }
	[Required]
	public string Name { get; set; }
	
	public int TypeId { get; set; }
	public virtual Type Type { get; set; }

	[Required]
	public int Damage { get; set; }
	[Required]
	public int PowerPoints { get; set; }

}

