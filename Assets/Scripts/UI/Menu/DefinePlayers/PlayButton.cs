using System;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public static event Action Click;

    public void OnClick() => Click?.Invoke();
}