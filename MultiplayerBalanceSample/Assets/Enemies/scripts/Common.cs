using UnityEngine;
using System.Collections;

public struct MyContext
{
    #region  изменяемые значения 
    public static int EnemiesExist = 0;
    public static int EnemiesEscaped = 0;
    public static int EnemiesDestroyed = 0;
    #endregion

    #region константы
    //враг-куб минимальный порог спавна, сек
    public const float CubeEnemySpawnMin = 5;
    //враг-куб максимальный порог спавна, сек
    public const float CubeEnemySpawnMax = 120;
    //враг-куб минимальный порог жизни, сек
    public const float CubeEnemyLiveMin = 60;
    //враг-куб максимальный порог жизни, сек
    public const float CubeEnemyLiveMax = 100;
    //враг-куб минимальный порог смены состояния
    public const float CubeEnemyChangeStateMin = 1;
    //враг куб максимальный порог смены состояния
    public const float CubeEnemyChangeStateMax = 10;
    //дальность лазера
    public const float MaxLaserDistance = 100;
    #endregion
}