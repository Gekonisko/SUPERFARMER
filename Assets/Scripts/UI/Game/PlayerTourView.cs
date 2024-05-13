using TMPro;
using UnityEngine;
using Zenject;

public class PlayerTourView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Color[] playerColors;

    [Inject]
    private GameService _gameService;

    private void Awake()
    {
        _gameService.ChangePlayerTurn += OnChangeTurn;
    }

    private void Start()
    {
        var player = _gameService.GetPlayer(_gameService.PlayerTurn);
        text.text = player.name;
        text.color = playerColors[_gameService.PlayerTurn];
    }

    private void OnChangeTurn(int playerId)
    {
        var player = _gameService.GetPlayer(playerId);
        text.text = player.name;
        text.color = playerColors[playerId];
    }

    private void OnDestroy()
    {
        _gameService.ChangePlayerTurn -= OnChangeTurn;
    }
}