using System;
using UnityEngine;

public class ThrowDiceButton : MonoBehaviour
{
    public static event Action Click;

    public void OnClick() => Click?.Invoke();
}
