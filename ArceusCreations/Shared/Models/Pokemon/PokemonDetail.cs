using System;
public class PokemonDetail
{
	public int Id { get; set; }
	public string Name { get; set; }
	public int Hp { get; set; }
	public int TypeId { get; set; }
	public string TypeName { get; set; }
	public int Move1Id { get; set; }
	public string MoveName1 { get; set; }
    public int Move2Id { get; set; }
    public string MoveName2 { get; set; }
    public int Move3Id { get; set; }
    public string MoveName3 { get; set; }
    public int Move4Id { get; set; }
    public string MoveName4 { get; set; }

    public PokemonDetail()
	{
	}
}

