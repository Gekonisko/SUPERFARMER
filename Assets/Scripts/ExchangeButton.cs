using System;
using UnityEngine;

public class ExchangeButton : MonoBehaviour
{
    public static event Action Click;

    public void OnClick() => Click?.Invoke();
}
