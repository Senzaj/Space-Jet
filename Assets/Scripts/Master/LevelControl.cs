using Agava.YandexGames.Samples;
using UnityEngine;
using UnityEngine.Events;

public class LevelControl : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [SerializeField] private SpaceStation _station;
    [SerializeField] private Player _player;
    [SerializeField] private InGamePanel _gamePanel;
    [SerializeField] private LevelButton _nextLevelButton;
    [SerializeField] private LevelButton _restartLevelButton;

    public event UnityAction LevelStarted;
    public event UnityAction<LevelData, bool> LevelComplete;
    public event UnityAction<LevelData> LevelFailed;
    private LevelData _currentLevel;

    private void Start()
    {
        _restartLevelButton.LevelSelected += LoadLevel;
        _nextLevelButton.LevelSelected += LoadLevel;

        foreach (LevelButton button in _content.GetComponentsInChildren<LevelButton>())
            button.LevelSelected += LoadLevel;

        _player.Won += OnPlayerWon;
        _player.Lost += OnPlayerLost;
    }

    private void OnDisable()
    {
        _restartLevelButton.LevelSelected -= LoadLevel;
        _nextLevelButton.LevelSelected -= LoadLevel;

        foreach (LevelButton button in _content.GetComponentsInChildren<LevelButton>())
            button.LevelSelected -= LoadLevel;

        _player.Won -= OnPlayerWon;
        _player.Lost -= OnPlayerLost;
    }

    private void LoadLevel(LevelData data)
    {
        _currentLevel = data;
        _station.SetParams(data.StationBlocksCount, data.RotationSpeed , data.MinShieldsCount, data.MaxShieldsCount);
        LevelStarted?.Invoke();
        _gamePanel.TurnOn();
    }

    private void OnPlayerWon( bool isPlayerDamaged)
    {
        LevelComplete?.Invoke(_currentLevel, isPlayerDamaged);
        _gamePanel.TurnOff();
    }

    private void OnPlayerLost()
    {
        LevelFailed?.Invoke(_currentLevel);
        _gamePanel.TurnOff();
    }
}
