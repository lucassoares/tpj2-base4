using System.Collections;
using UnityEngine;

public sealed class Player2 : MonoBehaviour
{
	public static int score = 0;
	public static int lives = 3;
	public static int blinkCount = 9;
	public static float invincibilityTime = 2.0f;
	public static bool isInvincible = false;

	public static Renderer spriteRenderer;

	public Renderer playerRenderer;
	public Rigidbody2D playerRigidbody;

    public string verticalKeyboard;
    public string horizontalKeyboard;

    private void Awake()
	{
        score = 0;
        lives = 3;
        spriteRenderer = playerRenderer;

		StartCoroutine( UpdateScore() );
	}

	private void Update()
	{
		float moveX = Input.GetAxis( horizontalKeyboard );
		float moveY = Input.GetAxis( verticalKeyboard );

		Vector3 position = playerRigidbody.position;
		position.x += moveX * 5.0f * Time.deltaTime;
		position.y += moveY * 5.0f * Time.deltaTime;
		playerRigidbody.position = position;
	}

	private IEnumerator UpdateScore()
	{
		while( true )
		{
			yield return new WaitForSeconds( 1.0f );
			score += 10;
		}
	}
}
