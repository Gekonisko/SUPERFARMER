using TMPro;
using UnityEngine;
using Zenject;

public class ExchangerNameView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    [Inject]
    private GameService gameService;

    private void Awake()
    {
        Exchange.ExchangerButton.Click += OnClickExchangerButton;
    }

    private void OnClickExchangerButton(Exchanger exchanger)
    {
        text.text = exchanger == Exchanger.Bank ? "Bank" : gameService.GetPlayer((int)exchanger).name;
    }

    private void OnDestroy()
    {
        Exchange.ExchangerButton.Click -= OnClickExchangerButton;

    }
}