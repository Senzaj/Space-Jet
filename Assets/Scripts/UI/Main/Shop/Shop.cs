using UnityEngine;
using UnityEngine.UI;

public class Shop : Panel
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private MainMenu _mainMenu;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        TurnOff();
        _closeButton.onClick.AddListener(OpenMainMenu);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OpenMainMenu);
    }

    private void OpenMainMenu()
    {
        TurnOff();
        _mainMenu.TurnOn();
    }
}
