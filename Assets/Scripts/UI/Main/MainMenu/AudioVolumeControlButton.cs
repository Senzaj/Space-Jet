using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using Agava.YandexGames.Samples;
using Agava.WebUtility;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class AudioVolumeControlButton : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioSources;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;
    [SerializeField] private Color _enableColor;
    [SerializeField] private Color _disableColor;

    private string _playerPrefsVariableName;
    private Button _button;
    private Image _image;
    private bool _isAudioOn;
    private AudioSource _clickSound;

    private void OnEnable()
    {
        _isAudioOn = true;

        if (_audioSources.Count > 1)
            _playerPrefsVariableName = PlayerPrefsVariables.IsSoundOn;
        else
            _playerPrefsVariableName = PlayerPrefsVariables.IsMusicOn;

        if (PlayerPrefs.HasKey(_playerPrefsVariableName))
            _isAudioOn = PlayerPrefs.GetInt(_playerPrefsVariableName) == 1;

        _clickSound = FindAnyObjectByType<ClickAudioSource>().GetComponent<AudioSource>();
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _button.onClick.AddListener(SwitchVolume);

        if (_isAudioOn == false)
            SetVolume(_minVolume, _disableColor);
        else
            SetVolume(_maxVolume, _enableColor);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SwitchVolume);
    }

    public void SwitchVolume()
    {
        _clickSound.Play();

        if (_isAudioOn)
        {
            SetVolume(_minVolume, _disableColor);
            _isAudioOn = false;
            PlayerPrefs.SetInt(_playerPrefsVariableName, 0);
        }
        else
        {
            SetVolume(_maxVolume, _enableColor);
            _isAudioOn = true;
            PlayerPrefs.SetInt(_playerPrefsVariableName, 1);
        }
    }

    private void SetVolume(float volume, Color color)
    {
        foreach (AudioSource source in _audioSources)
            source.volume = volume;

        _image.color = color;
    }
}
