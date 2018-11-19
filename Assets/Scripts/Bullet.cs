using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int childNumber;

    public float radius = 10.0f;
    public float power = 5.0f;
    public float upForce = 1.0f;

    private void OnCollisionEnter(Collision collision)
    {
        Detonate();
        Destroy(gameObject, 0.5f);
    }

    private void Detonate()
    {
        Vector3 explosionPosition = gameObject.transform.position;
        Collider[] collider = Physics.OverlapSphere(explosionPosition, radius);

        foreach(Collider hit in collider)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }
        }
    }
}
