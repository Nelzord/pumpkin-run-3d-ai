using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour {

    NavMeshAgent bar;
    public Transform target; 

	// Use this for initialization
	void Start () {
        bar = GetComponent<NavMeshAgent>();
        
	}
	
	// Update is called once per frame
	void Update () {
        bar.SetDestination(target.position);
    }
}
