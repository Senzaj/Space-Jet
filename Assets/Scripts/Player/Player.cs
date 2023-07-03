using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(SpaceFighterMover))]
[RequireComponent(typeof(SpaceFighterShooting))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    [SerializeField] private ParticleSystem _breakdown;
    [SerializeField] private LevelControl _levelControl;

    public int MaxHP => _maxHP;

    public event UnityAction Lost;
    public event UnityAction<bool> Won;
    public event UnityAction<int> HealthChanged;

    private int _currentHP;
    private SpaceFighterMover _mover;
    private SpaceFighterShooting _shooting;
    private SpaceStation _station;
    private bool _isDamaged;

    private void OnEnable()
    {
        _station = FindFirstObjectByType<SpaceStation>();
        _mover = GetComponent<SpaceFighterMover>();
        _shooting = GetComponent<SpaceFighterShooting>();
        _levelControl.LevelStarted += StartLevel;
        _station.Destroyed += OnStationDestroyed;

        _shooting.enabled = false;
    }

    private void OnDisable()
    {
        _levelControl.LevelStarted -= StartLevel;
    }

    public void TakeDamage(int damage)
    {
        _currentHP -= damage;
        _isDamaged = true;
        _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);
        HealthChanged.Invoke(_currentHP);
        _breakdown.Play();
        TryEscape();
    }

    private void TryEscape()
    {
        if (_currentHP == 0)
        {
            _shooting.enabled = false;
            _mover.GoToEndPosition();
            Lost?.Invoke();
        }
    }

    private void StartLevel()
    {
        _mover.GoToStartPosition();
        _currentHP = _maxHP;
        HealthChanged.Invoke(_currentHP);
        _isDamaged = false;
        _shooting.enabled = true;
    }

    private void OnStationDestroyed()
    {
        Won?.Invoke(_isDamaged);
        _shooting.enabled = false;
        _mover.GoToEndPosition();
    }
}
