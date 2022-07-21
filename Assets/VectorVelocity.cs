using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorVelocity : MonoBehaviour
{
    private Vector3 vector3;
    private Rigidbody rb;
    private GameObject obj;

    private Vector3 push;

    public float velocity = 7.5f;

    void OnEnable()
    {      
        rb = GetComponent<Rigidbody>();
        push = new Vector3(0, 0, 0);
        push = transform.forward * velocity;
        rb.AddForce(push * 50);
    }

    void Update()
    {
        vector3 = rb.velocity;
        rb.transform.forward = vector3;
        Debug.Log("Velocity: " + rb.velocity.magnitude);
    }

    private void OnCollisionEnter(Collision collision)
    {        
        Bounce(collision.contacts[0].normal);
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var direction = Vector3.Reflect(vector3.normalized, collisionNormal);

        Debug.Log("Reflected Direction: " + direction);
        rb.velocity = direction * velocity;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        //obj = GameObject.Find("Cart");
        Gizmos.DrawRay(rb.position, rb.velocity);

        Gizmos.color = Color.black;
        obj = GameObject.Find("Middle_pillar");
        Vector3 line = obj.transform.position - rb.position;
        Gizmos.DrawRay(rb.position, line);
    }
}
