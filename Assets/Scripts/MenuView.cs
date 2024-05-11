using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : MonoBehaviour
{

    [SerializeField] private GameObject _menu;

    private void Start()
    {
        GameManager.ShowMenu += OnShowMenu;
    }

    private void OnShowMenu(bool isActive) => _menu.SetActive(isActive);

    private void OnDestroy()
    {
        GameManager.ShowMenu -= OnShowMenu;
    }
}
