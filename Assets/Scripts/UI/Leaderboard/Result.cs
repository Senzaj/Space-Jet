using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _score;
    
    public void SetParams(string name, int score)
    {
        if (string.IsNullOrEmpty(name) == false)
            _name.text = name;

        _score.text = score.ToString();
    }
}
