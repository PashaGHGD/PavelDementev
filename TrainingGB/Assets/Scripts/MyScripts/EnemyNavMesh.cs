using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyNavMesh : MonoBehaviour {
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform[] waypoints;
    private int index;
    [SerializeField] private bool activeBoolAgro;
    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start() {
        navMeshAgent.SetDestination(waypoints[0].position);
        playerTransform = GameObject.FindObjectOfType<PlayerMove>().transform;
    }


    void Update() {
        EnemyGoNavMesh();
        EnemyPatrol();
    }

    private void EnemyPatrol() {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && activeBoolAgro == false) {
            index = (index + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[index].position);

        }
    }
    public void EnemyGoNavMesh() {
        float PlayerPos = Vector3.Distance(transform.position, playerTransform.position);
        if (PlayerPos <= 10f) {
            activeBoolAgro = true;
            navMeshAgent.SetDestination(playerTransform.position);

        } else {
          //  navMeshAgent.ResetPath();
            activeBoolAgro = false;

        }

    }

    //public Transform playerTransform;

    //[SerializeField] private NavMeshAgent navMeshAgent;
    //[SerializeField] private Transform[] waypoints;
    //private int index;
    //[SerializeField] private bool activeBoolAgro;

    //void Start() {
    //    navMeshAgent.SetDestination(waypoints[0].position);

    //}


    //void Update() {
    //    Patrol();
    //    Agro();
    //}

    //private void Patrol() {
    //    if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && activeBoolAgro == false) {
    //        index = (index + 1) % waypoints.Length;
    //        navMeshAgent.SetDestination(waypoints[index].position);

    //    }
    //}
    //private void Agro() {
    //    float distance = Vector3.Distance(playerTransform.position, transform.position);

    //    if (distance <= 10f) {
    //        activeBoolAgro = true;
    //    } else {
    //        activeBoolAgro = false;
    //    }

    //    if (distance <= 10f) {
    //        navMeshAgent.SetDestination(playerTransform.position);
    //    }

    //}


}
