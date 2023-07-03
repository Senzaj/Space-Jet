using UnityEngine;
using UnityEngine.UI;

public class PausePanel : Panel
{
    [SerializeField] private Button _loseButton;
    [SerializeField] protected Button _continueGameButton;
    [SerializeField] private InGamePanel _gamePanel;
    [SerializeField] private SpaceStation _spaceStation;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
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
        Time.timeScale = 1;
        _spaceStation.ContinueRotation();
        TurnOff();
        _gamePanel.TurnOn();
    }

    private void LoseGame()
    {
        Time.timeScale = 1;
        _spaceStation.ContinueRotation();
        TurnOff();
        _player.TakeDamage(_player.MaxHP);
    }
}
