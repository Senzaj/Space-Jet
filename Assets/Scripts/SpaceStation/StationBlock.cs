using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class StationBlock : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    [SerializeField] private float _turnOffShieldsSpeed;
    [SerializeField] private float _getAwaySpeed;
    [SerializeField] private ParticleSystem _fire;
    [SerializeField] private ParticleSystem _bigBoom;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip _explosionSound;

    public event UnityAction<StationBlock> Destroyed;

    private int _currentHP;
    private List<EnergyShield> _energyShields;
    private SpaceStation _station;
    private Transform _destroyerPosition;
    private AudioSource _audioSource;
    private BlastPool _blastPool;

    private void OnEnable()
    {
        _energyShields = new List<EnergyShield>();
        _currentHP = _maxHP;

        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out EnergyShield energyShield))
            {
                _energyShields.Add(energyShield);
                child.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Torpedo torpedo))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Instantiate(_fire.gameObject, contact.point, Quaternion.identity, transform);
                break;
            }

            _currentHP -= torpedo.Damage;
            _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);
            _audioSource.PlayOneShot(_hitSound);
            TryToBeDestroyed();
        }
    }

    public void SetComponents(Destroyer destroyer, SpaceStation spaceStation, StationBlockAudioSource stationBlockAudioSource, BlastPool pool)
    {
        _destroyerPosition = destroyer.transform;
        _station = spaceStation;
        _audioSource = stationBlockAudioSource.GetComponent<AudioSource>();
        _blastPool = pool;

        TurnOnShields();
    }

    private void TryToBeDestroyed()
    {
        if (_currentHP == 0)
        {
            foreach(EnergyShield shield in _energyShields)
            {
                if (shield.gameObject.activeSelf)
                    shield.TurnOff(_turnOffShieldsSpeed);
            }

            _audioSource.PlayOneShot(_explosionSound);
            _bigBoom.Play();
            transform.DOMove(_destroyerPosition.position - transform.position, _getAwaySpeed);
            transform.parent.parent = null;
            Destroyed?.Invoke(this);
        }
    }

    private void TurnOnShields()
    {
        foreach (EnergyShield shield in _energyShields)
            shield.SetComponents(_blastPool, _audioSource);

        _energyShields = _energyShields.OrderBy(x => Random.Range(0, _energyShields.Count)).ToList();
        int turnedOnShieldsCount = Random.Range(_station.MinShieldCount, _station.MaxShieldCount);

        for (int i = 0; i < turnedOnShieldsCount; i++)
            _energyShields[i].gameObject.SetActive(true);
    }
}
