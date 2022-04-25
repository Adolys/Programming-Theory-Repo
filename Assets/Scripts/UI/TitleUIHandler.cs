using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TitleUIHandler : MonoBehaviour
{
    public TextMeshProUGUI clickText;
    public Button startButton;

    private void Start()
    {
        if(startButton != null)
        {
            startButton.onClick.AddListener(OnClick_Start);
        }
    }

    private void LateUpdate()
    {
        if(clickText != null)
        {
            float alpha = Mathf.PingPong(Time.time, 1.0f);
            clickText.alpha = alpha;
        }
    }

    public void OnClick_Start()
    {
        SceneManager.LoadScene(1);
    }
}
