public class Orc : Enemy 
{
    public Orc(string name, int level, int healthPoints) : base(name, level, healthPoints) 
    {
        Abilities = new List<Ability>();
    }

    public override object Clone()
    {
        Orc orcClone = (Orc)this.MemberwiseClone();
        orcClone.Abilities = new List<Ability>();
        foreach (var ability in this.Abilities) 
        {
            orcClone.Abilities.Add((Ability)ability.Clone());
        }
        return orcClone;
    }
}