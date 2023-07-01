using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Panel
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _SettingsButton;
    [SerializeField] private Button _ShopButton;
    [SerializeField] private Button _ExitButton;
    [SerializeField] private Panel _levelSelection;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        TurnOn();
        _playButton.onClick.AddListener(TurnOnLevelSelection);
        _SettingsButton.onClick.AddListener(TurnOnSettings);
        _ShopButton.onClick.AddListener(TurnOnShop);
        _ExitButton.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(TurnOnLevelSelection);
        _SettingsButton.onClick.RemoveListener(TurnOnSettings);
        _ShopButton.onClick.RemoveListener(TurnOnShop);
        _ExitButton.onClick.RemoveListener(Exit);
    }

    private void TurnOnLevelSelection()
    {
        _levelSelection.TurnOn();
        TurnOff();
    }

    private void TurnOnShop()
    {

    }

    private void TurnOnSettings()
    {

    }

    private void Exit()
    {

    }
}