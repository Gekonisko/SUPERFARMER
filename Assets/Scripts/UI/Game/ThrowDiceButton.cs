using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ThrowDiceButton : MonoBehaviour
{
    public static event Action Click;
    public static void Invoke() => Click?.Invoke();

    [SerializeField] private Button button;

    [Inject]
    private GameService gameService;

    private void Awake()
    {
        gameService.ChangePlayerTurn += OnChangePlayerTurn;
    }

    private void OnChangePlayerTurn(int playerId)
    {
        button.interactable = true;
    }

    private void OnDestroy()
    {
        gameService.ChangePlayerTurn -= OnChangePlayerTurn;
    }
}
