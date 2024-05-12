using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<bool> ShowMenu;
    public static event Action<bool> ShowDiceRoller;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public int dices = 2;

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

        ThrowDiceButton.Click += OnThrowDice;
        BackToMenuButton.Click += OnShowMenu;
    }

    private void OnThrowDice()
    {
        ShowMenu?.Invoke(false);
        ShowDiceRoller?.Invoke(true);
    }

    private void OnShowMenu()
    {
        ShowMenu?.Invoke(true);
        ShowDiceRoller?.Invoke(false);
    }

    private void OnDestroy()
    {
        ThrowDiceButton.Click -= OnThrowDice;
        BackToMenuButton.Click -= OnShowMenu;
    }

}
