using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class CustomerSpawner : MonoBehaviour
{
    public Stall[] stalls;
    public Customer prefab;
    public float spawnDelay;
    float spawnTimer;

    public Transform entrance;
    public Transform browseZoneCentre;
    public Vector3 browseZoneExtents = new Vector3(10, 0, 10);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnDelay)
        {
            spawnTimer = 0;
            SpawnCustomer();
        }
    }


    void SpawnCustomer()
    {
        Stall stall = stalls[Random.Range(0, stalls.Length - 1)];
        
        
        Customer customer = Instantiate(prefab, entrance.position, Quaternion.identity);
        customer.desiredPurchase = stall.fruitSelling;


        float x = Random.Range(browseZoneExtents.x, -browseZoneExtents.x);
        float y = Random.Range(browseZoneExtents.y, -browseZoneExtents.y);
        float z = Random.Range(browseZoneExtents.z, -browseZoneExtents.z);
        Vector3 browsePosition = browseZoneCentre.position + new Vector3(x, y, z);

        //NavMesh.SamplePosition(browsePosition, )

        customer.GetComponent<NavMeshAgent>().SetDestination(browsePosition);
    }
}
