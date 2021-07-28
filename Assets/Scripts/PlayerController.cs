using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;


    public float movementSpeed = 5;
    Vector3 movementValues;

    public Transform model;

    private void Awake()
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
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        float vertical = Input.GetAxis("Vertical") * movementSpeed;
        movementValues = new Vector3(horizontal, 0, vertical);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movementValues * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        model.LookAt(model.transform.position + movementValues, transform.up);
    }
}
