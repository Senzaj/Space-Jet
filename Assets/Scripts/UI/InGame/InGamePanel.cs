using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanel : Panel
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private Leaderlist _leaderboard;
    [SerializeField] private AuthorizationPanel _authorizationPanel;
    [SerializeField] private Button _leaderboardButton;
    [SerializeField] private SpaceStation _spaceStation;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        TurnOff();
        _pauseButton.onClick.AddListener(StopGame);
        _leaderboardButton.onClick.AddListener(TurnOnLeaderBoard);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(StopGame);
        _leaderboardButton.onClick.RemoveListener(TurnOnLeaderBoard);
    }

    private void StopGame()
    {
        ClickSoundSource.Play();
        Time.timeScale = 0;
        TurnOff();
        _pausePanel.TurnOn();
    }

    private void TurnOnLeaderBoard()
    {
        ClickSoundSource.Play();
        Time.timeScale = 0;
        TurnOff();

        if (PlayerAccount.IsAuthorized)
            _leaderboard.TurnOn();
        else
            _authorizationPanel.TurnOn();
    }
}
