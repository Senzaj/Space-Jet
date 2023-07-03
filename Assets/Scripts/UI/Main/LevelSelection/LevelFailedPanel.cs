using UnityEngine;
using UnityEngine.UI;

public class LevelFailedPanel : Panel
{
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private Button _restartLevelButton;
    [SerializeField] private LevelControl _levelControl;
    [SerializeField] private MainMenu _mainMenu;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
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
        LevelButton Level = _restartLevelButton.GetComponent<LevelButton>();
        Level.SetLevelData(data);
        TurnOn();
    }

    private void OpenMainMenu()
    {
        TurnOff();
        _mainMenu.TurnOn();
    }

    private void RestartLevel()
    {
        TurnOff();
    }
}
