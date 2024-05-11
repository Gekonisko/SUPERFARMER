using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    private static DiceRoller _instance;

    public static DiceRoller Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    [SerializeField]
    private Animal[] _diceI = new Animal[] { Animal.Rabbit, Animal.Rabbit, Animal.Rabbit, Animal.Rabbit,
        Animal.Rabbit, Animal.Rabbit, Animal.Sheep, Animal.Sheep, Animal.Sheep, Animal.Pig, Animal.Horse,
        Animal.Wolf };

    [SerializeField]
    private Animal[] _diceII = new Animal[] { Animal.Rabbit, Animal.Rabbit, Animal.Rabbit, Animal.Rabbit,
        Animal.Rabbit, Animal.Rabbit, Animal.Sheep, Animal.Sheep, Animal.Pig, Animal.Pig, Animal.Cow, Animal.Fox };

    public Animal[] DiceI => _diceI;

    public Animal[] DiceII => _diceII;

    public Animal RollDiceI() => _diceI[Random.Range(0, _diceI.Length)];

    public Animal RollDiceII() => _diceII[Random.Range(0, _diceII.Length)];

}
