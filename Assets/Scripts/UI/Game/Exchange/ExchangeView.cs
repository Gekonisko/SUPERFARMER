using UnityEngine;
using Zenject;

public class ExchangeView : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [Inject]
    private GameService gameService;

    private void Awake()
    {
        gameService.ActiveGameCanvas += OnChangeGameCanvas;
    }

    private void OnChangeGameCanvas(GameCanvases canvas)
    {
        menu.SetActive(canvas == GameCanvases.Exchange);
    }

    private void OnDestroy()
    {
        gameService.ActiveGameCanvas -= OnChangeGameCanvas;
    }
}
