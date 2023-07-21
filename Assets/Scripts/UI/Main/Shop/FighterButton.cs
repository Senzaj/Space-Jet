using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class FighterButton : MonoBehaviour
{
    [SerializeField] private bool _isFighterBought = false;
    [SerializeField] private int _index;
    [SerializeField] private GameObject _fighterTemplate;
    [SerializeField] private int _price;
    [SerializeField] private TMP_Text _priceField;
    [SerializeField] private RawImage _starIcon;
    [SerializeField] private Image _checkMarkIcon;

    public int Index => _index;

    private Button _button;
    private Player _player;
    private PlayersPiggyBank _playersBank;
    private AudioSource _clickSound;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _player = FindFirstObjectByType<Player>();
        _playersBank = FindFirstObjectByType<PlayersPiggyBank>();
        _clickSound = FindFirstObjectByType<ClickAudioSource>().GetComponent<AudioSource>();
        _priceField.text = _price.ToString();

        _button.onClick.AddListener(TryBuyFighter);

        _checkMarkIcon.enabled = false;

        if (PlayerPrefs.GetInt(GetFighterName()) == 1)
            _isFighterBought = true;

        if (_isFighterBought)
            RedrawButton();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TryBuyFighter);
    }

    public void ChangePlayersFighter()
    {
        _player.ChangeFighter(_fighterTemplate);
        PlayerPrefs.SetInt(PlayerPrefsVariables.LastFighterSelected, _index);
    }

    private void TryBuyFighter()
    {
        _clickSound.Play();

        if (_isFighterBought == false)
        {
            if (_playersBank.AreEnoughCoins(_price))
            {
                _playersBank.TakeCoin(_price);
                _isFighterBought=true;
                RedrawButton();
                PlayerPrefs.SetInt(GetFighterName(), 1);
                ChangePlayersFighter();
            }
        }
        else
        {
            ChangePlayersFighter();
        }
    }

    private void RedrawButton()
    {
        _priceField.enabled = false;
        _starIcon.enabled = false;
        _checkMarkIcon.enabled = true;
    }

    private string GetFighterName()
    {
        return "fighter" + _index;
    }
}
