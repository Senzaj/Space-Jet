using UnityEngine;
using UnityEngine.UI;

public class ProgressFlags : MonoBehaviour
{
    [SerializeField] private RawImage _firstFlag;
    [SerializeField] private RawImage _SecondFlag;
    [SerializeField] private Color _falseColor;
    [SerializeField] private Color _trueColor;

    public void ChangeFirstFlag()
    {
        ChangeFlag(_firstFlag);
    }

    public void ChangeSecondFlag()
    {
        ChangeFlag(_SecondFlag);
    }

    private void ChangeFlag(RawImage flag)
    {
        flag.color = _trueColor;
    }
}
