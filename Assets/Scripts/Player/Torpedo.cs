using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Torpedo : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _explosion;

    public int Damage => _damage;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }
    void Update()
    {
        _rigidbody.velocity = Vector3.forward * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_explosion.gameObject, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
