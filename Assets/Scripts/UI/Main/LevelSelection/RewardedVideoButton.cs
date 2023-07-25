using Agava.YandexGames.Samples;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(CanvasGroup))]
[RequireComponent (typeof(Button))]
public class RewardedVideoButton : MonoBehaviour
{
    [SerializeField] private Image _videoImage;
    [SerializeField] private Yandex _yandex;
    [SerializeField] private Color _startColor = Color.white;
    [SerializeField] private Color _endColor;
    [SerializeField] private float _blinkingDuration;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _videoImage.color = _startColor;
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
        TurnOnFlicker();
    }

    public void TurnOff()
    {
        _canvasGroup.alpha = 0.5f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        TurnOffFlicker();
    }

    private void TurnOnFlicker()
    {
        _videoImage.DOColor(_endColor, _blinkingDuration).SetLoops(-1,LoopType.Yoyo);
    }

    private void TurnOffFlicker()
    {
        _videoImage.DOKill();
        _videoImage.color = _startColor;
    }
}
