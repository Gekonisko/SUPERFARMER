using System;
using UnityEngine;

public class ExchangeButton : MonoBehaviour
{
    public static event Action<int, Animal, Animal> Click;

    [Header("exchange of")]
    [SerializeField] private int animalAmount;
    [SerializeField] private Animal animalIn;
    [Header("exchange for")]
    [SerializeField] private Animal animalOut;

    public void OnClick() => Click?.Invoke(animalAmount, animalIn, animalOut);
}