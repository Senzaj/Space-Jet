using UnityEngine;
using DG.Tweening;

public class SpaceFighterMover : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _endRotationValue;

    private SpaceStation _station;

    private void OnEnable()
    {
        _station = FindFirstObjectByType<SpaceStation>();
        _station.Moved += Rotate;
    }

    private void OnDisable()
    {
        _station.Moved -= Rotate;
    }

    private void Rotate()
    {
        transform.DOLocalRotate(new Vector3(0, 0, _endRotationValue), _rotationSpeed, RotateMode.FastBeyond360);
    }
}
