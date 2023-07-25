using UnityEngine;
using DG.Tweening;

public class EnergyShield : MonoBehaviour
{
    [SerializeField] private AudioClip _hitSound;
    
    private ObjectPool _blastPool;
    private AudioSource _audioSource;

    public void SetComponents(BlastPool pool, AudioSource stationBlockAudioSource)
    {
        _blastPool = pool;
        _audioSource = stationBlockAudioSource;
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
                _audioSource.PlayOneShot(_hitSound);
                _blastPool.Spawn(contact.point);
                break;
            }
        }
    }
}
