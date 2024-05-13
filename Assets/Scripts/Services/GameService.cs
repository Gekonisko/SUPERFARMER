
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Zenject;

public class GameService : IInitializable, IDisposable
{
    public event Action<GameCanvases> ActiveGameCanvas;
    public event Action<int, Animal> PlayerFarmUpdate;
    public event Action<int> ChangePlayerTurn;

    public readonly int MAX_Players = 4;
    public readonly int MIN_Players = 2;

    private int _playerTurn = 0;
    public int PlayerTurn => _playerTurn;

    [Inject]
    private BankService _bankService;

    public List<Player> players = new List<Player>();

    public int dices = 2;

    public void Initialize()
    {
        EndTurnEvent.Event += OnEndTour;
        ExchangeMenuButton.Click += OnExchange;
        ChangeSceneButton.Click += OnChangeSceneButton;

        if (SceneManager.GetActiveScene().name == GameScenes.Game.ToString())
        {
            players.Add(new Player("P1"));
            players.Add(new Player("P2"));
        }
    }

    public int GetPlayersCount() => players.Count;

    public void AddPlayer(string name) => players.Add(new Player(name));

    public Player GetPlayer(int number) => players[number];

    public void AddToPlayerFarm(Animal type, int count) => AddToPlayerFarm(_playerTurn, type, count);

    public void AddToPlayerFarm(int playerId, Animal type, int count)
    {
        players[playerId].animals[type] += count;
        PlayerFarmUpdate(playerId, type);
    }

    public void RemoveFromPlayerFarm(Animal type, int count) => RemoveFromPlayerFarm(_playerTurn, type, count);

    public void RemoveFromPlayerFarm(int playerId, Animal type, int count)
    {
        players[playerId].animals[type] -= count;
        PlayerFarmUpdate(playerId, type);
    }

    public void SetPlayerFarm(Animal type, int count) => SetPlayerFarm(_playerTurn, type, count);

    public void SetPlayerFarm(int playerId, Animal type, int count)
    {
        players[playerId].animals[type] = count;
        PlayerFarmUpdate(playerId, type);
    }

    private void OnEndTour()
    {
        _playerTurn = (_playerTurn + 1) % players.Count;
        ChangePlayerTurn?.Invoke(_playerTurn);
    }

    private void OnExchange() => ActiveGameCanvas?.Invoke(GameCanvases.Exchange);

    private void OnChangeSceneButton(string name)
    {
        if (name == GameScenes.Game.ToString())
        {
            _bankService.Reset();
        }
        if (name == GameScenes.Menu.ToString())
        {
            players.Clear();
        }
        SceneManager.LoadScene(name);
    }

    public void Dispose()
    {
        ExchangeMenuButton.Click -= OnExchange;
        ChangeSceneButton.Click -= OnChangeSceneButton;
        EndTurnEvent.Event -= OnEndTour;
    }
}

public enum GameScenes
{
    Menu,
    Game
}

public enum GameCanvases
{
    Menu,
    DiceRoller,
    Exchange,
    DefinePlayers
}
