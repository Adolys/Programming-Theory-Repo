using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameState
{
    Ready,
    Play,
    End,
}


public class GameManager : MonoBehaviour
{
    public SpawnManager spawnManager;
    public GameUIHandler uiHandler;

    private EGameState m_State;
    private int m_Score;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnManager == null)
        {
            Debug.LogError("Spawn Manager is not valid!");
        }

        if(uiHandler == null)
        {
            Debug.LogError("UI Handler is not valid!");
        }

        m_Score = 0;
        spawnManager.InitSpawnManager();
        SetGameState(EGameState.Ready);
    }

    public void SetGameState(EGameState state)
    {
        m_State = state;

        switch(m_State)
        {
            case EGameState.Ready:
                spawnManager.isSpawnable = false;
                uiHandler.SetScore(m_Score);

                SetGameState(EGameState.Play);
                break;
            case EGameState.Play:
                spawnManager.isSpawnable = true;
                break;
            case EGameState.End:
                spawnManager.isSpawnable = false;
                uiHandler.ShowGameOver();
                break;
        }
    }

    public EGameState GetGameState()
    {
        return m_State;
    }

    public void AddScore()
    {
        uiHandler.SetScore(++m_Score);
    }
}
