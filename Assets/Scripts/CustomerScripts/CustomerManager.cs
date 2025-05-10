using System.Linq;
using UnityEngine;
using System.Collections;

public class CustomerManager : MonoBehaviour
{

    public Customer testCustomer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CustomerBehaviour.startPosition = transform.GetChild(0).transform;
        CustomerBehaviour.endPosition = transform.GetChild(1).transform;
        StartCoroutine("CreateCustomer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("skibdi")]
    public void testcreating()
    {
        CreateNewCustomer(testCustomer);
    }

    IEnumerator CreateCustomer()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            CreateNewCustomer(testCustomer);
        }
    }
    void CreateNewCustomer(Customer customer)
    {
        GameObject customerInstance = Instantiate(customer.prefab, CustomerBehaviour.startPosition.position, Quaternion.identity);

        customerInstance.GetComponent<CustomerBehaviour>().customerData = customer;

    }
}
