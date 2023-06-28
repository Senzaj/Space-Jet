using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class SpaceStation : MonoBehaviour
{
    [SerializeField] private int _blocksCount;
    [SerializeField] private int _maxShieldCount;
    [SerializeField] private int _minShieldCount;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private GameObject _blockTemplate;
    [SerializeField] private float _distanceBetweenBlocks;

    public event UnityAction Moved;
    public int MaxShieldCount => _maxShieldCount;
    public int MinShieldCount => _minShieldCount;

    private Vector3 _spawnPosition;
    private List<StationBlock> _blocks;

    private void Update()
    {
        Rotate();
    }

    private void OnEnable()
    {
        _blocks = new List<StationBlock>();
        _spawnPosition = transform.position;

        for (int i = 0; i < _blocksCount; i++)
        {
            GameObject spawnedObject = Instantiate(_blockTemplate, _spawnPosition, Quaternion.identity , transform);
            _spawnPosition.x += _distanceBetweenBlocks;

            StationBlock spawnedBlock = spawnedObject.GetComponentInChildren<StationBlock>();
            spawnedBlock.Destroyed += Move;
            _blocks.Add(spawnedBlock);
        }
    }

    private void OnDisable()
    {
        foreach (StationBlock block in _blocks)
            block.Destroyed -= Move;
    }

    private void Rotate()
    {
        transform.Rotate(_rotationSpeed, 0, 0);
    }

    private void Move()
    {
        Moved?.Invoke();
        transform.DOMoveX(transform.position.x - _distanceBetweenBlocks, _moveSpeed);
    }
}
