using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private void Update()
    {
        const float screenMaxX = 12.0f;
        const float screenMaxY = 5.0f;

        Vector3 position = transform.position;
        position.x -= 4.0f * Time.deltaTime;

        if( position.x < -screenMaxX)
        {
            position.x = screenMaxX + Random.Range( 0.0f, screenMaxX * 2 );
            position.y = Random.Range(-screenMaxY, screenMaxY);
        }

        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
