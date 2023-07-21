using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class PausePanel : Panel
{
    [SerializeField] private Button _loseButton;
    [SerializeField] protected Button _continueGameButton;
    [SerializeField] private InGamePanel _gamePanel;
    [SerializeField] private SpaceStation _spaceStation;
    [SerializeField] private Player _player;
    [SerializeField] private TimeControl _timeControl;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        ClickSound = FindAnyObjectByType<ClickAudioSource>().GetComponent<AudioSource>();
        TurnOff();
        _continueGameButton.onClick.AddListener(ContinueGame);
        _loseButton.onClick.AddListener(LoseGame);
    }

    private void OnDisable()
    {
        _continueGameButton.onClick.RemoveListener(ContinueGame);
        _loseButton.onClick.RemoveListener(LoseGame);
    }

    private void ContinueGame()
    {
        ClickSound.Play();
        _timeControl.ContinueTime();
        TurnOff();
        _gamePanel.TurnOn();
    }

    private void LoseGame()
    {
        ClickSound.Play();
        _timeControl.ContinueTime();
        TurnOff();
        _player.TakeDamage(_player.MaxHP);
    }
}
