using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	[System.Serializable]
	struct EnemySpawn
	{
		public GameObject prefab;
		public float spawnRate;
	}

	[SerializeField] private EnemySpawn[] enemyTypes;
	[SerializeField] private List<GameObject> enemys;


	public float spawnTime;
	public BoxCollider2D spawnArea;

	private void Start()
	{
		Invoke("Spawn", spawnTime);
	}

	void Spawn()
	{
		foreach (var item in enemyTypes)
		{
			if(Random.Range(0f,1f) < item.spawnRate)
			{
				Vector3 pos = new Vector3(
					Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
					Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y));

				Quaternion quat = new Quaternion();
				quat.eulerAngles = new Vector3(0,0,180);

				enemys.Add(Instantiate(item.prefab, pos, quat));
			}
		}

		Invoke("Spawn", spawnTime);
	}

	public void KillAll()
	{
		foreach (var item in enemys)
		{
			enemys.Remove(item);
			Destroy(item.gameObject);
		}
	}

}
