using Agava.YandexGames.Samples;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(CanvasGroup))]
[RequireComponent (typeof(Button))]
public class RewardedVideoButton : MonoBehaviour
{
    [SerializeField] private Image _videoImage;
    [SerializeField] private Yandex _yandex;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show()
    {
        _yandex.ShowVideo();
    }

    public void TurnOn()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void TurnOff()
    {
        _canvasGroup.alpha = 0.5f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}
