using System;
using UnityEngine;
using Zenject;

public class FarmService : IInitializable, IDisposable
{
    [Inject]
    private DiceRollerService diceRoller;
    [Inject]
    private GameService gameService;
    [Inject]
    private BankService bankService;

    void IInitializable.Initialize()
    {
        diceRoller.DiceRoll += OnDiceRoll;
    }

    private void OnDiceRoll(Animal diceI, Animal diceII)
    {
        var player = gameService.GetPlayer(gameService.PlayerTurn);

        var diceIAnimals = 0;
        var diceIIAnimals = 0;

        if (player.animals.ContainsKey(diceI))
            diceIAnimals = (int)Mathf.Floor((player.animals[diceI] + 1) / 2);
        if (player.animals.ContainsKey(diceII))
        {
            if (player.animals.ContainsKey(diceI) && diceI == diceII)
            {
                diceIAnimals = (int)Mathf.Floor((player.animals[diceI] + 2) / 2);
                diceIIAnimals = (int)Mathf.Floor((player.animals[diceII] + 2) / 2);
            }
            else
            {
                diceIIAnimals = (int)Mathf.Floor((player.animals[diceII] + 1) / 2);
            }
        }
        if (diceIAnimals > 0)
            AddToPlayerFarm(diceI, diceIAnimals);
        if (diceIIAnimals > 0 && diceI != diceII)
            AddToPlayerFarm(diceII, diceIIAnimals);

        CheckForPredator(diceI, ref player);
        CheckForPredator(diceII, ref player);
    }

    private void AddToPlayerFarm(Animal type, int count)
    {
        var animals = bankService.GetAnimals(type) > count ? count : bankService.GetAnimals(type);

        gameService.AddToPlayerFarm(type, animals);
        bankService.RemoveFromBank(type, animals);
    }

    private void CheckForPredator(Animal dice, ref Player player)
    {
        if (dice == Animal.Fox)
            Fox(ref player);
        else if (dice == Animal.Wolf)
            Wolf(ref player);
    }

    private void Fox(ref Player player)
    {
        if (player.animals[Animal.SmallDog] > 0)
        {
            gameService.RemoveFromPlayerFarm(Animal.SmallDog, 1);
            bankService.AddToBank(Animal.SmallDog, 1);
        }
        else
        {
            bankService.AddToBank(Animal.Rabbit, player.animals[Animal.Rabbit] - 1);
            gameService.SetPlayerFarm(Animal.Rabbit, 1);
        }
    }

    private void Wolf(ref Player player)
    {
        if (player.animals[Animal.BigDog] > 0)
        {
            gameService.RemoveFromPlayerFarm(Animal.BigDog, 1);
            bankService.AddToBank(Animal.BigDog, 1);
        }
        else
        {
            bankService.AddToBank(Animal.Sheep, player.animals[Animal.Sheep]);
            gameService.SetPlayerFarm(Animal.Sheep, 0);
            bankService.AddToBank(Animal.Pig, player.animals[Animal.Pig]);
            gameService.SetPlayerFarm(Animal.Pig, 0);
            bankService.AddToBank(Animal.Cow, player.animals[Animal.Cow]);
            gameService.SetPlayerFarm(Animal.Cow, 0);
        }
    }

    public void Dispose()
    {
        diceRoller.DiceRoll -= OnDiceRoll;
    }
}