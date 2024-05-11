using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<bool> ShowMenu;
    public static event Action<bool> ShowDiceRoller;

    private void Awake()
    {
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
