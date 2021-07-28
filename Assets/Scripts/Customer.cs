using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Customer : MonoBehaviour
{
    NavMeshAgent na;
    
    public Fruit desiredPurchase;
    public bool satisfied;

    public CustomerAssistance assistant;
    public float stayCloseThreshold = 2;
    public Transform fruitIcon;


    private void Awake()
    {
        na = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (satisfied == false)
        {
            ShowProductIndicator();
        }
    }

    void ShowProductIndicator()
    {
        Debug.Log("Setting up icon");
        GameObject icon = Instantiate(desiredPurchase.model, fruitIcon.position, Quaternion.identity, transform);
        Destroy(fruitIcon.gameObject);
        fruitIcon = icon.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (assistant != null)
        {
            if (Vector3.Distance(transform.position, assistant.transform.position) > stayCloseThreshold)
            {
                na.isStopped = false;
                na.SetDestination(assistant.transform.position);
            }
            else
            {
                na.isStopped = true;
            }
        }

        if (satisfied == true)
        {
            
        }
    }

    private void LateUpdate()
    {
        fruitIcon.LookAt(Camera.main.transform.position, Camera.main.transform.up);
    }

    public void Satisfied()
    {
        satisfied = true;
        fruitIcon.gameObject.SetActive(false);
        assistant = null;
        gameObject.SetActive(false);
    }
}
