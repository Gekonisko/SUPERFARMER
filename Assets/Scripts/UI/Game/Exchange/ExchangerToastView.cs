using TMPro;
using UnityEngine;
using Zenject;

public class ExchangerToastView : MonoBehaviour
{
    [SerializeField] private GameObject closeButton, acceptButton;
    [SerializeField] private TextMeshProUGUI playerMulti, exchangerMulti;
    [SerializeField] private TextMeshProUGUI text;

    [Inject]
    private ExchangeService exchangeService;

    private void OnEnable()
    {
        var playerMultiplier = exchangeService.GetPlayerMultiplier();
        var exchangerMultiplier = exchangeService.GetExchangerMultiplier();

        playerMulti.text = playerMultiplier.ToString();
        exchangerMulti.text = exchangerMultiplier.ToString();

        if (playerMultiplier < exchangerMultiplier)
        {
            acceptButton.SetActive(false);
            text.text = "Niewłaściwa Wymiana";
            text.color = Color.red;
        }
        else if (playerMultiplier == exchangerMultiplier)
        {
            acceptButton.SetActive(true);
            text.text = "Dobra Wymiana";
            text.color = Color.green;
        }
        else
        {
            acceptButton.SetActive(true);
            text.text = "Niekorzystna Wymiana";
            text.color = Color.blue;
        }
    }


}