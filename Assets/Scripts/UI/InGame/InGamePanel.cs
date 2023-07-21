using UnityEngine;
using UnityEngine.UI;

public class InGamePanel : Panel
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private SpaceStation _spaceStation;
    [SerializeField] private TimeControl _timeControl;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        ClickSound = FindAnyObjectByType<ClickAudioSource>().GetComponent<AudioSource>();
        TurnOff();
        _pauseButton.onClick.AddListener(StopGame);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(StopGame);
    }

    private void StopGame()
    {
        ClickSound.Play();
        _timeControl.StopTime();
        TurnOff();
        _pausePanel.TurnOn();
    }
}
