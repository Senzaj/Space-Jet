using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Panel
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _ShopButton;
    [SerializeField] private Button _LeaderboardButton;
    [SerializeField] private Leaderlist _Leaderboard;
    [SerializeField] private Panel _levelSelection;
    [SerializeField] private Panel _shop;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        TurnOn();
        _playButton.onClick.AddListener(TurnOnLevelSelection);
        _ShopButton.onClick.AddListener(TurnOnShop);
        _LeaderboardButton.onClick.AddListener(TurnOnLeaderBoard);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(TurnOnLevelSelection);
        _ShopButton.onClick.RemoveListener(TurnOnShop);
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
        _Leaderboard.TurnOn();
    }
}
