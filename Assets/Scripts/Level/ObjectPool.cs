using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private Player _player;

    private List<GameObject> _pool;

    private void Awake()
    {
        _pool = new List<GameObject>();

        for (int i = 0; i < _poolCapacity; i++)
        {
            GameObject spawned = Instantiate(_template, transform.position,Quaternion.identity ,transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    private void OnEnable()
    {
        //_player = FindFirstObjectByType<Player>();
        _player.Lost += DisableObjects;
        _player.Won += DisableObjects;
    }

    public GameObject Spawn(Vector3 spawnPoint)
    {
        foreach (GameObject obj in _pool)
        {
            if (obj.activeSelf == false)
            {
                obj.transform.position = spawnPoint;
                obj.transform.rotation = Quaternion.identity;
                obj.SetActive(true);
                return obj;
            }
        }

        return null;
    }

    private void DisableObjects(bool isPlayerDamaged)
    {
        foreach(GameObject obj in _pool)
            obj.SetActive(false);
    }

    private void DisableObjects()
    {
        foreach (GameObject obj in _pool)
            obj.SetActive(false);
    }
}
