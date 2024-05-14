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
            ExchangeButton.Click += OnClickExchangeButton;
            input.onValueChanged.AddListener(OnInputValueChanged);
        }

        private void OnInputValueChanged(string str)
        {
            if (int.TryParse(str, out int val))
            {
                if (val <= 0) return;

                exchangeService.SetPlayerOffer(type, val);
            }
            else
            {
                exchangeService.SetExchangerOffer(type, 0);
            }
        }

        private void OnClickExchangeButton() => UpdateView();

        private void UpdateView()
        {
            text.text = gameService.GetPlayer(gameService.PlayerTurn).animals[type].ToString();
        }

        private void OnDestroy()
        {
            ExchangeButton.Click -= OnClickExchangeButton;
            input.onValueChanged.RemoveListener(OnInputValueChanged);

        }
    }
}