using System;
using UnityEngine;

public class EndTurnEvent : MonoBehaviour
{
    public static event Action Event;

    public static void Invoke() => Event?.Invoke();
}