using System;
using System.ComponentModel.DataAnnotations;

public class PokemonCreate
{
	[Required]
	public string Name { get; set; }
	[Required]
	public int Hp { get; set; }
	public int TypeId { get; set; }
	public int Move1Id { get; set; }
    public int Move2Id { get; set; }
    public int Move3Id { get; set; }
    public int Move4Id { get; set; }


    public PokemonCreate()
	{
	}
}

