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
        public Action InterstitialOpened;
        public Action<bool> InterstitialClosed;
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
            InterstitialAd.Show(OnInterstitialOpened, OnInterstitialClosed);
        }

        public void ShowVideo()
        {
            VideoAd.Show();
        }

        public void ShowStickyAd()
        {
            StickyAd.Show();
        }

        public void HideStickyAd()
        {
            StickyAd.Hide();
        }

        public void GetEnvironment()
        {
            Debug.Log($"Environment = {JsonUtility.ToJson(YandexGamesSdk.Environment)}");
        }

        private void OnInitialized()
        {
            SetLanguage();
            ShowStickyAd();
        }

        private void OnInterstitialOpened()
        {
            Time.timeScale = 0;
            InterstitialOpened.Invoke();
        }

        private void OnInterstitialClosed(bool showed)
        {
            Time.timeScale = 1;
            InterstitialClosed.Invoke(showed);
        }
    }
}
