using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gold.Interfaces;

public class Killzone : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other)
	{
		IDamageable damageable = other.GetComponent<IDamageable>();
		if(damageable != null)
		{
			DamageData hit = new DamageData(1);
			hit.killInstantly = true;
			damageable.Damage(hit);
		}
	}
}
