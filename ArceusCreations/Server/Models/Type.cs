using System;
using System.ComponentModel.DataAnnotations;

public class Type
{
	[Key]
	public int Id { get; set; }
	[Required]
	public string Name { get; set; }

	public Type()
	{
	}
}

