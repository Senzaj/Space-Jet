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

    public event UnityAction<LevelData> LevelSelected;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _index = GetComponentInChildren<TMP_Text>();
        _progressFlags = GetComponentInChildren<ProgressFlags>();
        _playersBank = FindFirstObjectByType<PlayersPiggyBank>();
        _button.onClick.AddListener(Clicked);
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
            {
                _progressFlags.ChangeSecondFlag();
                _playersBank.GetCoin();
            }
        }
        else if (_data.IsLevelComplete == false && _data.IsLevelFullyComplete == false)
        {
            _progressFlags.ChangeFirstFlag();
            _playersBank.GetCoin();

            if (isPlayerDamaged == false)
            {
                _progressFlags.ChangeSecondFlag();
                _playersBank.GetCoin();
            }
        }
    }

    private void Clicked()
    {
        LevelSelected?.Invoke(_data);
    }
}
