using System.Collections;
using UnityEngine;

public sealed class Player : MonoBehaviour
{
	public static int score = 0;
	public static int lives = 3;
	public static int blinkCount = 9;
	public static float invincibilityTime = 2.0f;
	public static bool isInvincible = false;

	public static Renderer spriteRenderer;

	public Renderer playerRenderer;
	public Rigidbody2D playerRigidbody;

	private void Awake()
	{
		spriteRenderer = playerRenderer;

		StartCoroutine( UpdateScore() );
	}

	private void Update()
	{
		float moveX = Input.GetAxis( "Horizontal" );
		float moveY = Input.GetAxis( "Vertical" );

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
