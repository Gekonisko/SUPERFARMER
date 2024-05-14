using TMPro;
using UnityEngine;
using Zenject;

public class ExchangerAnimalView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TMP_InputField input;
    [SerializeField] private Animal type;
    [SerializeField] private Exchanger exchanger;

    [Inject]
    private GameService gameService;
    [Inject]
    private BankService bankService;
    [Inject]
    private ExchangeService exchangeService;

    private void Awake()
    {
        Menu.ExchangeButton.Click += OnClickMenuExchangeButton;
        Exchange.ExchangerButton.Click += OnClickExchangerButton;
        Exchange.ExchangeButton.Click += OnClickExchangeButton;
        input.onValueChanged.AddListener(OnInputValueChanged);
    }

    private void OnClickExchangeButton() => UpdateView();

    private void OnInputValueChanged(string str)
    {
        if (int.TryParse(str, out int val))
        {
            if (val <= 0) return;

            exchangeService.SetExchangerOffer(type, val);
        }
        else
        {
            exchangeService.SetExchangerOffer(type, 0);
        }
    }

    private void OnClickExchangerButton(Exchanger exchanger)
    {
        this.exchanger = exchanger;
        UpdateView();
    }

    private void OnClickMenuExchangeButton() => UpdateView();

    private void UpdateView()
    {
        text.text = GetAnimalNumber().ToString();
    }

    private int GetAnimalNumber()
    {
        if (exchanger == Exchanger.Bank)
            return bankService.GetAnimals(type);
        return gameService.GetPlayer((int)exchanger).animals[type];
    }

    private void OnDestroy()
    {
        Menu.ExchangeButton.Click -= OnClickMenuExchangeButton;
        Exchange.ExchangerButton.Click -= OnClickExchangerButton;
        Exchange.ExchangeButton.Click -= OnClickExchangeButton;
        input.onValueChanged.RemoveListener(OnInputValueChanged);
    }
}