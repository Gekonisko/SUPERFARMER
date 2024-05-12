using System;
using UnityEngine;

namespace Menu
{
    public class HowToPlayButton : MonoBehaviour
    {
        public static event Action Click;

        public void OnClick() => Click?.Invoke();
    }
}

