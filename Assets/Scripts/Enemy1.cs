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

        if (collision.gameObject.CompareTag("Player2") && !Player.isInvincible)
        {
            Player2.lives -= 1;

            if (Player2.lives == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Player2.lives = 3;
                Player2.score = 0;
                Player2.isInvincible = false;
            }
            else
            {
                StartCoroutine(Player2InvincibleCoroutine());
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

    private IEnumerator Player2InvincibleCoroutine()
    {
        Player2.isInvincible = true;
        Camera.main.GetComponent<CameraShake>().Shake();

        for (int i = 0; i < Player2.blinkCount; i++)
        {
            Player2.spriteRenderer.enabled = !Player2.spriteRenderer.enabled;
            yield return new WaitForSeconds(Player2.invincibilityTime / Player2.blinkCount);
        }

        Player2.spriteRenderer.enabled = true;
        Player2.isInvincible = false;
    }
}
