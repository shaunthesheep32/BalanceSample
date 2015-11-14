using UnityEngine;
using System.Collections;
using Assets.Scripts.Utils.GameEvents;
using System;

public class CubeEnemyBeh : CommandMonoBehaviour {
    private bool resist = false;

    public Material normalStateMaterial;
    public Material resistStateMaterial;

    // Use this for initialization
    void Start () {
        StartCoroutine(ChangeState());
    }

    // Update is called once per frame
    void Update () {
        if (resist)
            GetComponent<Renderer>().material = resistStateMaterial;
        else
            GetComponent<Renderer>().material = normalStateMaterial;
    }

    IEnumerator ChangeState()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(MyContext.CubeEnemyChangeStateMin, MyContext.CubeEnemyChangeStateMax));
            resist = !resist;
        }
    }
}
