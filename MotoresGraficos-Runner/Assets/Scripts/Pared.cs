using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour
{
    public Transform SpawnPared;
    Rigidbody rb;
    public float velocity;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        gameObject.transform.Translate(0, 0, -velocity);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("end")) gameObject.transform.position = SpawnPared.position;
    }
}
