using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollerView : MonoBehaviour
{
    [SerializeField] private GameObject _dices;
    [SerializeField] private Button _nextButton;

    private int _rollDiceCounter = 0;

    private void Awake()
    {
        GameManager.ShowDiceRoller += OnShowDiceRoller;
        DiceView.RollDice += OnRollDice;
    }

    private void OnShowDiceRoller(bool isActive)
    {
        _dices.SetActive(isActive);
        _nextButton.interactable = false;
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
        GameManager.ShowDiceRoller -= OnShowDiceRoller;
        DiceView.RollDice -= OnRollDice;
    }

}
