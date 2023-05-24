using System;
using System.ComponentModel.DataAnnotations;

public class PokemonCreate
{
	[Required]
	public string Name { get; set; }
	[Required]
	public int Hp { get; set; }
	[Required]
	public int TypeId { get; set; }
    [Required]
    public int Move1Id { get; set; }
    [Required]
    public int Move2Id { get; set; }
    [Required]
    public int Move3Id { get; set; }
    [Required]
    public int Move4Id { get; set; }


    public PokemonCreate()
	{
	}
}

