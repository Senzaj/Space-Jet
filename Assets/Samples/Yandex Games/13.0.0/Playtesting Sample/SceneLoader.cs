using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    private Button _prevSceneButton;

    private void OnEnable()
    {
        _prevSceneButton = GetComponent<Button>();
        _prevSceneButton.onClick.AddListener(OnPrevSceneButtonClick);
    }

    private void OnDisable()
    {
        _prevSceneButton.onClick.RemoveListener(OnPrevSceneButtonClick);
    }

    private void OnPrevSceneButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
