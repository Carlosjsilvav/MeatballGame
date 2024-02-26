using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public GameObject youlost;

    public Collider EnemyCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a GameObject on the "Player" layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player collided with enemy");
            youlost.SetActive(true);
            player.gameObject.GetComponent<PlayerMovement>().playerCanMove = false;
        }
    }
}

