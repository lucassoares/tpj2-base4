using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerHud : MonoBehaviour
{
	public Image life1;
	public Image life2;
	public Image life3;

    public Image life4;
    public Image life5;
    public Image life6;

    public Text scoreText;

    public Text scoreText2;

    private void Update()
	{
		life1.enabled = Player.lives >= 1;
		life2.enabled = Player.lives >= 2;
		life3.enabled = Player.lives >= 3;

        life4.enabled = Player2.lives >= 1;
        life5.enabled = Player2.lives >= 2;
        life6.enabled = Player2.lives >= 3;

        scoreText.text = string.Format( "Score1: {0}", Player.score );

        scoreText2.text = string.Format("Score2: {0}", Player2.score);
    }
}
