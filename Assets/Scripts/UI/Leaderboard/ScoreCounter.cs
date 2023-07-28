using Agava.YandexGames.Samples;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Text _addText;
    [SerializeField] private Yandex _yandex;
    [SerializeField] private Leaderlist _leaderboard;
    [SerializeField] private SpaceStation _spaceStation;

    private bool _isInitialized = false;
    private int _score;

    private void OnEnable()
    {
        _yandex.Initialized += OnInitialized; 

        if (PlayerPrefs.HasKey(PlayerPrefsVariables.Score))
            SetScore(PlayerPrefs.GetInt(PlayerPrefsVariables.Score));
        else
            SetScore(0);

        _spaceStation.Moved += AddScorePoint;
    }

    private void OnDisable()
    {
        _yandex.Initialized -= OnInitialized;
        _spaceStation.Moved -= AddScorePoint;
    }

    public void AddScorePoint()
    {
        _score++;
        SaveScore();
    }

    private void OnInitialized()
    {
        _isInitialized = true;
    }

    private void SetScore(int newScore)
    {
        _score = newScore;
        SaveScore();
    }

    private void SaveScore()
    {
        _text.text = _score.ToString();
        _addText.text = _score.ToString();
        PlayerPrefs.SetInt(PlayerPrefsVariables.Score, _score);

        if (_isInitialized)
            _yandex.SetLeaderboardScore(_leaderboard.LeaderboardName, _score);
    }
}
