using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRollerView : MonoBehaviour
{
    [SerializeField] private GameObject _dices;

    private void Awake()
    {
        GameManager.ShowDiceRoller += OnShowDiceRoller;
    }

    private void OnShowDiceRoller(bool isActive)
    {
        _dices.SetActive(isActive);
    }

    private void OnDestroy()
    {
        GameManager.ShowDiceRoller -= OnShowDiceRoller;
    }

}
