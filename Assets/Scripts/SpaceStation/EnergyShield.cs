using UnityEngine;
using DG.Tweening;

public class EnergyShield : MonoBehaviour
{
    [SerializeField] private AudioClip _hitSound;
    
    private ObjectPool _blastPool;
    private AudioSource _audioSource;

    private void Start()
    {
        _blastPool = FindObjectOfType<BlastPool>();
        _audioSource = FindAnyObjectByType<StationBlockAudioSource>().GetComponent<AudioSource>();
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
