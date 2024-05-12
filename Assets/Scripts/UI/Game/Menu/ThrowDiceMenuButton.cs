using System;
using UnityEngine;

public class ThrowDiceMenuButton : MonoBehaviour
{
    public static event Action Click;

    public void OnClick() => Click?.Invoke();
}
