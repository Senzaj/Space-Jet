using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : Panel
{
    [SerializeField] private List<LevelData> _data;
    [SerializeField] private GameObject _content;
    [SerializeField] private LevelControl _control; 
    [SerializeField] private LevelButton _buttonTemplate;
    [SerializeField] private MainMenu _menu;
    [SerializeField] private Button _closeButton;
    [SerializeField] private int _minAvailableLevelIndex;

    public int LevelCount => _data.Count;

    private List<LevelButton> _buttons;

    private void Awake()
    {
        _buttons = new List<LevelButton>();
        CanvasGroup = GetComponent<CanvasGroup>();
        TurnOff();

        foreach (var data in _data)
        {
            LevelButton button = Instantiate(_buttonTemplate, _content.transform);
            _buttons.Add(button);
            button.SetLevelData(data);
            button.Disable();

            if (data.LevelIndex <= _minAvailableLevelIndex)
                button.Enable();
        }

        _control.LevelStarted += TurnOff;
        _closeButton.onClick.AddListener(GoToMenu);
        _control.LevelComplete += OnLevelComplete;
    }

    private void OnDisable()
    {
        _control.LevelStarted -= TurnOff;
        _closeButton.onClick.RemoveListener(GoToMenu);
        _control.LevelComplete -= OnLevelComplete;
    }

    public LevelData GetNextLevel(LevelData data)
    {
        return _data[data.LevelIndex];
    }

    private void GoToMenu()
    {
        TurnOff();
        _menu.TurnOn();
    }

    private void OnLevelComplete(LevelData level, bool IsPlayerDamaged)
    {
        if (level.LevelIndex < _buttons.Count)
            _buttons[level.LevelIndex].Enable();

        _buttons[level.LevelIndex - 1].TryChangeFlags(IsPlayerDamaged);
    }
}
