#pragma warning disable

using System;
using System.Collections;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using Lean.Localization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Agava.YandexGames.Samples
{
    public class Yandex : MonoBehaviour
    {
        [SerializeField] private Leaderlist _leaderlist;
        [SerializeField] private PlayersPiggyBank _playersPiggyBank;
        [SerializeField] private int Reward = 2;

        public Action AdOpened;
        public Action<bool> AdClosed;
        public Action Initialized;
        private string _currentLanguage;

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        private IEnumerator Start()
        {
            #if !UNITY_WEBGL || UNITY_EDITOR
            yield break;
            #endif

            yield return YandexGamesSdk.Initialize(OnInitialized);
        }

        public void SetLanguage()
        {
            _currentLanguage = YandexGamesSdk.Environment.i18n.lang;

            switch (_currentLanguage)
            {
                case "ru":
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(LanguageList.Russian);
                    break;

                case "uk":
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(LanguageList.Russian);
                    break;

                case "be":
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(LanguageList.Russian);
                    break;

                case "uz":
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(LanguageList.Russian);
                    break;

                case "kk":
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(LanguageList.Russian);
                    break;

                case "tr":
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(LanguageList.Turkish);
                    break;

                default:
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(LanguageList.English);
                    break;
            }
        }

        public void ShowInterstitial()
        {
            InterstitialAd.Show(OnAdOpened, OnAdClosed);
        }

        public void ShowVideo()
        {
            VideoAd.Show(OnAdOpened, OnRewarded, OnAdClosed);
        }

        public void ShowStickyAd()
        {
            StickyAd.Show();
        }

        public void HideStickyAd()
        {
            StickyAd.Hide();
        }

        public void SetLeaderboardScore(string boardName,int score)
        {
            Leaderboard.SetScore(boardName, score);
        }

        public void GetLeaderboardEntries(string boardName)
        {
            Leaderboard.GetEntries(boardName, (result) =>
            {
                var results = result.entries.Length;
                results = Mathf.Clamp(results, _leaderlist.MinPlayersCount, _leaderlist.MaxPlayersCount);

                for (var i = 0; i < results; i++)
                    _leaderlist.AddResult(result.entries[i].player.publicName, result.entries[i].score);
            });
        }

        public void GetLeaderboardPlayerEntry(string boardName)
        {
            Leaderboard.GetPlayerEntry(boardName, (result) =>
            {
                if (result == null)
                    Debug.Log("Player is not present in the leaderboard.");
                else
                    Debug.Log($"My rank = {result.rank}, score = {result.score}");
            });
        }

        private void OnInitialized()
        {
            SetLanguage();
            ShowStickyAd();
            Initialized.Invoke();
        }

        private void OnRewarded()
        {
            _playersPiggyBank.AddCoin(Reward);
        }

        private void OnAdOpened()
        {
            Time.timeScale = 0;
            AdOpened.Invoke();
        }

        private void OnAdClosed(bool showed)
        {
            Time.timeScale = 1;
            AdClosed.Invoke(showed);
        }

        private void OnAdClosed()
        {
            Time.timeScale = 1;
            AdClosed.Invoke(true);
        }
    }
}
