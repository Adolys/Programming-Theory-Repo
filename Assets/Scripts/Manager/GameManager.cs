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
    public List<Character> PlayerPrefabs;

    [SerializeField] private Vector3 startPos = new Vector3(0.0f, 4.3f, 3.5f);
    private EGameState m_State;
    private int m_Score;
    private Character m_SpawnedCharcter;

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

                int playerIndex = GameInstance.Instance.GetCharacterIndex();

                m_SpawnedCharcter = Instantiate(PlayerPrefabs[playerIndex], startPos, PlayerPrefabs[playerIndex].transform.rotation);

                uiHandler.ShowReadyText();

                StartCoroutine(OnReadyGame());
                
                break;
            case EGameState.Play:
                spawnManager.isSpawnable = true;

                if(m_SpawnedCharcter)
                {
                    m_SpawnedCharcter.StartRunning();
                }

                break;
            case EGameState.End:
                spawnManager.isSpawnable = false;
                uiHandler.ShowGameOver();
                break;
        }
    }

    IEnumerator OnReadyGame()
    {
        yield return new WaitForSeconds(3.0f);

        SetGameState(EGameState.Play);
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
