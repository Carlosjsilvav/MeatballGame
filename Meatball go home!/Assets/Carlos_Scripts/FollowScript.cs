/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
   public Transform targetObj;
   public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, speed * Time.deltaTime);
        
    }

    
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform targetObj;
    public float speed = 10f;

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetObj.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a wall
        if (collision.gameObject.CompareTag("wall"))
        {
            // Get the normal of the collision to determine the direction of the collision
            Vector3 collisionNormal = collision.contacts[0].normal;

            // Reflect the velocity vector using the collision normal to maintain direction
            rb.velocity = Vector3.Reflect(rb.velocity, collisionNormal).normalized * speed;
        }
    }
}
