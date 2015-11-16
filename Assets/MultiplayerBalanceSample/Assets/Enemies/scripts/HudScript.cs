using UnityEngine;
using System.Collections;

public class HudScript : MonoBehaviour {

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 30), "Enemies Exist: " + MyContext.EnemiesExist);
        GUI.Label(new Rect(10, 40, 200, 30), "Enemies Destroyed: " + MyContext.EnemiesDestroyed);
        GUI.Label(new Rect(10, 70, 200, 30), "Enemies Escaped: " + MyContext.EnemiesEscaped);
        GUI.Label(new Rect(10, 100, 200, 30), "Health: " + MyContext.PlayerHealth);
    }
    void Update()
    {
        if (MyContext.EnemiesDestroyed == MyContext.EnemiesDestroyedToWin)
            Application.LoadLevel("Win");
        if ((MyContext.EnemiesEscaped == MyContext.EnemiesEscapedToLose)||(MyContext.PlayerHealth<=0))
            Application.LoadLevel("GameOver");

    }
}
