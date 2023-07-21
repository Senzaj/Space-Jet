using UnityEngine;
using UnityEngine.UI;

public class LevelFailedPanel : Panel
{
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private Button _restartLevelButton;
    [SerializeField] private LevelControl _levelControl;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private AudioClip _loseSound;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        ClickSound = FindAnyObjectByType<ClickAudioSource>().GetComponent<AudioSource>();
        TurnOff();
        _levelControl.LevelFailed += OpenPanel;
        _backToMenuButton.onClick.AddListener(OpenMainMenu);
        _restartLevelButton.onClick.AddListener(RestartLevel);
    }

    private void OnDisable()
    {
        _levelControl.LevelFailed -= OpenPanel;
        _backToMenuButton.onClick.RemoveListener(OpenMainMenu);
        _restartLevelButton.onClick.RemoveListener(RestartLevel);
    }

    private void OpenPanel(LevelData data)
    {
        _audioSource.PlayOneShot(_loseSound);
        LevelButton Level = _restartLevelButton.GetComponent<LevelButton>();
        Level.SetLevelData(data);
        TurnOn();
    }

    private void OpenMainMenu()
    {
        ClickSound.Play();
        TurnOff();
        _mainMenu.TurnOn();
    }

    private void RestartLevel()
    {
        ClickSound.Play();
        TurnOff();
    }
}
