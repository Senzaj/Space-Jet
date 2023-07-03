using UnityEngine;

public class SpaceFighterShooting : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootCooldown;
    
    private ObjectPool _torpedoPool;
    private float _passedTime;

    private void Start()
    {
        _torpedoPool = GetComponentInChildren<TorpedoPool>();
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && _passedTime > _shootCooldown)
        {
            Shoot();
            _passedTime = 0;
        }
    }

    private void Shoot()
    {
        _torpedoPool.Spawn(_shootPoint.position);
    }
}
