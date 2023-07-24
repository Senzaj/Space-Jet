using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(CanvasGroup))]
public abstract class Panel : MonoBehaviour
{
    [SerializeField] protected AudioSource ClickSoundSource;
    protected CanvasGroup CanvasGroup;

    public void TurnOn()
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
    }

    public void TurnOff()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
    }
}
