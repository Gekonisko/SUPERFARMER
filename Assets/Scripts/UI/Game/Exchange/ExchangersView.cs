using System.Linq;
using UnityEngine;
using Zenject;

public class ExchangersView : MonoBehaviour
{
    [SerializeField] private GameObject[] playerButtons;
    [Inject]
    private GameService gameService;

    private void Awake()
    {
        Menu.ExchangeButton.Click += OnMenuExchangeButton;
    }

    private void OnMenuExchangeButton()
    {
        int i = 0;
        playerButtons.ToList().ForEach(x => x.gameObject.SetActive(i++ < gameService.players.Count));

        playerButtons[gameService.PlayerTurn].SetActive(false);
    }

    private void OnDestroy()
    {
        Menu.ExchangeButton.Click -= OnMenuExchangeButton;
    }
}