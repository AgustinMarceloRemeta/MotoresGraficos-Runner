using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager manager;
    Rigidbody rb;
    public float VelocityPlayer, ForceJump;
    private bool TouchMap = true;
    Transform spawm;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        manager = FindObjectOfType<GameManager>();
        spawm = GameObject.FindGameObjectWithTag("spawn").transform;
    }

    private void FixedUpdate()
    {
   
        if (Input.GetKey("a")) rb.AddRelativeForce(-VelocityPlayer, 0, 0, ForceMode.Force);    
        if (Input.GetKey("d")) rb.AddRelativeForce(VelocityPlayer, 0, 0, ForceMode.Force);
        if (Input.GetKey(KeyCode.Space) && TouchMap) { rb.AddRelativeForce(0, ForceJump, 0, ForceMode.Impulse);
            TouchMap = false;
        }    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
            TouchMap = true;
        if (collision.gameObject.CompareTag("enemy")) manager.Muerte();
        if (collision.gameObject.CompareTag("Limit")) manager.Muerte();
        if (collision.gameObject.CompareTag("money")) { 
            manager.MoreScore();
            Destroy(collision.gameObject);
        }

    }
    void Update()
    {
        
    }
    public void TpSpawn()
    {
        transform.position = spawm.position;
    }
}
