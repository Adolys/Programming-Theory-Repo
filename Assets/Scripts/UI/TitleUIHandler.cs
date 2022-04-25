using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class TitleUIHandler : MonoBehaviour
{
    public TextMeshProUGUI clickText;
    public Button startButton;

    private void Start()
    {
        if(startButton)
        {
            startButton.onClick.AddListener(OnClick_Start);
        }

        if(clickText)
        {
            clickText.DOFade(0.0f, 1.0f).SetLoops(-1, LoopType.Yoyo);
        }
    }

    public void OnClick_Start()
    {
        SceneManager.LoadScene(1);
    }
}
