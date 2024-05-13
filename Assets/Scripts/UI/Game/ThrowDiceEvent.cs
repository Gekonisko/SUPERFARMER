using System;
using UnityEngine;

public class ThrowDiceEvent : MonoBehaviour
{
    public static event Action Event;

    public static void Invoke() => Event?.Invoke();
}
