using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject prefab;
	public int count = 20;

	private void Start()
	{
		for( int i = 0; i < count; i++ )
			Instantiate( prefab, transform.position, Quaternion.identity );
	}
}
