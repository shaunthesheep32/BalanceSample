using UnityEngine;
using System.Collections;

/*
 * этот скрипт грузим в объект врага
 * он отрисует линию (Ray) к игроку, как только тот окажется на указанной дистанции
 * ВНИМАНИЕ! дистанция указывается с учетом хитрой системы sqrMagnitude, где одна единица != одной единице расстояния на сцене!
*/
public class InstantlyDetectorPlayer : MonoBehaviour 
{
	LineRenderer line;
	GameObject[] gos;
	RaycastHit hit;

	void Start () 
	{
		gos = GameObject.FindGameObjectsWithTag ("Player");
		line = gameObject.GetComponent<LineRenderer>();

	}
	void Update()
	{
		foreach (GameObject go in gos) 
		{
			Vector3 diff = go.transform.position - transform.position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < 60) 
			{
                //проверяем видимость
                if (Physics.Raycast(transform.position, diff, out hit, 60) && (hit.transform.gameObject.tag == "Player"))
                {
                    line.enabled = true;
                    Ray locator = new Ray(transform.position, go.transform.position);
                    line.SetPosition(0, locator.origin);
                    line.SetPosition(1, go.transform.position);
                    return;
                }
			}

		}
        line.enabled = false;
	}
}