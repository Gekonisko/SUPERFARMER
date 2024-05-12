using System;
using UnityEngine;

namespace Menu
{
    public class ExitButton : MonoBehaviour
    {
        public static event Action Click;

        public void OnClick()
        {
            Click?.Invoke();
            Application.Quit();
        }
    }
}
