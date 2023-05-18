using System;
using System.ComponentModel.DataAnnotations;

public class TypeCreate
{
	[Required]
	public string Name { get; set; }

	public TypeCreate()
	{
	}
}

