﻿using System;
using System.ComponentModel.DataAnnotations;

public class TypeEdit
{
	[Required]
	public int Id { get; set; }
	[Required]
	public string Name { get; set; }

	public TypeEdit()
	{
	}
}

