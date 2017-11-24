using UnityEngine;

public class Player : MonoBehaviour
{
    public static int lives = 3;   

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 position = transform.position;
        position.x += moveX * 5.0f * Time.deltaTime;
        position.y += moveY * 5.0f * Time.deltaTime;
        transform.position = position;
    }
}
