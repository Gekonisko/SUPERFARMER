using TMPro;
using UnityEngine;
using Zenject;

public class MultiplierView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private bool isMainPlayer;

    [Inject]
    private ExchangeService exchangeService;

    private void Awake()
    {
        exchangeService.ExchangeUpdate += OnExchangeUpdate;
    }

    private void OnExchangeUpdate()
    {
        text.text = isMainPlayer ?
            exchangeService.GetPlayerMultiplier().ToString() :
            exchangeService.GetExchangerMultiplier().ToString();
    }

    private void OnDestroy()
    {
        exchangeService.ExchangeUpdate -= OnExchangeUpdate;
    }
}