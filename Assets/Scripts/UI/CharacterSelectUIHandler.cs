using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectUIHandler : MonoBehaviour
{
    public Button selectButton1;
    public Button selectButton2;
    public Button selectButton3;
    public Button selectButton4;

    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        selectButton1.onClick.AddListener(delegate { OnClick_SelectButton(0); });
        selectButton2.onClick.AddListener(delegate { OnClick_SelectButton(1); });
        selectButton3.onClick.AddListener(delegate { OnClick_SelectButton(2); });
        selectButton4.onClick.AddListener(delegate { OnClick_SelectButton(3); });

        startButton.onClick.AddListener(OnClick_StartButton);
    }

    public void OnClick_SelectButton(int index)
    {
        GameInstance.Instance.SetCharacterIndex(index);
    }

    public void OnClick_StartButton()
    {
        SceneManager.LoadScene(2);
    }
}
