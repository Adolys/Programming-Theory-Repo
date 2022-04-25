using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody characterRb;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        characterRb = GetComponent<Rigidbody>();
        if(characterRb == null)
        {
            Debug.LogError("Rigidbody is not valid!");
        }

        gameManager = GameObject.FindObjectOfType<GameManager>();
        if(gameManager == null)
        {
            Debug.LogError("Game Manager is not valid!");
        }
    }

    private void LateUpdate()
    {
        if (gameManager.GetGameState() == EGameState.Play)
        {
            float scaleY = Mathf.PingPong(Time.time, 0.2f);
            transform.localScale = new Vector3(1.0f, 1.0f + scaleY, 1.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            gameManager.AddScore();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            if(gameManager.GetGameState() == EGameState.Play)
            {
                characterRb.constraints = RigidbodyConstraints.None;
                characterRb.AddForce(new Vector3(0.0f, 5.0f, -0.5f), ForceMode.Impulse);
            }

            gameManager.SetGameState(EGameState.End);
        }
    }
}
