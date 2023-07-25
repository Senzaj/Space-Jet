using Lean.Localization;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanel : Panel
{
    [SerializeField] private int _levelIndexForTutorial1;
    [SerializeField] private int _levelIndexForTutorial2;
    [SerializeField] private Text _text;
    [SerializeField] private LeanPhrase _phrase1;
    [SerializeField] private LeanPhrase _phrase2;
    [SerializeField] private InGamePanel _inGamePanel;
    [SerializeField] private Button _closeButton;

    public int LevelIndexForTutorial1 => _levelIndexForTutorial1;
    public int LevelIndexForTutorial2 => _levelIndexForTutorial2;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        TurnOff();
        _closeButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(Close);
    }

    public void ShowTutorial1()
    {
        _inGamePanel.TurnOff();
        _text.text = Lean.Localization.LeanLocalization.GetTranslationText(_phrase1.name);
        TurnOn();
    }

    public void ShowTutorial2()
    {
        _inGamePanel.TurnOff();
        _text.text = Lean.Localization.LeanLocalization.GetTranslationText(_phrase2.name);
        TurnOn();
    }

    private void Close()
    {
        ClickSoundSource.Play();
        TurnOff();
        _inGamePanel.TurnOn();
    }
}
