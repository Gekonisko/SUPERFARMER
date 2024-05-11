using System;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public static event Action Click;

    public void OnClick() => Click?.Invoke();
}
