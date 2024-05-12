using UnityEngine;

public class MenuView : MonoBehaviour
{

    [SerializeField] private GameObject _menu;

    private void Awake()
    {
        GameManager.ActiveGameCanvas += OnChangeGameCanvas;
    }

    private void OnChangeGameCanvas(GameCanvases canvas) => _menu.SetActive(canvas == GameCanvases.Menu);

    private void OnDestroy()
    {
        GameManager.ActiveGameCanvas -= OnChangeGameCanvas;
    }
}
