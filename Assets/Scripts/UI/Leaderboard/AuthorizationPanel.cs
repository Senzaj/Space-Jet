using Agava.YandexGames.Samples;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationPanel : Panel
{
    [SerializeField] private Button _cancelButton;
    [SerializeField] private Button _confirmButton;
    [SerializeField] private InGamePanel _inGamePanel;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private Yandex _yandex;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        TurnOff();

        _cancelButton.onClick.AddListener(Close);
        _confirmButton.onClick.AddListener(Authorize);
    }

    private void OnDisable()
    {
        _cancelButton.onClick.RemoveListener(Close);
        _confirmButton.onClick.RemoveListener(Authorize);
    }

    private void Close()
    {
        ClickSoundSource.Play();
        TurnOff();

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            _inGamePanel.TurnOn();
        }
        else
            _mainMenu.TurnOn();
    }

    private void Authorize()
    {
        ClickSoundSource.Play();
        TurnOff();

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            _inGamePanel.TurnOn();
        }
        else
            _mainMenu.TurnOn();

        _yandex.OnAuthorizeButtonClick();
    }
}
