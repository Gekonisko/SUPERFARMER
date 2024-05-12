using System;
using UnityEngine;

public class DeletePlayer : MonoBehaviour
{
    public static event Action Click;

    public void OnClick() => Click?.Invoke();
}