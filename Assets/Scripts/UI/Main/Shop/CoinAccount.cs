using TMPro;
using UnityEngine;

public class CoinAccount : MonoBehaviour
{
    [SerializeField] private TMP_Text _numberOfCoin;
    [SerializeField] private PlayersPiggyBank _playersBank;

    private void OnEnable()
    {
        _playersBank.ChangedNumberOfCoin += ChangeValue;
    }

    private void OnDisable()
    {
        _playersBank.ChangedNumberOfCoin -= ChangeValue;
    }

    private void ChangeValue(int numberOfCoin)
    {
        _numberOfCoin.text = numberOfCoin.ToString();
    }
}
