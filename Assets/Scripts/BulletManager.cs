using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

	[SerializeField] static List<GameObject> _bullets;
	public GameObject bulletPrefab;

	private void Awake()
	{
		_bullets = new List<GameObject>();
	}

	public GameObject GetBullet()
	{
		for(int i = 0; i < _bullets.Count; i++)
		{
			if(!_bullets[i].gameObject.activeInHierarchy)
			{
				return _bullets[i];
			}
		}
		GameObject bullet = Instantiate(bulletPrefab,transform);
		_bullets.Add(bullet);
		return bullet;
	}
}
