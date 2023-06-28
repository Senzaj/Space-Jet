using UnityEngine;
using DG.Tweening;

public class EnergyShield : MonoBehaviour
{
    public void TurnOff(float speed)
    {
        transform.DOScale(0,speed);
    }
}
