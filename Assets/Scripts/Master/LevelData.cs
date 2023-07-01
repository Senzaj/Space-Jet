using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] private int _levelIndex;
    [SerializeField] private int _stationBlocksCount;
    [SerializeField] private int _minShieldsCount;
    [SerializeField] private int _maxShieldsCount;
    [SerializeField] private LevelControl _control;

    public int LevelIndex => _levelIndex;
    public int StationBlocksCount => _stationBlocksCount;
    public int MinShieldsCount => _minShieldsCount;
    public int MaxShieldsCount => _maxShieldsCount;
    public bool IsLevelComplete => _isLevelComplete;
    public bool IsLevelFullyComplete => _isLevelFullyComplete;

    private bool _isLevelComplete = false;
    private bool _isLevelFullyComplete = false;

    public void CompleteLevel()
    {
        _isLevelComplete = true;
    }

    public void CompleteLevelFully()
    {
        _isLevelFullyComplete = true;
    }
}
