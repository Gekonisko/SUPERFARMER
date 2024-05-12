using UnityEngine;
using UnityEngine.UI;

public class DiceRollerView : MonoBehaviour
{
    [SerializeField] private GameObject _dices;
    [SerializeField] private Button _nextButton;

    private int _rollDiceCounter = 0;

    private void Awake()
    {
        GameManager.ActiveGameCanvas += OnChangeGameCanvas;
        DiceView.RollDice += OnRollDice;
    }

    private void OnChangeGameCanvas(GameCanvases canvas)
    {
        if (canvas == GameCanvases.DiceRoller)
        {
            _dices.SetActive(true);
            _nextButton.interactable = false;
        }
        else
        {
            _dices.SetActive(false);
        }

    }

    private void OnRollDice(Animal animal)
    {
        _rollDiceCounter += 1;
        if (_rollDiceCounter == 2)
        {
            _rollDiceCounter = 0;
            _nextButton.interactable = true;
        }
    }

    private void OnDestroy()
    {
        GameManager.ActiveGameCanvas -= OnChangeGameCanvas;
        DiceView.RollDice -= OnRollDice;
    }

}
