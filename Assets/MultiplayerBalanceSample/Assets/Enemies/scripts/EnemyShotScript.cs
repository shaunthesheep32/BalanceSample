using UnityEngine;
using System.Collections;

public class EnemyShotScript : MonoBehaviour {

    public GameObject projectile;
    private float initialSpeed = 200.0f;
    private float reloadTime = 0.5f;
    private float ammoCount = 20f;
    private float lastShot = -10.0f;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
        //// Did the time exceed the reload time?
        //if ((Time.time > reloadTime + lastShot) && (ammoCount > 0))
        //{
        //    GameObject instantiatedProjectile = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
        //    instantiatedProjectile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, initialSpeed));
        //    lastShot = Time.time;
        //    ammoCount--;
        //}
        //{
        //    // create a new projectile, use the same position and rotation as the Launcher.
        //    var instantiatedProjectile : Rigidbody = Instantiate(projectile, transform.position, transform.rotation);

        //    // Give it an initial forward velocity. The direction is along the z-axis of the missile launcher's transform.
        //    instantiatedProjectile.velocity = transform.TransformDirection(Vector3(0, 0, initialSpeed));

        //    // Ignore collisions between the missile and the character controller
        //    Physics.IgnoreCollision(instantiatedProjectile.collider, transform.root.collider);

        //    lastShot = Time.time;
        //    ammoCount--;
        //}
    }
}
