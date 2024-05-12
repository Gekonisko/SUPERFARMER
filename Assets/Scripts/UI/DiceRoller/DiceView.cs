using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DiceView : MonoBehaviour
{
    public static event Action<Animal> RollDice;

    private Animal[] _animals;
    [SerializeField] private Image image;


    public void Roll(Animal[] animals)
    {
        _animals = animals;
        StartCoroutine(RollAnimation());
    }

    IEnumerator RollAnimation()
    {

        Animal result = _animals[UnityEngine.Random.Range(0, _animals.Length)];

        float time = 0;
        while (time < 0.2f)
        {
            var animal = _animals[UnityEngine.Random.Range(0, _animals.Length)].ToString();
            var animalImage = Resources.Load<Sprite>(animal);

            image.sprite = animalImage;

            yield return new WaitForSeconds(time);

            time += 0.05f;
        }

        image.sprite = Resources.Load<Sprite>(result.ToString());

        yield return new WaitForSeconds(1);

        RollDice?.Invoke(result);
    }
}
