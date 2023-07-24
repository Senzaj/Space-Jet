using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : Panel
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private GameObject _content;

    private List<FighterButton> _fighterButtons = new List<FighterButton>();

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        TurnOff();
        _closeButton.onClick.AddListener(OpenMainMenu);

        foreach (Transform child in _content.transform)
        {
            FighterButton button = child.GetComponent<FighterButton>();
            _fighterButtons.Add(button);

            if (PlayerPrefs.GetInt(PlayerPrefsVariables.LastFighterSelected) == button.Index)
                button.ChangePlayersFighter();
        }
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OpenMainMenu);
    }

    private void OpenMainMenu()
    {
        ClickSoundSource.Play();
        TurnOff();
        _mainMenu.TurnOn();
    }
}
