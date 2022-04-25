using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameUIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI readyStartText;

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
            gameOverObj.transform.DOScale(1.0f, 0.3f);
        }
    }

    public void OnClick_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClick_Exit()
    {
        //#if UNITY_EDITOR
        //        EditorApplication.ExitPlaymode();
        //#else
        //        Application.Quit();
        //#endif

        SceneManager.LoadScene(1);
    }

    public void ShowReadyText()
    {
        if(readyStartText)
        {
            readyStartText.SetText("Ready");
            readyStartText.transform.DOScale(Vector3.one, 0.8f).SetEase(Ease.OutFlash).OnComplete(() => 
            { readyStartText.transform.DOScale(Vector3.zero, 0.7f).SetEase(Ease.InFlash).OnComplete(() => ShowStartText()); });
        }
    }

    public void ShowStartText()
    {
        if (readyStartText)
        {
            readyStartText.SetText("Start");
            readyStartText.transform.DOScale(Vector3.one, 0.8f).SetEase(Ease.OutFlash).OnComplete(() => 
            { readyStartText.transform.DOScale(Vector3.zero, 0.7f).SetEase(Ease.InFlash); });
        }
    }
}
