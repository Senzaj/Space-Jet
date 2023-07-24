using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))] 
public class LevelButton : MonoBehaviour
{
    private Button _button;
    private TMP_Text _index;
    private LevelData _data;
    private ProgressFlags _progressFlags;
    private PlayersPiggyBank _playersBank;
    private AudioSource _clickSound;

    public event UnityAction<LevelData> LevelSelected;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _index = GetComponentInChildren<TMP_Text>();
        _progressFlags = GetComponentInChildren<ProgressFlags>();
        _playersBank = FindFirstObjectByType<PlayersPiggyBank>();
        _clickSound = FindFirstObjectByType<ClickAudioSource>().GetComponent<AudioSource>();
        _button.onClick.AddListener(Clicked);
    }

    private void Start()
    {
        if (_data != null && PlayerPrefs.HasKey(GetLevelName()))
        {
            int numberOfStarsPerLevel = PlayerPrefs.GetInt(GetLevelName());

            if (numberOfStarsPerLevel == 1)
            {
                _data.CompleteLevel();
                _progressFlags.ChangeFirstFlag();
            }
            else if (numberOfStarsPerLevel == 2)
            {
                _data.CompleteLevelFully();
                _progressFlags.ChangeFirstFlag();
                _progressFlags.ChangeSecondFlag();
            }
        }
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Clicked);
    }

    public void SetLevelData(LevelData data)
    {
        _data = data;
        _index.text = data.LevelIndex.ToString();
    }

    public void Disable()
    {
        _button.interactable = false;
    }

    public void Enable()
    {
        _button.interactable = true;
    }
    public void TryChangeFlags(bool isPlayerDamaged)
    {
        if (_data.IsLevelComplete && _data.IsLevelFullyComplete)
        {
            return;
        }
        else if (_data.IsLevelComplete && _data.IsLevelFullyComplete == false)
        {
            if (isPlayerDamaged == false)
                LevelFullyComplete();
        }
        else if (_data.IsLevelComplete == false && _data.IsLevelFullyComplete == false)
        {
            _progressFlags.ChangeFirstFlag();
            PlayerPrefs.SetInt(GetLevelName(), 1);
            _playersBank.AddCoin();

            int levelIndex = _data.LevelIndex;
            PlayerPrefs.SetInt(PlayerPrefsVariables.NumberOfCompletedLevels, ++levelIndex);

            if (isPlayerDamaged == false)
                LevelFullyComplete();
        }
    }

    public string GetLevelName()
    {
        return "ProgressOfLevel" + _data.LevelIndex;
    }

    private void Clicked()
    {
        _clickSound.Play();
        LevelSelected?.Invoke(_data);
    }

    private void LevelFullyComplete()
    {
        _progressFlags.ChangeSecondFlag();
        _playersBank.AddCoin();
        PlayerPrefs.SetInt(GetLevelName(), 2);
    }
}
