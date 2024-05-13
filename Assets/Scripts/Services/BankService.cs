using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BankService : IInitializable, IDisposable
{
    public event Action<Animal> BankUpdate;

    private Dictionary<Animal, int> _backupAnimals = new Dictionary<Animal, int>()
    {
        {Animal.Rabbit, 60},
        {Animal.Sheep, 24},
        {Animal.Pig, 20},
        {Animal.Cow, 12},
        {Animal.Horse, 4},
        {Animal.SmallDog, 4},
        {Animal.BigDog, 2},
    };

    private Dictionary<Animal, int> _animals;

    public int GetAnimals(Animal type) => _animals[type];

    public void AddToBank(Animal type, int count)
    {
        _animals[type] += count;
        BankUpdate?.Invoke(type);
    }

    public void RemoveFromBank(Animal type, int count)
    {
        _animals[type] -= count;
        BankUpdate?.Invoke(type);
    }

    public void Reset() => _animals = new Dictionary<Animal, int>(_backupAnimals);

    public void Initialize()
    {
        _animals = new Dictionary<Animal, int>(_backupAnimals);
    }

    public void Dispose()
    {
    }
}