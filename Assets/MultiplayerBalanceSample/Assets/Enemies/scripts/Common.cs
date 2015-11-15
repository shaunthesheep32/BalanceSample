using UnityEngine;
using System.Collections;


    public static class MyContext
    {
        #region  изменяемые значения 
        public static int EnemiesExist = 0;
        public static int EnemiesEscaped = 0;
		public static int EnemiesDestroyed = 0;
		public static float angle = 180;        // начальный угол сканеры (с учетом особенностей 3D-объекта Quad, указываем 180, иначе ставим угол соответсвующий "лицу" объекта (по оси Z) 
		#endregion

        #region константы
        //кол0во врагов чтобы проиграть
        public const float EnemiesEscapedToLose = 10;
        //кол-во врагов чтобы выиграть
        public const float EnemiesDestroyedToWin = 10;
        //враг-куб минимальный порог спавна, сек
        public const float CubeEnemySpawnMin = 5;
        //враг-куб максимальный порог спавна, сек
        public const float CubeEnemySpawnMax = 10;
        //враг-куб минимальный порог жизни, сек
        public const float CubeEnemyLiveMin = 60;
        //враг-куб максимальный порог жизни, сек
        public const float CubeEnemyLiveMax = 100;
        //враг-куб минимальный порог смены состояния
        public const float CubeEnemyChangeStateMin = 1;
        //враг куб максимальный порог смены состояния
        public const float CubeEnemyChangeStateMax = 10;
        //дальность лазера
        public const float MaxLaserDistance = 30;
        //сила прыжка
        public const float JumpPower = 15f;
        //минимальное приближение куба к точке маршрута перед сменой
		public const float MinimumDistance = 10f;
        //точки маршрутов кубов
		public static Vector3[] WayPoints = { new Vector3(15, 0, 5), new Vector3(11, 0, 22.5f), new Vector3(-33, 0, 28), new Vector3(-14, 0, -37), new Vector3(-14.5f, 0, -9.5f), new Vector3(-47.7f, 0, -9.5f), new Vector3(20.3f, 0, 10.1f), new Vector3(26.6f, 7.3f, -21.15f), new Vector3(-3.03f, 4.86f, -21.15f) };
		//параметры сканера кубов-врагов
		public const float rEnemyScan = 15;	// радиус сканера
		public const float stepaside = 1;	// дистанция локатора от носителя
		public const float scanSpeed = .1f;	// скорость сканирования (значения от 0 до 5 -максимум, иначе будет не замечать цель	
	    //пули врагов
		public const float bulletSpeed = 50f;	//скорость полета, значение выше = выше скорость
		public const float bulletLifeTime = 3f;	//время жизни пули в секундах (уничтожается по истечении)
		public const float fireRate = 100f;		//скорострельность, значение ВЫШЕ = скорострельность НИЖЕ
		#endregion
}
