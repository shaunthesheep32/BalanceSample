using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{
    LineRenderer line;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StopCoroutine("FireLaser");
            StartCoroutine("FireLaser");
        }
    }

    IEnumerator FireLaser()
    {
        line.enabled = true;

        while (Input.GetButton("Fire1"))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            line.SetPosition(0, ray.origin);

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, MyContext.MaxLaserDistance))
            {
                line.SetPosition(1, hit.point);
                if (hit.transform)
                {
                    if (hit.transform.gameObject.tag == "CubeEnemy")
                    {
                        if (hit.transform.gameObject.GetComponent<Renderer>().material.name.Contains("Normal"))
                        {
                            Destroy(hit.transform.gameObject);
                            MyContext.EnemiesDestroyed++;
                            MyContext.EnemiesExist--;
                        }
                    }
                }
            }
            else
				line.SetPosition(1, Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(MyContext.MaxLaserDistance));

            yield return null;
        }

        line.enabled = false;
    }
}
