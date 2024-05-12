using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<GameCanvases> ActiveGameCanvas;
    public static readonly int MAX_Players = 4;
    public static readonly int MIN_Players = 2;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    private List<Player> players = new List<Player>();

    public int dices = 2;
    public int playersNumber = 2;

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

    public void AddPlayer(string name) => players.Add(new Player(name));

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
    Exchange,
    DefinePlayers
}
