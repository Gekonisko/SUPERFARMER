using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class PlayButton : MonoBehaviour
    {
        public static event Action Click;

        public void OnClick()
        {
            Click?.Invoke();
        }
    }
}

