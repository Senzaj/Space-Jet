using System.Collections.Generic;
using UnityEngine;

public class BlastPool : ObjectPool
{
    private void Awake()
    {
        Pool = new List<GameObject>();

        for (int i = 0; i < PoolCapacity; i++)
        {
            GameObject spawned = Instantiate(Template, transform.position, Quaternion.identity, transform);
            spawned.GetComponent<Blast>().SetTarget(Player);
            spawned.SetActive(false);
            Pool.Add(spawned);
        }
    }

    public void SetTargets()
    {
        foreach (GameObject gameObject in Pool)
            gameObject.GetComponent<Blast>().SetTarget(Player);
    }
}
