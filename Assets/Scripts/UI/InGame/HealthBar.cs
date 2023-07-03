using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _durationOfChange;

    private Slider _slider;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaxHP;
        _player.HealthChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeValue;
    }

    private void ChangeValue(int value)
    {
        _slider.DOValue(value, _durationOfChange);
    }
}
