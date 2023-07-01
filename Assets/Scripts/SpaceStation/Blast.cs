using UnityEngine;
using DG.Tweening;

public class Blast : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _moveSpeed;

    private Transform _target;

    private void OnEnable()
    {
        _target = FindFirstObjectByType<Player>().transform;
        transform.DOMove(_target.position, _moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }
}
