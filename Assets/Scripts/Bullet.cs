using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gold.Interfaces;

public class Bullet : MonoBehaviour {
	[SerializeField] private Rigidbody2D rb2D;
	[SerializeField] private SpriteRenderer sprite;
	public DamageData damage;
	public float life;

	private void OnTriggerEnter2D(Collider2D other)
	{
		IDamageable damageable = other.GetComponent<IDamageable>();
		if(damageable != null)
		{
			damageable.Damage(damage);
			gameObject.SetActive(false);
		}
	}

	public void Setup(Vector2 positon, Vector2 velocity, string layer, Color color)
	{
		transform.position = positon;
		rb2D.velocity = velocity;
		gameObject.layer = LayerMask.NameToLayer(layer);
		sprite.color = color;
	}

	public void Fire()
	{
		gameObject.SetActive(true);
		Invoke("Kill", life);
	}

	void Kill()
	{
		gameObject.SetActive(false);
	}
}
