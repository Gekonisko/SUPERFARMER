using System;
using UnityEngine;

public class ExitMenuButton : MonoBehaviour
{
    public static event Action Click;

    public void OnClick() => Click?.Invoke();
}
