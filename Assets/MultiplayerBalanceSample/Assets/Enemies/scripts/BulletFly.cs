using UnityEngine;
using System.Collections;

public class BulletFly : MonoBehaviour
{

	void Start ()
	{
        var rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * MyContext.bulletSpeed;
		Destroy (this, MyContext.bulletLifeTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
            //Debug.Log("Hit the player");
            MyContext.PlayerHealth -= MyContext.DamagePercent;
			Destroy(this);
		}
	}
}