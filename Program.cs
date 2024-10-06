// See https://aka.ms/new-console-template for more information

Goblin goblin1 = new Goblin("g1", 10, 50);
Ability bonk = new Ability("bonk", "attack", 5, 10);
goblin1.Abilities.Add(bonk);
Goblin goblin2 = (Goblin)goblin1.Clone();
goblin2.name = "g2";
Goblin goblin3 = (Goblin)goblin2.Clone();
goblin3.name = "g3";
Hero hero1 = new Hero("Percival", 12, 100, 5);
Ability swordSlash = new Ability("sword slash", "attack", 6, 12);
hero1.Abilities.Add(swordSlash);
Ability spotlessWater = new Ability("spotless water", "heal", 30, 50);
hero1.Abilities.Add(spotlessWater);
Ability finalSlash = new Ability("final slash", "special attack", 20, 30);
hero1.Abilities.Add(finalSlash);

List<Goblin> goblins= new List<Goblin>();
goblins.Add(goblin1);
goblins.Add(goblin2);
goblins.Add(goblin3);
while (goblins.Count != 0)
{
    Console.WriteLine($"There are {goblins.Count} enemies now. ");
    List<Goblin> defeatedGoblins = new List<Goblin>();
    foreach (Goblin tempGoblin in goblins)
    {
        int turn = 0;
        while(tempGoblin.healthPoints > 0)
        {
            
            turn++;
            if (turn % 2 != 0)
            {
                Console.WriteLine($"You are gonna fight versus {tempGoblin.name}");
                Console.WriteLine($"What are you gonna do {hero1.heroName}? \n1. Attack\t2. Heal\t3. Special Attack \n4. Enemy details \nLife points remaining: {hero1.healthPoints} \tCurrent Manna: {hero1.manna}");
                int decision = int.Parse(Console.ReadLine());
                switch (decision)
                {
                    case 1:
                        tempGoblin.abilityImpact(swordSlash.cast());
                        hero1.cooldown(swordSlash);
                        break;
                    case 2:
                        if (hero1.manna > 50)
                        {
                            hero1.abilityImpact(spotlessWater.cast());
                            hero1.cooldown(spotlessWater);
                        }
                        break;
                    case 3:
                        if (hero1.manna == 100)
                        {
                            tempGoblin.abilityImpact(finalSlash.cast());
                            hero1.cooldown(finalSlash);
                        }
                        break;
                    case 4:
                        tempGoblin.description();
                        break;
                    default:
                        Console.WriteLine("Make no mistake!");
                        break;
                }
                Console.WriteLine(turn);
            } 
            else
            {
                hero1.abilityImpact(bonk.cast());
                Console.WriteLine(turn);
            }
            if (hero1.healthPoints < 1)
            {
                hero1.die();
                break;
            }
            
        }
        tempGoblin.healthPoints = 0;
        Console.WriteLine($"{tempGoblin.name} has fallen!");
        defeatedGoblins.Add(tempGoblin);
        continue;
    }
    foreach (Goblin fallenGoblin in defeatedGoblins)
    {
        goblins.Remove(fallenGoblin);
    }    
}
Console.WriteLine($"You have achieved the victory {hero1.heroName}!");