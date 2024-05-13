using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FarmManager : MonoBehaviour
{
    public static event Action<Animal, int> FarmUpdate;
    private Dictionary<Animal, int> _animals = new();

    private int _rollDiceCount = 0;
    private Animal _diceI, _diceII;
    [Inject]
    private GameService gameService;

    private void InitAnimals()
    {
        _animals.Add(Animal.Rabbit, 0);
        _animals.Add(Animal.Sheep, 0);
        _animals.Add(Animal.Pig, 0);
        _animals.Add(Animal.Cow, 0);
        _animals.Add(Animal.Horse, 0);
        _animals.Add(Animal.SmallDog, 0);
        _animals.Add(Animal.BigDog, 0);
    }

    private void Awake()
    {
        InitAnimals();
        DiceView.RollDice += OnRollDice;
        ExchangeButton.Click += OnExchange;
    }

    private void OnExchange(int amount, Animal animalIn, Animal animalOut)
    {
        if (_animals[animalIn] >= amount)
        {
            _animals[animalIn] -= amount;
            FarmUpdate(animalIn, _animals[animalIn]);

            _animals[animalOut] += 1;
            FarmUpdate(animalOut, _animals[animalOut]);
        }
    }

    private void OnRollDice(Animal animal)
    {
        _rollDiceCount++;

        if (_rollDiceCount == 1)
            _diceI = animal;

        if (_rollDiceCount == gameService.dices)
        {
            _diceII = animal;
            _rollDiceCount = 0;

            var diceIAnimals = 0;
            var diceIIAnimals = 0;

            if (_animals.ContainsKey(_diceI))
                diceIAnimals = _animals[_diceI] + (int)Mathf.Floor((_animals[_diceI] + 1) / 2);
            if (_animals.ContainsKey(_diceII))
            {
                if (_animals.ContainsKey(_diceI) && _diceI == _diceII)
                {
                    diceIAnimals = _animals[_diceI] + (int)Mathf.Floor((_animals[_diceI] + 2) / 2);
                    diceIIAnimals = _animals[_diceII] + (int)Mathf.Floor((_animals[_diceII] + 2) / 2);
                }
                else
                {
                    diceIIAnimals = _animals[_diceII] + (int)Mathf.Floor((_animals[_diceII] + 1) / 2);
                }
            }
            if (diceIAnimals > 0)
            {
                _animals[_diceI] = diceIAnimals;
                FarmUpdate?.Invoke(_diceI, diceIAnimals);
            }
            if (diceIIAnimals > 0)
            {
                _animals[_diceII] = diceIIAnimals;
                FarmUpdate?.Invoke(_diceII, diceIIAnimals);
            }

            CheckForPredator(_diceI);
            CheckForPredator(_diceII);
        }
    }

    private void CheckForPredator(Animal dice)
    {
        if (dice == Animal.Fox)
            Fox();
        else if (dice == Animal.Wolf)
            Wolf();
    }

    private void Fox()
    {
        if (_animals[Animal.SmallDog] > 0)
        {
            _animals[Animal.SmallDog] -= 1;
            FarmUpdate?.Invoke(Animal.SmallDog, _animals[Animal.SmallDog]);
        }
        else
        {
            _animals[Animal.Rabbit] = 1;
            FarmUpdate?.Invoke(Animal.Rabbit, _animals[Animal.Rabbit]);
        }
    }

    private void Wolf()
    {
        if (_animals[Animal.BigDog] > 0)
        {
            _animals[Animal.BigDog] -= 1;
            FarmUpdate?.Invoke(Animal.BigDog, _animals[Animal.BigDog]);
        }
        else
        {
            _animals[Animal.Sheep] = 0;
            FarmUpdate?.Invoke(Animal.Sheep, _animals[Animal.Sheep]);
            _animals[Animal.Pig] = 0;
            FarmUpdate?.Invoke(Animal.Pig, _animals[Animal.Pig]);
            _animals[Animal.Cow] = 0;
            FarmUpdate?.Invoke(Animal.Cow, _animals[Animal.Cow]);
        }
    }

    private void OnDestroy()
    {
        DiceView.RollDice -= OnRollDice;
        ExchangeButton.Click -= OnExchange;
    }

}
