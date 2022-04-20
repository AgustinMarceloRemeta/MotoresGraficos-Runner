using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    public float Velocity;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        rb.AddRelativeForce(0, 0, -Velocity, ForceMode.Force);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("destroy")) Destroy(gameObject);
    }
}
