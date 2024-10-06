public class Goblin : Enemy 
{
    public Goblin(string name, int level, int healthPoints) : base(name, level, healthPoints) 
    {
        Abilities = new List<Ability>();
    }

    public override object Clone()
    {
        Goblin goblinClone = (Goblin)this.MemberwiseClone();
        goblinClone.Abilities = new List<Ability>();
        foreach (var ability in this.Abilities) 
        {
            goblinClone.Abilities.Add((Ability)ability.Clone());
        }
        return goblinClone;
    }
}