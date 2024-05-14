using System;
using UnityEngine;
using UnityEngine.UI;

namespace Exchange
{
    public class ExchangerButton : MonoBehaviour
    {
        [SerializeField] private Exchanger type;
        [SerializeField] private bool isSelected;
        [SerializeField] private Image image;
        [SerializeField] private Color selectColor, deselectColor;

        public static event Action<Exchanger> Click;
        public void Invoke() => Click?.Invoke(type);

        private void Awake()
        {
            Click += OnClick;
        }

        private void OnClick(Exchanger type)
        {
            image.color = this.type == type ? selectColor : deselectColor;
        }

        private void OnEnable()
        {
            if (isSelected)
            {
                Click.Invoke(type);
            }
        }

        private void OnDestroy()
        {
            Click -= OnClick;
        }
    }
}