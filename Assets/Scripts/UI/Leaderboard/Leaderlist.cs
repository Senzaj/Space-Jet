using Agava.YandexGames.Samples;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderlist : Panel
{
    [SerializeField] private string _leaderboardName = "Leaderboard";
    [SerializeField] private Yandex _yandex;
    [SerializeField] private Result _resultTemplate;
    [SerializeField] private GameObject _content;
    [SerializeField] private Button _closeButton;
    [SerializeField] private MainMenu _mainMenu;

    public string LeaderboardName => _leaderboardName;

    private List<Result> _results = new();
    //private bool _isInitialized = false;

    private void OnEnable()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        TurnOff();

        _yandex.Initialized += OnInitialized;
        _closeButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _yandex.Initialized -= OnInitialized;
        _closeButton.onClick.RemoveListener(Close);
    }

    public override void TurnOn()
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;

        //if (_isInitialized)
            _yandex.GetLeaderboardEntries(LeaderboardName);
    }

    public override void TurnOff()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;

        Clear();
    }

    public void AddResult(string name, int score)
    {
        Result result = Instantiate(_resultTemplate, _content.transform);
        _results.Add(result);
        result.SetParams(name, score);
    }

    private void Clear()
    {
        if (_results.Count > 0)
        {
            while (_results.Count > 0)
            {
                Destroy(_results[0].gameObject);
                _results.Remove(_results[0]);
            }
        }
    }

    private void OnInitialized()
    {
        //_isInitialized = true;
    }

    private void Close()
    {
        ClickSoundSource.Play();
        TurnOff();
        _mainMenu.TurnOn();
    }
}
