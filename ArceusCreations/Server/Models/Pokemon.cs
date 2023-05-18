using System;
public class Pokemon
{
	public int Id { get; set; }
	public string Name { get; set; }
	public int Hp { get; set; }
	public int OwnerId { get; set; }

	public int TypeId { get; set; }
	public virtual Type Type { get; set; }

	public int  Move1Id { get; set; }
	public virtual Move Move1 { get; set; }

    public int Move2Id { get; set; }
    public virtual Move Move2 { get; set; }

    public int Move3Id { get; set; }
    public virtual Move Move3 { get; set; }

    public int Move4Id { get; set; }
    public virtual Move Move4 { get; set; }

    public Pokemon()
	{
	}
}

