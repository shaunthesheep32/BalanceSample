using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {
    public GameObject[] objes;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnSequence());
    }
	
    private GameObject GetObjectToSpawn()
    {
        if (objes.Length > 0)
            return objes[Random.Range(0, objes.Length)];
        return null;
    }

    IEnumerator SpawnSequence()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(MyContext.CubeEnemySpawnMin, MyContext.CubeEnemySpawnMax));
            var obj = GetObjectToSpawn();
            obj = (GameObject)Instantiate(obj, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            MyContext.EnemiesExist++;
            yield return new WaitForSeconds(Random.Range(MyContext.CubeEnemyLiveMin, MyContext.CubeEnemyLiveMax));
            if (obj != null)
            {

                Destroy(obj);
                MyContext.EnemiesExist--;
                MyContext.EnemiesEscaped++;
            }
        }
    }
}
