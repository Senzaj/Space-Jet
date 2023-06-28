using UnityEngine;

public class SpaceFighterShooting : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _torpedoTemplate;
    [SerializeField] private float _shootCooldown;

    private float _passedTime;

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
        Instantiate(_torpedoTemplate, _shootPoint.position, Quaternion.identity, transform);
    }
}
