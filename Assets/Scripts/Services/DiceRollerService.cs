using System;
using UnityEngine;

public class DiceRollerService
{
    public event Action<Animal, Animal> DiceRoll;
    public readonly float ROLL_TIME = 0.3f;
    public readonly float ROLL_TIME_INCREMENT = 0.05f;

    [SerializeField]
    public readonly Animal[] DiceI = new Animal[] { Animal.Rabbit, Animal.Rabbit, Animal.Rabbit, Animal.Rabbit,
        Animal.Rabbit, Animal.Rabbit, Animal.Sheep, Animal.Sheep, Animal.Sheep, Animal.Pig, Animal.Horse,
        Animal.Wolf };

    [SerializeField]
    public readonly Animal[] DiceII = new Animal[] { Animal.Rabbit, Animal.Rabbit, Animal.Rabbit, Animal.Rabbit,
        Animal.Rabbit, Animal.Rabbit, Animal.Sheep, Animal.Sheep, Animal.Pig, Animal.Pig, Animal.Cow, Animal.Fox };

    public (Animal, Animal) RollDices()
    {
        var diceI = DiceI[UnityEngine.Random.Range(0, DiceI.Length)];
        var diceII = DiceII[UnityEngine.Random.Range(0, DiceII.Length)];
        DiceRoll?.Invoke(diceI, diceII);

        return (diceI, diceII);
    }
}