using UnityEngine;
using UnityEngine.UI;

public class InGamePanel : Panel
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private SpaceStation _spaceStation;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        TurnOff();
        _pauseButton.onClick.AddListener(StopGame);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(StopGame);
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        TurnOff();
        _pausePanel.TurnOn();
    }
}
