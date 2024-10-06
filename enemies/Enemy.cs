public abstract class Enemy : ICloneable 
{
    public string name { get; set; }
    public int level {get; set;}
    public int healthPoints { get; set; }
    public List<Ability> Abilities{ get; set; }

    public Enemy(string name, int level, int healthPoints) 
    {
        this.name = name;
        this.level = level;
        this.healthPoints = healthPoints;
        Abilities = new List<Ability>();
    }

    public void abilityImpact(int lifePointsChanged) 
    {
        healthPoints += lifePointsChanged;
        if (lifePointsChanged < 0)
        {
            Console.WriteLine($"{name} has taken {lifePointsChanged} damage!");
        }
        else
        {
            Console.WriteLine($"{name} has recoverd {lifePointsChanged} life points");
        }
    }

    public abstract object Clone();

    public void addAbility(Ability ability) 
    {
        Abilities.Add(ability);
    }

    public void description() 
    {
        Console.WriteLine($"Enemy: {name} \nLevel: {level} \nLife Points: {healthPoints} \nAbilities:");
        foreach (var ability in Abilities)
        {
            ability.showAbility();
            
        }
        Console.WriteLine();
    }
}