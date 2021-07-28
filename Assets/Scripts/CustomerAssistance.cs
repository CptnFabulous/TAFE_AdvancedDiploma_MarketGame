using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAssistance : MonoBehaviour
{
    public float detectionRadius = 2;
    public Customer currentCustomer;

    public Transform detectionArrow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Customer closestCustomer = null;
        float distance = float.MaxValue;
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            Customer c = colliders[i].GetComponentInParent<Customer>();
            if (c != null && Vector3.Distance(c.transform.position, transform.position) < distance)
            {
                closestCustomer = c;
                distance = Vector3.Distance(c.transform.position, transform.position);
            }
        }

        if (closestCustomer != null && closestCustomer.satisfied == false && currentCustomer == null)
        {
            // Show detection arrow
            detectionArrow.gameObject.SetActive(true);
            detectionArrow.LookAt(closestCustomer.transform.position, transform.up);
            
            if (Input.GetButtonDown("Jump"))
            {
                // Interact with customer
                currentCustomer = closestCustomer;
                currentCustomer.assistant = this;
            }
        }
        else
        {
            detectionArrow.gameObject.SetActive(false);
        }


        

        if (currentCustomer != null)
        {
            Collider[] stalls = Physics.OverlapSphere(transform.position, detectionRadius);
            for (int i = 0; i < stalls.Length; i++)
            {
                // If the player is close enough to a stall that has the customer's desired purchase in stock
                Stall stall = stalls[i].GetComponentInParent<Stall>();
                if (stall != null && Vector3.Distance(stall.transform.position, transform.position) < stall.distanceReachedThreshold && stall.fruitSelling == currentCustomer.desiredPurchase && stall.inventory > 0)
                {
                    FinishProcessingCustomer(stall);

                    
                }
            }
        }
    }

    void FinishProcessingCustomer(Stall stall)
    {
        currentCustomer.Satisfied();
        currentCustomer = null;

        //stall.inventory -= 1;

        FindObjectOfType<ScoreHandler>().IncreaseScore(1);
    }
}
