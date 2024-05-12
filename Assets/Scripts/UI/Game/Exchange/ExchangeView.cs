using UnityEngine;

public class ExchangeView : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private void Awake()
    {
        GameManager.ActiveGameCanvas += OnChangeGameCanvas;
    }

    private void OnChangeGameCanvas(GameCanvases canvas)
    {
        menu.SetActive(canvas == GameCanvases.Exchange);
    }

    private void OnDestroy()
    {
        GameManager.ActiveGameCanvas -= OnChangeGameCanvas;
    }
}
