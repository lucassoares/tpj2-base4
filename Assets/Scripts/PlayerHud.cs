using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerHud : MonoBehaviour
{
	public Image life1;
	public Image life2;
	public Image life3;

	public Text scoreText;

	private void Update()
	{
		life1.enabled = Player.lives >= 1;
		life2.enabled = Player.lives >= 2;
		life3.enabled = Player.lives >= 3;

		scoreText.text = string.Format( "Score: {0}", Player.score );
	}
}
