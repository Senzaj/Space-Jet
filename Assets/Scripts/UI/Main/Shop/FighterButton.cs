using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class FighterButton : MonoBehaviour
{
    [SerializeField] private bool _isFighterBought = false;
    [SerializeField] private GameObject _fighterTemplate;
    [SerializeField] private int _price;
    [SerializeField] private TMP_Text _priceField;
    [SerializeField] private RawImage _starIcon;
    [SerializeField] private Image _checkMarkIcon;

    private Button _button;
    private Player _player;
    private PlayersPiggyBank _playersBank;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _player = FindFirstObjectByType<Player>();
        _playersBank = FindFirstObjectByType<PlayersPiggyBank>();
        _priceField.text = _price.ToString();

        _button.onClick.AddListener(TryBuyFighter);

        _checkMarkIcon.enabled = false;

        if (_isFighterBought)
            RedrawButton();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TryBuyFighter);
    }

    private void TryBuyFighter()
    {

        if (_isFighterBought == false)
        {
            if (_playersBank.AreEnoughCoins(_price))
            {
                _playersBank.TakeCoin(_price);
                _isFighterBought=true;
                RedrawButton();
                _player.ChangeFighter(_fighterTemplate);
            }
        }
        else
        {
            _player.ChangeFighter(_fighterTemplate);
        }
    }

    private void RedrawButton()
    {
        _priceField.enabled = false;
        _starIcon.enabled = false;
        _checkMarkIcon.enabled = true;
    }
}
