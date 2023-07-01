using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private int _poolCapacity;

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

    public void Spawn(Vector3 spawnPoint)
    {
        foreach (GameObject obj in _pool)
        {
            if (obj.activeSelf == false)
            {
                obj.transform.position = spawnPoint;
                obj.transform.rotation = Quaternion.identity;
                obj.SetActive(true);
                break;
            }
        }
    }
}
