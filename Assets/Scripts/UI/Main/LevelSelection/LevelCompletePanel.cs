using Agava.YandexGames.Samples;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletePanel : Panel
{
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private TMP_Text _levelIndex;
    [SerializeField] private LevelSelection _selection;
    [SerializeField] private LevelControl _control;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private RawImage _flag;
    [SerializeField] private Color _falseColor;
    [SerializeField] private Color _trueColor;
    [SerializeField] private AudioClip _victorySound;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Yandex _yandex;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        TurnOff();
        _control.LevelComplete += OpenPanel;
        _backToMenuButton.onClick.AddListener(OpenMainMenu);
        _nextLevelButton.onClick.AddListener(StartNextLevel);
    }

    private void OnDisable()
    {
        _control.LevelComplete -= OpenPanel;
        _backToMenuButton.onClick.RemoveListener(OpenMainMenu);
        _nextLevelButton.onClick.RemoveListener(StartNextLevel);
    }

    private void OpenPanel(LevelData data, bool isPlayerDamaged)
    {
        _audioSource.PlayOneShot(_victorySound);

        if (isPlayerDamaged)
            _flag.color = _falseColor;
        else 
            _flag.color = _trueColor;

        if (data.LevelIndex < _selection.LevelCount)
        {
            LevelButton nextLevel = _nextLevelButton.GetComponent<LevelButton>();
            nextLevel.SetLevelData(_selection.GetNextLevel(data));

            _nextLevelButton.interactable = true;
        }
        else
            _nextLevelButton.interactable = false;
        
        _levelIndex.text = data.LevelIndex.ToString();
        TurnOn();
    }

    private void OpenMainMenu()
    {
        ClickSoundSource.Play();
        _yandex.ShowInterstitial();
        TurnOff();
        _mainMenu.TurnOn();
    }

    private void StartNextLevel()
    {
        ClickSoundSource.Play();
        _yandex.ShowInterstitial();
        TurnOff();
    }
}
