using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class SpaceStation : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _appearingAndDisappearingSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private GameObject _blockTemplate;
    [SerializeField] private float _distanceBetweenBlocks;
    [SerializeField] private LevelControl _levelControl;
    [SerializeField] private Transform _stationStart;
    [SerializeField] private Transform _stationEnd;

    public int MaxShieldCount => _maxShieldCount;
    public int MinShieldCount => _minShieldCount;

    public event UnityAction Moved;
    public event UnityAction Destroyed;

    private Player _player;
    private int _blocksCount;
    private int _maxShieldCount;
    private int _minShieldCount;
    private Vector3 _spawnPosition;
    private List<StationBlock> _blocks;
    private int _currentBlocksCount;

    private void Update()
    {
        Rotate();
    }

    private void OnEnable()
    {
        _player = FindFirstObjectByType<Player>();
        transform.position = _stationEnd.position;
        _levelControl.LevelStarted += Spawn;
        _player.Lost += GoEndPosition;
    }

    private void OnDisable()
    {
        _levelControl.LevelStarted -= Spawn;
        _player.Lost -= GoEndPosition;

        foreach (StationBlock block in _blocks)
            block.Destroyed -= Move;
    }

    public void SetParams(int blocksCount, int minShields, int maxShields)
    {
        _blocksCount = blocksCount;
        _minShieldCount = minShields;
        _maxShieldCount = maxShields;
    }

    private void Spawn()
    {
        if (_blocks != null)
            DisableBlocks();
        _blocks = new List<StationBlock>();
        transform.position = _stationEnd.position;
        _spawnPosition = transform.position;

        for (int i = 0; i < _blocksCount; i++)
        {
            GameObject spawnedObject = Instantiate(_blockTemplate, _spawnPosition, Quaternion.identity, transform);
            _spawnPosition.x += _distanceBetweenBlocks;

            StationBlock spawnedBlock = spawnedObject.GetComponentInChildren<StationBlock>();
            spawnedBlock.Destroyed += Move;
            _blocks.Add(spawnedBlock);
        }

        _currentBlocksCount = _blocks.Count;
        GoStartPosition();
    }

    private void GoStartPosition()
    {
        transform.DOMove(_stationStart.position, _appearingAndDisappearingSpeed);
    }

    private void GoEndPosition()
    {
        transform.DOMove(_stationEnd.position, _appearingAndDisappearingSpeed);
        DestroyBlocks(_appearingAndDisappearingSpeed);
    }

    private void Rotate()
    {
        transform.Rotate(_rotationSpeed, 0, 0);
    }

    private void Move()
    {
        Moved?.Invoke();
        transform.DOMoveX(transform.position.x - _distanceBetweenBlocks, _moveSpeed);
        _currentBlocksCount--;
        
        if (_currentBlocksCount == 0)
            Destroyed?.Invoke();
    }

    private void DestroyBlocks(float time)
    {
        foreach (StationBlock block in _blocks)
        {
            Destroy(block.gameObject, time);            
        }
    }

    private void DisableBlocks()
    {
        foreach (StationBlock block in _blocks)
        {
            block.gameObject.SetActive(false);
        }
    }
}