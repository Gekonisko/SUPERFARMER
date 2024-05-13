using TMPro;
using UnityEngine;
using Zenject;

namespace Bank
{
    public class AnimalView : MonoBehaviour
    {
        [SerializeField] private Animal type;
        [SerializeField] private TextMeshProUGUI text;
        [Inject]
        private BankService _bankService;

        private void Awake()
        {
            _bankService.BankUpdate += OnBankUpdate;
        }

        private void Start()
        {
            text.text = _bankService.GetAnimals(type).ToString();
        }

        private void OnBankUpdate(Animal animal)
        {
            if (animal == type)
            {
                text.text = _bankService.GetAnimals(type).ToString();
            }
        }

        private void OnDestroy()
        {
            _bankService.BankUpdate -= OnBankUpdate;
        }
    }

}

