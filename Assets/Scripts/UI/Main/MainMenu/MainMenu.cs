using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Panel
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _LeaderboardButton;
    [SerializeField] private Leaderlist _Leaderboard;
    [SerializeField] private AuthorizationPanel _authorizationPanel;
    [SerializeField] private Panel _levelSelection;
    [SerializeField] private Panel _shop;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        TurnOn();
        _playButton.onClick.AddListener(TurnOnLevelSelection);
        _shopButton.onClick.AddListener(TurnOnShop);
        _LeaderboardButton.onClick.AddListener(TurnOnLeaderBoard);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(TurnOnLevelSelection);
        _shopButton.onClick.RemoveListener(TurnOnShop);
        _LeaderboardButton.onClick.RemoveListener(TurnOnLeaderBoard);
    }

    private void TurnOnLevelSelection()
    {
        ClickSoundSource.Play();
        TurnOff();
        _levelSelection.TurnOn();
    }

    private void TurnOnShop()
    {
        ClickSoundSource.Play();
        TurnOff();
        _shop.TurnOn();
    }

    private void TurnOnLeaderBoard()
    {
        ClickSoundSource.Play();
        TurnOff();

        if (PlayerAccount.IsAuthorized)
            _Leaderboard.TurnOn();
        else
            _authorizationPanel.TurnOn();
    }
}
