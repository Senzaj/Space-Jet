using Agava.YandexGames.Samples;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    [SerializeField] private Yandex _yandex;

    private void OnEnable()
    {
        _yandex.InterstitialOpened += StopTime;
        _yandex.InterstitialClosed += ContinueTime;
    }

    private void OnDisable()
    {
        _yandex.InterstitialOpened -= StopTime;
        _yandex.InterstitialClosed -= ContinueTime;
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void ContinueTime()
    {
        Time.timeScale = 1;
    }

    public void ContinueTime(bool wasShown)
    {
        Time.timeScale = 1;
    }
}
