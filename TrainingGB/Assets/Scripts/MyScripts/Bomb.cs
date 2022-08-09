using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float radius = 10f;
    [SerializeField] private float explosionForce = 10f;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (var hitCollider in hitColliders) {
                if (hitCollider.TryGetComponent<Rigidbody>(out Rigidbody hitRigidbody)) {
                    hitRigidbody.AddRelativeForce((hitRigidbody.position - transform.position) * explosionForce);
                }
            }

        }
            //Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            //foreach (var hitCollider in hitColliders) {
            //    if (hitCollider.TryGetComponent<Rigidbody>(out Rigidbody hitRigidbody)) {
            //        hitRigidbody.AddRelativeForce((hitRigidbody.position - transform.position) * explosionForce);
            //    }
            //}
          //  Destroy(gameObject);
        
    }
}
