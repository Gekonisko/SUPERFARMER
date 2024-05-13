using System;
using UnityEngine;

public class ChangeSceneButton : MonoBehaviour
{
    public static event Action<string> Click;

    public static void OnClick(string name) => Click?.Invoke(name);
}
