using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DiceRollerView : MonoBehaviour
{
    [SerializeField] private GameObject _dices;
    [SerializeField] private Button _nextButton;
    [Inject]
    private GameService gameService;

    private int _rollDiceCounter = 0;

    private void Awake()
    {
        gameService.ActiveGameCanvas += OnChangeGameCanvas;
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
        gameService.ActiveGameCanvas -= OnChangeGameCanvas;
        DiceView.RollDice -= OnRollDice;
    }

}
