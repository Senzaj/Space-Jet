using UnityEngine;

[RequireComponent (typeof(ParticleSystem))]
public class Explosion : MonoBehaviour
{
    private ParticleSystem _exlosion;

    private void Start()
    {
        _exlosion = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (_exlosion.isStopped)
            Destroy(gameObject);
    }
}
