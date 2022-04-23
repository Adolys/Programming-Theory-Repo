using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        float scaleY = Mathf.PingPong(Time.time, 0.2f); 
        transform.localScale = new Vector3(1.0f, 1.0f + scaleY, 1.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Crate"))
        {
            Debug.Log("Game Over!!!!!");
        }
    }
}
