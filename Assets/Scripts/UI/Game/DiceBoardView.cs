using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DiceBoardView : MonoBehaviour
{
    [SerializeField] private Image[] _dices;
    [Inject]
    private DiceRollerService _diceRoller;

    private void Awake()
    {
        ThrowDiceEvent.Event += OnThrowDice;
    }

    private void OnThrowDice()
    {
        StartCoroutine(Roll());
    }

    IEnumerator Roll()
    {
        _dices[0].enabled = false;
        _dices[1].enabled = false;

        yield return new WaitForSeconds(0.5f);

        _dices[0].enabled = true;
        _dices[1].enabled = true;

        float time = 0;
        while (time < _diceRoller.ROLL_TIME)
        {
            var animalI = _diceRoller.DiceI[Random.Range(0, _diceRoller.DiceI.Length)];
            var animalII = _diceRoller.DiceII[Random.Range(0, _diceRoller.DiceII.Length)];

            var animalImage = Resources.Load<Sprite>(animalI.ToString());
            var animalIImage = Resources.Load<Sprite>(animalII.ToString());

            _dices[0].sprite = animalImage;
            _dices[1].sprite = animalIImage;

            yield return new WaitForSeconds(time);

            time += _diceRoller.ROLL_TIME_INCREMENT;
        }

        yield return new WaitForSeconds(0.5f);

        var result = _diceRoller.RollDices();
        _dices[0].sprite = Resources.Load<Sprite>(result.Item1.ToString());
        _dices[1].sprite = Resources.Load<Sprite>(result.Item2.ToString());
    }

    private void OnDestroy()
    {
        ThrowDiceEvent.Event -= OnThrowDice;
    }
}