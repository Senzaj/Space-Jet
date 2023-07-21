using UnityEngine;
using DG.Tweening;

public class SpaceFighterMover : MonoBehaviour
{
    [SerializeField] private Transform _playerStart;
    [SerializeField] private Transform _playerEnd;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _endRotationValue;
    [SerializeField] private AudioSource _flyingSound;
    [SerializeField] private AudioSource _turnSound;

    private SpaceStation _station;

    private void OnEnable()
    {
        transform.position = _playerEnd.position;
        _station = FindFirstObjectByType<SpaceStation>();
        _station.Moved += Rotate;
    }

    private void OnDisable()
    {
        _station.Moved -= Rotate;
    }

    public void GoToStartPosition()
    {
        transform.DOMove(_playerStart.position, _moveSpeed);
        _flyingSound.Play();
    }

    public void GoToEndPosition()
    {
        transform.DOMove(_playerEnd.position, _moveSpeed);
        _flyingSound.Stop();
    }

    private void Rotate()
    {
        _turnSound.Play();
        transform.DOLocalRotate(new Vector3(0, 0, _endRotationValue), _rotationSpeed, RotateMode.FastBeyond360);
    }
}
