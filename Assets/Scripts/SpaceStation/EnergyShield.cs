using UnityEngine;
using DG.Tweening;

public class EnergyShield : MonoBehaviour
{
    private ObjectPool _blastPool;

    private void Start()
    {
        _blastPool = FindObjectOfType<ObjectPool>();
    }

    public void TurnOff(float speed)
    {
        transform.DOScale(0,speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Torpedo torpedo))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                _blastPool.Spawn(contact.point);
                break;
            }
        }
    }
}
