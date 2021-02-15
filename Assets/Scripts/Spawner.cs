using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public const string COROUTINE_NAME = "SpawnCustomer"; 

    [SerializeField] GameObject _customer;

    [SerializeField] bool isInstaSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        if (isInstaSpawn)
        { 
            Instantiate(_customer, transform.position, transform.rotation, this.transform);
        }
        else
        {
            StartCoroutine(SpawnCustomer());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CallSpawnCustomer()
    {
        StartCoroutine(SpawnCustomer());
    }

    public IEnumerator SpawnCustomer()
    {
        float timer = Random.Range(10f, 20f);
        yield return new WaitForSeconds(timer);
        Instantiate(_customer, transform.position, transform.rotation, this.transform);
    }
}
