using System;
using System.ComponentModel.DataAnnotations;

public class SearchMoveByDamage
{
	[Required]
	public int lowDamage { get; set; }
	[Required]
	public int highDamage { get; set; }
	public SearchMoveByDamage()
	{
	}
}

