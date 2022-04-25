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

    public List<Button> selectButtons;

    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < selectButtons.Count; i++)
        {
            int index = i;
            selectButtons[i].onClick.AddListener(delegate { OnClick_SelectButton(index); });
        }

        selectButtons[GameInstance.Instance.GetCharacterIndex()].Select();

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
