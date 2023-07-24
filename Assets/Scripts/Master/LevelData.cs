using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] private int _levelIndex;
    [SerializeField] private int _stationBlocksCount;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private int _minShieldsCount;
    [SerializeField] private int _maxShieldsCount;
    [SerializeField] private LevelControl _control;

    public int LevelIndex => _levelIndex;
    public int StationBlocksCount => _stationBlocksCount;
    public float RotationSpeed => _rotationSpeed;
    public int MinShieldsCount => _minShieldsCount;
    public int MaxShieldsCount => _maxShieldsCount;
    public bool IsLevelComplete => _isLevelComplete;
    public bool IsLevelFullyComplete => _isLevelFullyComplete;
    public bool IsRewardedVideoWatched => _isRewardedVideoWatched;

    private bool _isRewardedVideoWatched = false;
    private bool _isLevelComplete = false;
    private bool _isLevelFullyComplete = false;

    public void OnRewardedVideoShown()
    {
        _isRewardedVideoWatched = true;
    }

    public string GetLevelNameForVideo()
    {
        return "RewardedVideoLevel" + _levelIndex;
    }

    public void CompleteLevel()
    {
        _isLevelComplete = true;
    }

    public void CompleteLevelFully()
    {
        _isLevelFullyComplete = true;
    }
}
