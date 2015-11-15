using UnityEngine;
using System.Collections;

public class BulletWallCollider : MonoBehaviour {
	public GameObject bullet;

	void OnTriggerEnter(Collider bullet)
	{
		Destroy(bullet.gameObject);
	}
}
