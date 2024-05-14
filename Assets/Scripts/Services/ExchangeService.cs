using System;
using System.Collections.Generic;
using Zenject;

public class ExchangeService : IInitializable, IDisposable
{
    public event Action ExchangeUpdate;

    public readonly Dictionary<Animal, int> multiplier = new()
    {
        { Animal.Rabbit, 1 },
        { Animal.Sheep, 6 },
        { Animal.Pig, 12 },
        { Animal.Cow, 36 },
        { Animal.Horse, 72 },
        { Animal.SmallDog, 6 },
        { Animal.BigDog, 36 },
    };

    private Dictionary<Animal, int> playerOffer = new()
    {
        { Animal.Rabbit, 0 },
        { Animal.Sheep, 0 },
        { Animal.Pig, 0 },
        { Animal.Cow, 0 },
        { Animal.Horse, 0 },
        { Animal.SmallDog, 0 },
        { Animal.BigDog, 0 },
    };

    private Dictionary<Animal, int> exchangerOffer = new()
    {
        { Animal.Rabbit, 0 },
        { Animal.Sheep, 0 },
        { Animal.Pig, 0 },
        { Animal.Cow, 0 },
        { Animal.Horse, 0 },
        { Animal.SmallDog, 0 },
        { Animal.BigDog, 0 },
    };

    public void Initialize()
    {
        Menu.ExchangeButton.Click += OnClickMenuExchangeButton;
        ClearExchange();
        ExchangeUpdate?.Invoke();
    }

    public void ClearExchange()
    {
        List<Animal> keys = new List<Animal>(playerOffer.Keys);

        foreach (Animal key in keys)
        {
            playerOffer[key] = 0;
            exchangerOffer[key] = 0;
        }
    }

    public void SetPlayerOffer(Animal animal, int offer)
    {
        playerOffer[animal] = offer;
        ExchangeUpdate?.Invoke();
    }

    public void SetExchangerOffer(Animal animal, int offer)
    {
        exchangerOffer[animal] = offer;
        ExchangeUpdate?.Invoke();
    }

    public int GetPlayerMultiplier() => CalculateMultiplier(playerOffer);

    public int GetExchangerMultiplier() => CalculateMultiplier(exchangerOffer);

    public int CalculateMultiplier(Dictionary<Animal, int> animals)
    {
        var sum = 0;
        foreach (KeyValuePair<Animal, int> animal in animals)
        {
            sum += animal.Value * multiplier[animal.Key];
        }

        return sum;
    }

    private void OnClickMenuExchangeButton()
    {
        ClearExchange();
        ExchangeUpdate?.Invoke();
    }

    public void Dispose()
    {
        Menu.ExchangeButton.Click -= OnClickMenuExchangeButton;
    }
}