using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(SpaceFighterMover))]
[RequireComponent(typeof(SpaceFighterShooting))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    [SerializeField] private ParticleSystem _breakdown;
    [SerializeField] private LevelControl _levelControl;
    [SerializeField] private GameObject _startFighter;
    [SerializeField] private AudioSource _empSound;

    public int MaxHP => _maxHP;

    public event UnityAction Lost;
    public event UnityAction<bool> Won;
    public event UnityAction<int> HealthChanged;

    private int _currentHP;
    private SpaceFighterMover _mover;
    private SpaceFighterShooting _shooting;
    private SpaceStation _station;
    private GameObject _currentFighter;
    private bool _isDamaged;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsVariables.LastFighterSelected) == false)
            ChangeFighter(_startFighter);

        _station = FindFirstObjectByType<SpaceStation>();
        _mover = GetComponent<SpaceFighterMover>();
        _shooting = GetComponent<SpaceFighterShooting>();
        _levelControl.LevelStarted += StartLevel;
        _station.Destroyed += OnStationDestroyed;

        _shooting.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerStartPosition pos))
            _shooting.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerStartPosition pos))
            _shooting.enabled = false;
    }

    private void OnDisable()
    {
        _levelControl.LevelStarted -= StartLevel;
    }

    public void ChangeFighter(GameObject fighter)
    {
        if (_currentFighter != null)
            Destroy(_currentFighter);

        _currentFighter = Instantiate(fighter, transform.position, Quaternion.identity, transform);
    }

    public void TakeDamage(int damage)
    {
        _empSound.Play();
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
    }

    private void OnStationDestroyed()
    {
        _mover.GoToEndPosition();
        Won?.Invoke(_isDamaged);
    }
}
