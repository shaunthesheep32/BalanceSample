using UnityEngine;
using System.Collections;

// имитирует локатор, вращая вокруг носителя объект типа Quad (с учетом односторонней отрисовки)
// скрип закгружать в объект Quad, а сам объект  бросать в Child-ы к носителю

public class EnemyLocator : MonoBehaviour 
{
	LineRenderer line;
	Vector3 pPos;
	public GameObject parentObject;
	public GameObject targetObject;
	private Ray locator;
	private RaycastHit hit;
	private bool search;

	void Start ()
	{
		line = gameObject.GetComponent<LineRenderer>();
		line.enabled = true; // врубаем тру и наблюдаем луч сканера
		search = true;		// можно убрать, т.к. по умолчанию юнька все булы считает трушными (но для тестов пусть пока полежит здесь)
	}
	
	void Update ()
	{
		if (search) {
			ScanSpace ();
		} else {
			TrackingTarget ();
		}
	}

	void ScanSpace()
	{
		// в direction переписываем готовые координаты X и Z, идя по радиусу rEnemyScan
		pPos = parentObject.transform.position;	// отсутп от родителя
		Vector3 pos = new Vector3((Mathf.Sin (MyContext.angle * Mathf.Deg2Rad) * MyContext.stepaside) + pPos.x, transform.position.y, (Mathf.Cos (MyContext.angle * Mathf.Deg2Rad) * MyContext.stepaside) + pPos.z);
		transform.position = pos;
		Quaternion rot = Quaternion.Euler(0, MyContext.angle, 0); transform.rotation = rot;
		locator = new Ray (transform.position, -transform.forward);
		line.SetPosition (0, locator.origin);

		if (Physics.Raycast (transform.position, -transform.forward, out hit, MyContext.rEnemyScan) && hit.transform.gameObject.tag == "Player") 
		{
			targetObject = hit.transform.gameObject;
			search = false;
			return;
		} else 
		{
			line.SetPosition (1, locator.GetPoint (MyContext.rEnemyScan));
			if (MyContext.angle >= 359) {MyContext.angle = 0;} else MyContext.angle += MyContext.scanSpeed; // скидываем угол на 0 при 359 градусах
		}

	}
	void TrackingTarget()
	{
		// ЭТОТ КОД ТРЕБУЕТ ДОРАБОТКИ (или замены).
		pPos = parentObject.transform.position;	// отсутп от родителя
		Vector3 pos = new Vector3((Mathf.Sin (MyContext.angle * Mathf.Deg2Rad) * MyContext.stepaside) + pPos.x, transform.position.y, (Mathf.Cos (MyContext.angle * Mathf.Deg2Rad) * MyContext.stepaside) + pPos.z);
		transform.position = pos;
		Quaternion rot = Quaternion.Euler(0, MyContext.angle, 0); transform.rotation = rot;
		locator = new Ray (transform.position, -transform.forward);
		line.SetPosition (0, locator.origin);
		line.SetPosition (1, targetObject.GetComponent<Transform>().position);

	}
}