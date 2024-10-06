public class Ability : ICloneable {
    public string name { get; set; }
    public string type {get; set;}
    public int minLPChanged { get; set; }
    public int maxLPChanged { get; set; }
    public int lifePointsChanged { get; set; }

    public Ability(string name, string type, int minLPChanged, int maxLPChanged) {
        this.name = name;
        this.type = type;
        this.minLPChanged = minLPChanged;
        this.maxLPChanged = maxLPChanged;
    }
    Random rnd = new Random();

    public int cast() {
        if (type == "heal") {
            lifePointsChanged = rnd.Next(minLPChanged, maxLPChanged);
        } else if (type == "attack") {
            lifePointsChanged = rnd.Next(-maxLPChanged, -minLPChanged);
        } else if (type == "special attack") {
            lifePointsChanged = rnd.Next(-maxLPChanged, -minLPChanged);
        }
        return lifePointsChanged;
    }

    public void showAbility() {
        Console.WriteLine($"Name: {name} \nType: {type}");
        if (type == "heal") {
            Console.WriteLine($"Life points that can be recovered: {minLPChanged} to {maxLPChanged}");
        } else if (type == "attack" || type == "special attack") {
            Console.WriteLine($"Damage that can be dealed: {minLPChanged} to {maxLPChanged}");
        }
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }    
}