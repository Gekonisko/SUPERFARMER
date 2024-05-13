
using System;
using System.Collections.Generic;
using Zenject;

public class GameService : IInitializable, IDisposable
{
    public event Action<GameCanvases> ActiveGameCanvas;
    public readonly int MAX_Players = 4;
    public readonly int MIN_Players = 2;

    private List<Player> players = new List<Player>();

    public int dices = 2;

    public void Initialize()
    {
        ThrowDiceMenuButton.Click += OnThrowDice;
        BackToMenuButton.Click += OnShowMenu;
        ExchangeMenuButton.Click += OnExchange;
    }

    public void AddPlayer(string name) => players.Add(new Player(name));

    private void OnThrowDice() => ActiveGameCanvas?.Invoke(GameCanvases.DiceRoller);

    private void OnShowMenu() => ActiveGameCanvas?.Invoke(GameCanvases.Menu);

    private void OnExchange() => ActiveGameCanvas?.Invoke(GameCanvases.Exchange);

    public void Dispose()
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
