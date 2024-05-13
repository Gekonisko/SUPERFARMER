using UnityEngine;
using Zenject;

public class MenuView : MonoBehaviour
{

    [SerializeField] private GameObject _menu;
    [Inject]
    private GameService gameService;

    private void Awake()
    {
        gameService.ActiveGameCanvas += OnChangeGameCanvas;
    }

    private void OnChangeGameCanvas(GameCanvases canvas) => _menu.SetActive(canvas == GameCanvases.Menu);

    private void OnDestroy()
    {
        gameService.ActiveGameCanvas -= OnChangeGameCanvas;
    }
}
