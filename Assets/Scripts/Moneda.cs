using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    Rigidbody rb;
    public float Velocity;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {
        gameObject.transform.Rotate(1, 1, 1);
        rb.AddForce(0, 0, -Velocity, ForceMode.Force);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("destroy")) Destroy(gameObject);
    }
}
