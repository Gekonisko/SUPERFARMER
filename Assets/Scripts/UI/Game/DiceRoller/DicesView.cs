using UnityEngine;

public class DicesView : MonoBehaviour
{
    [SerializeField] private DiceView _diceI, _diceII;

    private void OnEnable()
    {
        _diceI.Roll(DiceRoller.Instance.DiceI);
        _diceII.Roll(DiceRoller.Instance.DiceII);
    }
}
