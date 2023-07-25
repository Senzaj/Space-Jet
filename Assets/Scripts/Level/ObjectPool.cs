using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private Player _player;

    protected GameObject Template => _template;
    protected int PoolCapacity => _poolCapacity;
    protected Player Player => _player;
    protected List<GameObject> Pool;

    private void Awake()
    {
        Pool = new List<GameObject>();

        for (int i = 0; i < _poolCapacity; i++)
        {
            GameObject spawned = Instantiate(_template, transform.position,Quaternion.identity ,transform);
            spawned.SetActive(false);
            Pool.Add(spawned);
        }
    }

    private void OnEnable()
    {
        _player.Lost += DisableObjects;
        _player.Won += DisableObjects;
    }

    public GameObject Spawn(Vector3 spawnPoint)
    {
        foreach (GameObject obj in Pool)
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
        foreach(GameObject obj in Pool)
            obj.SetActive(false);
    }

    private void DisableObjects()
    {
        foreach (GameObject obj in Pool)
            obj.SetActive(false);
    }
}
