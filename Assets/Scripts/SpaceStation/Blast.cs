using UnityEngine;
using DG.Tweening;

public class Blast : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _moveSpeed;

    private Transform _target;

    private void OnEnable()
    {
        if (_target != null)
            MoveToTarget();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }

    public void SetTarget(Player player)
    {
        _target = player.transform;
    }

    private void MoveToTarget()
    {
        transform.DOMove(_target.position, _moveSpeed);
    }
}
