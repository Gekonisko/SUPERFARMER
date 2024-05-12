using System.Collections.Generic;

public struct Player
{
    public string name;
    public Dictionary<Animal, int> animals;

    public Player(string name)
    {
        this.name = name;
        animals = new Dictionary<Animal, int>
        {
            { Animal.Rabbit, 0 },
            { Animal.Sheep, 0 },
            { Animal.Pig, 0 },
            { Animal.Cow, 0 },
            { Animal.Horse, 0 },
            { Animal.SmallDog, 0 },
            { Animal.BigDog, 0 }
        };
    }
}