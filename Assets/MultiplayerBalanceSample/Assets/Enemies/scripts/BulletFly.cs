using UnityEngine;
using System.Collections;

public class BulletFly : MonoBehaviour
{

	public GameObject bullet;

	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * MyContext.bulletSpeed;
		Destroy (bullet, MyContext.bulletLifeTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log("Hit the player");
			Destroy(bullet);
		}
	}
}