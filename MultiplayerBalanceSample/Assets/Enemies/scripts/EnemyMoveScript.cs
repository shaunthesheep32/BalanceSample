using UnityEngine;
using System.Collections;

public class EnemyMoveScript : MonoBehaviour {
    
    private NavMeshAgent agent;
    private Vector3 currentDestination;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        currentDestination = MyContext.WayPoints[Random.Range(0, MyContext.WayPoints.Length-1)];
        agent.SetDestination(currentDestination);
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, currentDestination) <= MyContext.MinimumDistance)
        {
            currentDestination = MyContext.WayPoints[Random.Range(0, MyContext.WayPoints.Length)];
            agent.SetDestination(currentDestination);
        }        
    }
}
