using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnit : MonoBehaviour
{
    [SerializeField] protected float m_Speed = 20.0f;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        if(gameManager == null)
        {
            Debug.LogError("Game Manager is not valid!");
        }
    }

    private void LateUpdate()
    {
        if(gameManager.GetGameState() == EGameState.Play)
        {
            OnUnitAction();
        }
    }

    protected virtual void OnUnitAction()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (-m_Speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }
    }
}
