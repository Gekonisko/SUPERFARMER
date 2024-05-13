using System;
using UnityEngine;

namespace DefinePlayers
{
    public class PlayButton : MonoBehaviour
    {
        public static event Action Click;

        public void OnClick() => Click?.Invoke();
    }
}