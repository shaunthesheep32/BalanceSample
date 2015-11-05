using UnityEngine;
using System.Collections;

public class HudScript : MonoBehaviour {

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 30), "Enemies Exist: " + MyContext.EnemiesExist);
        GUI.Label(new Rect(10, 40, 200, 30), "Enemies Destroyed: " + MyContext.EnemiesDestroyed);
        GUI.Label(new Rect(10, 70, 200, 30), "Enemies Escaped: " + MyContext.EnemiesEscaped);
    }
    void Update()
    {
        if (MyContext.EnemiesDestroyed == 10)
            Application.LoadLevel("Win");
        if (MyContext.EnemiesEscaped == 10)
            Application.LoadLevel("GameOver");

    }
}
