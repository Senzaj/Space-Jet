using UnityEngine;
using UnityEngine.Events;

public class PlayersPiggyBank : MonoBehaviour
{
    [SerializeField] private int _startNumberOfCoin;

    public event UnityAction<int> ChangedNumberOfCoin;

    private int _currentNumberOfCoin;

    private void OnEnable()
    {
        _currentNumberOfCoin = _startNumberOfCoin;
    }

    public void GetCoin()
    {
        _currentNumberOfCoin++;
        ChangedNumberOfCoin.Invoke(_currentNumberOfCoin);
    }
    public bool AreEnoughCoins(int coin)
    {
        return _currentNumberOfCoin >= coin;
    }

    public void TakeCoin(int coin)
    {
        _currentNumberOfCoin -= coin;
        ChangedNumberOfCoin.Invoke(_currentNumberOfCoin);
    }
}
