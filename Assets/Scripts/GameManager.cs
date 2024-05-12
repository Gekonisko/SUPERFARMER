using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<GameCanvases> ActiveGameCanvas;

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

        ThrowDiceMenuButton.Click += OnThrowDice;
        BackToMenuButton.Click += OnShowMenu;
        ExchangeMenuButton.Click += OnExchange;
    }

    private void OnThrowDice() => ActiveGameCanvas?.Invoke(GameCanvases.DiceRoller);

    private void OnShowMenu() => ActiveGameCanvas?.Invoke(GameCanvases.Menu);

    private void OnExchange() => ActiveGameCanvas?.Invoke(GameCanvases.Exchange);

    private void OnDestroy()
    {
        ThrowDiceMenuButton.Click -= OnThrowDice;
        BackToMenuButton.Click -= OnShowMenu;
        ExchangeMenuButton.Click -= OnExchange;
    }
}

public enum GameCanvases
{
    Menu,
    DiceRoller,
    Exchange
}
