using UnityEngine;
using UnityEngine.UI;

public class SpaceFighterShooting : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootCooldown;
    [SerializeField] private Button _shootButton;
    [SerializeField] private AudioSource _shootSound;
    
    private ObjectPool _torpedoPool;
    private float _passedTime;

    private void OnEnable()
    {
        _shootButton.onClick.AddListener(Shoot);
    }

    private void OnDisable()
    {
        _shootButton.onClick.RemoveListener(Shoot);
    }

    private void Start()
    {
        _torpedoPool = GetComponentInChildren<TorpedoPool>();
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;
    }

    private void Shoot()
    {
        if (_passedTime > _shootCooldown)
        {
            _shootSound.Play();
            _torpedoPool.Spawn(_shootPoint.position);
            _passedTime = 0;
        }
    }
}
