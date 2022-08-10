using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyNavMesh : MonoBehaviour {
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private bool activeBoolAgro;
    private int index;
    private float PlayerPos;
    public float a;
    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start() {
        navMeshAgent.SetDestination(waypoints[0].position);
        playerTransform = FindObjectOfType<PlayerRB>().transform;
    }


    void Update() {
        EnemyGoNavMesh();
        EnemyPatrol();
        PlayerPos = Vector3.Distance(transform.position, playerTransform.position);
        if (PlayerPos <= 3f) {
            a += Time.deltaTime;
            if (a >= 2f) {
                DamagePlayer();
                a = 0f;

            }
        } else {

            a = 0f;
        }
    }

    private void EnemyPatrol() {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && activeBoolAgro == false) {
            Invoke("StartEnemyPatrol", 3f);

        }
    }
    private void StartEnemyPatrol() {
        index = (index + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[index].position);
    }
    public void DamagePlayer() {

        FindObjectOfType<HealseObjects>().DamageObj(1);


    }



    public void EnemyGoNavMesh() {

        if (PlayerPos <= 10f) {
            activeBoolAgro = true;
            navMeshAgent.SetDestination(playerTransform.position);


        } else {

            activeBoolAgro = false;

        }

    }



}
