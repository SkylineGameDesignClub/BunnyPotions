using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;

public class CustomerBehaviour : MonoBehaviour
{
    public static Transform startPosition;
    public static Transform endPosition;

    bool isMovingDown = true;

    public Customer customerData;

    [SerializeField][Range(1f, 10f)] float customerSpeed = 6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, endPosition.position.y, transform.position.z), Time.deltaTime * customerSpeed);
            if (math.abs(transform.position.y - endPosition.position.y) < 0.01)
            {
                isMovingDown = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(endPosition.position.x, transform.position.y, transform.position.z), Time.deltaTime * customerSpeed);
        }
        
    }
}
