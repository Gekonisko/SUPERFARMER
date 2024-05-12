using System;
using UnityEngine;

public class AddPlayer : MonoBehaviour
{
    public static event Action Click;

    public void OnClick() => Click?.Invoke();
}