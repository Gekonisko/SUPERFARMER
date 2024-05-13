using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class StepView : MonoBehaviour {
    public UnityEvent CompleteHide;
    private CanvasGroup _canvasGroup;

    public void Hide() {
        if (LeanTween.isTweening(gameObject))
            return;
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 1;
        LeanTween.alphaCanvas(_canvasGroup, 0, 0.5f).setEaseInOutCirc().setOnComplete(_ => {
            CompleteHide?.Invoke();
            gameObject.SetActive(false);
        });
    }

    public void Show() {
        if (LeanTween.isTweening(gameObject))
            return;
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        gameObject.SetActive(true);
        LeanTween.alphaCanvas(_canvasGroup, 1, 0.5f).setEaseOutCubic();
    }
}