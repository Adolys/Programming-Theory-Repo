//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GameInstance : Singleton<GameInstance>
{
    protected int characterIndex;

    public GameInstance()
    {
        characterIndex = 0;

        Debug.Log("Call GameInstace constructor!");
    }

    public int GetCharacterIndex()
    {
        return characterIndex;
    }

    public void SetCharacterIndex(int index)
    {
        characterIndex = index;

        Debug.Log("Selected Character Index : " + characterIndex);
    }
}
