using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Enemy1 : MonoBehaviour
{
	public Rigidbody2D enemyRigidbody;

	private void Update()
	{
		const float screenMaxX = 12.0f;
		const float screenMaxY = 5.0f;

		Vector3 position = enemyRigidbody.position;
		position.x -= 4.0f * Time.deltaTime;

		if( position.x < -screenMaxX )
		{
			position.x = screenMaxX + Random.Range( 0.0f, screenMaxX * 2 );
			position.y = Random.Range( -screenMaxY, screenMaxY );
		}

		enemyRigidbody.position = position;
	}

	private void OnCollisionEnter2D( Collision2D collision )
	{
		if( collision.gameObject.CompareTag( "Player" ) && !Player.isInvincible )
		{
			Player.lives -= 1;

			if( Player.lives == 0 )
			{
				SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
				Player.lives = 3;
				Player.score = 0;
				Player.isInvincible = false;
			}
			else
			{
				StartCoroutine( PlayerInvincibleCoroutine() );
			}
		}
	}

	private IEnumerator PlayerInvincibleCoroutine()
	{
		Player.isInvincible = true;
		Camera.main.GetComponent<CameraShake>().Shake();

		for( int i = 0; i < Player.blinkCount; i++ )
		{
			Player.spriteRenderer.enabled = !Player.spriteRenderer.enabled;
			yield return new WaitForSeconds( Player.invincibilityTime / Player.blinkCount );
		}

		Player.spriteRenderer.enabled = true;
		Player.isInvincible = false;
	}
}
