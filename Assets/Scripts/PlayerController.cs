using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private Vector3 movementDirection;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float inputSide = Input.GetAxis("Horizontal");
        float inputForward = Input.GetAxis("Vertical");

        Vector3 sideMovement = transform.right;
        sideMovement *= (inputSide * Speed * Time.deltaTime);
        
        Vector3 forwardMovement = transform.forward;
        forwardMovement *= (inputForward * Speed * Time.deltaTime);

        movementDirection = sideMovement + forwardMovement;

        transform.position += movementDirection;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Faça o personagem pular
            rb.AddForce(Vector3.up * JumpForce);
        }

    }
}
