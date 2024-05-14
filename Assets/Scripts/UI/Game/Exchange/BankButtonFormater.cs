using Exchange;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BankButtonFormater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        ExchangerButton.Click += OnClickExchangerButton;
    }

    private void OnClickExchangerButton(Exchanger exchanger)
    {
        text.color = exchanger == Exchanger.Bank ? Color.black : Color.white;
    }

    private void OnDestroy()
    {
        ExchangerButton.Click -= OnClickExchangerButton;
    }
}