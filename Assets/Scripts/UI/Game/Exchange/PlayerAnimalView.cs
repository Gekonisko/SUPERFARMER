using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Exchange
{
    public class PlayerAnimalView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private TMP_InputField input;
        [SerializeField] private Animal type;

        [Inject]
        private GameService gameService;
        [Inject]
        private ExchangeService exchangeService;


        private void Awake()
        {
            Menu.ExchangeButton.Click += OnClickMenuExchangeButton;
            Exchange.ExchangeButton.Click += OnClickExchangeButton;
            input.onValueChanged.AddListener(OnInputValueChanged);
        }

        private void OnClickExchangeButton() => UpdateView();

        private void OnInputValueChanged(string str)
        {
            if (str.Length == 0) return;

            if (int.TryParse(str, out int val))
            {
                if (val <= 0)
                {
                    input.text = "0";
                    exchangeService.SetExchangerOffer(type, 0);
                    return;
                }

                var animals = gameService.GetPlayer(gameService.PlayerTurn).animals[type];
                if (val > animals)
                {
                    val = animals;
                    input.text = val.ToString();
                }

                exchangeService.SetPlayerOffer(type, val);
            }
            else
            {
                exchangeService.SetExchangerOffer(type, 0);
                input.text = "0";
            }
        }

        private void OnClickMenuExchangeButton() => UpdateView();

        private void UpdateView()
        {
            text.text = gameService.GetPlayer(gameService.PlayerTurn).animals[type].ToString();
            input.text = "0";
        }

        private void OnDestroy()
        {
            Menu.ExchangeButton.Click -= OnClickMenuExchangeButton;
            input.onValueChanged.RemoveListener(OnInputValueChanged);

        }
    }
}