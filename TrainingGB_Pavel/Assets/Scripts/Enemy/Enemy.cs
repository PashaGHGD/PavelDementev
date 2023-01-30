using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    private float _distans;
    private bool enabledBool = false;
    void Start()
    {
        playerTransform = FindObjectOfType<InteractiveObjectView>().transform;
    }

 
    void Update()
    {
        _distans = Vector3.Distance(transform.position, playerTransform.position);
        if (_distans<=4) {
            if (enabledBool) {
                var componentAIDestination = GetComponent<AIDestinationSetter>();
                componentAIDestination.enabled = true;
                var componentPatrol = GetComponent<Patrol>();
                componentPatrol.enabled = false;
                enabledBool = false;
            }
            
        } else {
            if (!enabledBool) {
                var componentAIDestination = GetComponent<AIDestinationSetter>();
                componentAIDestination.enabled = false;
                var componentPatrol = GetComponent<Patrol>();
                componentPatrol.enabled = true;
                enabledBool = true;
            }
           

        }




    }
}
