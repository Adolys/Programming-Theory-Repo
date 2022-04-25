using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_Speed = 20.0f;
    [SerializeField] private float maxPositionX = 6.5f;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("Game Manager is not valid!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetGameState() == EGameState.Play)
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(new Vector3(horizontalInput * m_Speed * Time.deltaTime, 0.0f, 0.0f));

            if (transform.position.x < -maxPositionX)
            {
                transform.position = new Vector3(-maxPositionX, transform.position.y, transform.position.z);
            }

            if (transform.position.x > maxPositionX)
            {
                transform.position = new Vector3(maxPositionX, transform.position.y, transform.position.z);
            }
        }
    }
}
