using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameUIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public GameObject gameOverObj;
    public Button restartButton;
    public Button exitButton;

    private void Start()
    {
        restartButton.onClick.AddListener(OnClick_Restart);
        exitButton.onClick.AddListener(OnClick_Exit);
    }

    public void SetScore(int score)
    {
        if(scoreText != null)
        {
            scoreText.SetText("Score : " + score);
        }
    }

    public void ShowGameOver()
    {
        if(gameOverObj)
        {
            gameOverObj.SetActive(true);
        }
    }

    public void OnClick_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClick_Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
