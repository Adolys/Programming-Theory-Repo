using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 startPos = new Vector3(0.0f, 4.3f, 3.5f);
    [SerializeField] private float m_Speed = 20.0f;
    [SerializeField] private float maxPositionX = 6.5f;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(horizontalInput * m_Speed * Time.deltaTime, 0.0f, 0.0f));

        if(transform.position.x < -maxPositionX)
        {
            transform.position = new Vector3(-maxPositionX, transform.position.y, transform.position.z);
        }

        if (transform.position.x > maxPositionX)
        {
            transform.position = new Vector3(maxPositionX, transform.position.y, transform.position.z);
        }
    }
}
