using TMPro;
using UnityEngine;

public class AnimalView : MonoBehaviour
{
    [SerializeField] private Animal type;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        FarmManager.FarmUpdate += OnFarmUpdate;
    }

    private void OnFarmUpdate(Animal animal, int count)
    {
        if (animal == type)
        {
            text.text = count.ToString();
        }
    }
}
