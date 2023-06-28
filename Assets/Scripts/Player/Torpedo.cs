using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MeshRenderer))]
public class Torpedo : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _explosion;

    public int Damage => _damage;

    private Rigidbody _rigidbody;
    private Collider _collider;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }
    void Update()
    {
        _rigidbody.velocity = Vector3.forward * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _meshRenderer.enabled = false;
        _collider.enabled = false;
        Instantiate(_explosion.gameObject, transform.position, Quaternion.identity, transform);
        gameObject.SetActive(false);
    }
}
