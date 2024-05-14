using System;
using UnityEngine;

namespace Menu
{
    public class EndTurnButton : MonoBehaviour
    {
        public static event Action Event;

        public static void Invoke() => Event?.Invoke();
    }
}
