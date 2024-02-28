using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForkEnable : MonoBehaviour
{
    public GameObject Enemy;
    public float height = 7;
    public float  currOffset = 7;
    private bool up, fall;
    void Start()
    {
        Enemy.GetComponent<NavMeshAgent>().baseOffset = height;
    }

    // Update is called once per frame
    void Update()
    {
         if(fall)
        {
            currOffset -= Time.deltaTime * 12;
            Enemy.GetComponent<NavMeshAgent>().baseOffset = currOffset;
           // Debug.Log("Dropping");
            if (currOffset <= .5)
            {
                fall = false;
                StartCoroutine("GroundWait");
            }
        }
        if(up)
        {
            currOffset += Time.deltaTime * 3;
            Enemy.GetComponent<NavMeshAgent>().baseOffset = currOffset;
            //Debug.Log("Upsies");
            if (currOffset >= (height - .5))
            {
                //Debug.Log("Back");
                up = false;
            }
        }

    }

    IEnumerator GroundWait()
    {
        yield return new WaitForSeconds(.5f);
        up = true;
        //Debug.Log("Rising");
    }
    IEnumerator AttackDelay()
    {
        this.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(5f);
        this.GetComponent<Collider>().enabled = true;
    }

        private void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Detected");
        if (other.gameObject.CompareTag("Player"))
        {
           // Debug.Log("Player");
            fall = true;
        StartCoroutine("AttackDelay");
        }

    }
}

