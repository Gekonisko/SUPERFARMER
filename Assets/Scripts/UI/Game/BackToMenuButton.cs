using System;
using UnityEngine;

public class BackToMenuButton : MonoBehaviour
{
    public static event Action Click;

    public void OnClick() => Click?.Invoke();
}
