﻿using UnityEngine;
using System.Collections;
using Assets.Scripts.Utils.GameEvents;

// имитирует локатор, вращая вокруг носителя объект типа Quad (с учетом односторонней отрисовки)
// скрип закгружать в объект Quad, а сам объект  бросать в Child-ы к носителю

public class EnemyLocator : CommandMonoBehaviour 
{
	LineRenderer line;
	Vector3 pPos;
	public GameObject parentObject;
	public GameObject targetObject;
	public GameObject bullet;
	public Transform BulletSpawn;
	private Ray locator;
	private RaycastHit hit;
	private bool search;
	private float delayFire;
    private float angle = MyContext.angle;

	void Start ()
	{
		line = gameObject.GetComponent<LineRenderer>();
		line.enabled = true; // врубаем тру и наблюдаем луч сканера
		search = true;		// можно убрать, т.к. по умолчанию юнька все булы считает трушными (но для тестов пусть пока полежит здесь)
	}
	
	void FixedUpdate ()
	{
		if (search) {
            ScanSpace ();
		} else {
			//публикуем в шину сообщение об обнаружении игрока - зовём другие кубы
			EventAggregator.PlayerDetected.Publish(new GameEventArgs<Vector3>(targetObject.transform.position));

            //проверяем дальность - если вышли за пределы видимости. то опять начинаем поиск
            var distance = Vector3.Distance(transform.position, targetObject.transform.position);
            if (distance <= MyContext.rEnemyScan)
                TrackingTarget();
            else
                search = true;
		}


    }

	void ScanSpace()
	{
		// в direction переписываем готовые координаты X и Z, идя по радиусу rEnemyScan
		pPos = parentObject.transform.position;	// отсутп от родителя
		Vector3 pos = new Vector3((Mathf.Sin (angle * Mathf.Deg2Rad) * MyContext.stepaside) + pPos.x, transform.position.y, (Mathf.Cos (angle * Mathf.Deg2Rad) * MyContext.stepaside) + pPos.z);
		transform.position = pos;
		Quaternion rot = Quaternion.Euler(0, angle, 0);
        transform.rotation = rot;
		locator = new Ray (transform.position, transform.forward);
		line.SetPosition (0, locator.origin);
        //если во чтото попали
        if (Physics.Raycast(transform.position, transform.forward, out hit, MyContext.rEnemyScan))
        {
            //если попали в игрока, то держим на нём взгляд
            if (hit.transform.gameObject.tag == "Player")
            {
                targetObject = hit.transform.gameObject;
                search = false;
                return;
            }
            //иначе обрубаем луч на первом коллаедре
            else
                line.SetPosition(1, hit.point);
        }
        //если не попали
        else
            line.SetPosition(1, locator.GetPoint(MyContext.rEnemyScan));

        //прибавляем угол
	    if (angle >= 359) {angle = 0;} else angle += MyContext.scanSpeed; // скидываем угол на 0 при 359 градусах
		

	}
	void TrackingTarget()
	{        
        pPos = parentObject.transform.position; // отсутп от родителя
        //вычисляем направление от куба до игрока - вычитание векторов
        Vector3 direction = targetObject.transform.position - pPos;
        var locator = new Ray(pPos, direction);
        //находим точку, куда ставить локатор 
        transform.position = locator.GetPoint(MyContext.stepaside);
        //поворачиваем локатор на игрока
        transform.rotation = Quaternion.LookRotation(direction);
        //пересчитываем угол
        angle = 180;// Vector3.Angle(parentObject.transform.forward, direction)*Mathf.Rad2Deg;

        //проверяем видимость игрока - если видим - направляем луч на него
        if (Physics.Raycast(transform.position, direction, out hit, MyContext.rEnemyScan) && (hit.transform.gameObject.tag == "Player"))
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, new Vector3(targetObject.transform.position.x, transform.position.y, targetObject.transform.position.z));
		    // --- F I R E --- //
			if (delayFire == 0) {
                //порождаем пулю в BulletSpawn и выбираем вектор куда "смотрит" куб
                if (Vector3.Angle(new Vector3(BulletSpawn.transform.up.x,0, BulletSpawn.transform.up.z), new Vector3(direction.x, 0, direction.z)) <= MyContext.AngleToShoot)
                {
                    Instantiate(bullet, new Vector3(BulletSpawn.position.x, BulletSpawn.position.y, BulletSpawn.position.z), Quaternion.LookRotation(BulletSpawn.transform.up));
                    delayFire = MyContext.fireRate;
                }
			} else {delayFire -= Time.timeScale;}
		}
        //потеряли цель
        else
            search = true;       
	}
}