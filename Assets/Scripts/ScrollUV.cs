using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour {
	public MeshRenderer meshRenderer;
	public float speed;
	public Vector2 offset;
	private void Update()
	{
		offset.y += speed * Time.deltaTime;
		meshRenderer.material.SetTextureOffset("_MainTex", offset);
	}
}
