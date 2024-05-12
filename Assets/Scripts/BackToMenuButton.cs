using System;
using UnityEngine;
using UnityEngine.UI;

public class BackToMenuButton : MonoBehaviour
{
    public static event Action Click;

    public void OnClick() => Click?.Invoke();
}
