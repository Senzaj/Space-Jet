using Agava.WebUtility;
using Agava.YandexGames.Samples;
using UnityEngine;

public class AudioListenerSwitcher : MonoBehaviour
{
    [SerializeField] private Yandex _yandex;

    private void OnEnable()
    {
        _yandex.InterstitialOpened += OnInterstitialOpened;
        _yandex.InterstitialClosed += OnInterstitialClosed;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnDisable()
    {
        _yandex.InterstitialOpened -= OnInterstitialOpened;
        _yandex.InterstitialClosed -= OnInterstitialClosed;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    private void OnInterstitialOpened()
    {
        AudioListener.pause = true;
        AudioListener.volume = 0;
    }

    private void OnInterstitialClosed(bool wasShown)
    {
        AudioListener.pause = false;
        AudioListener.volume = 1;
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        AudioListener.pause = inBackground;
        AudioListener.volume = inBackground ? 0f : 1f;
    }
}
