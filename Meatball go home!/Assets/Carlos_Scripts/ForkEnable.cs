using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForkEnable : MonoBehaviour
{
    public GameObject Enemy;
    public float height = 7;
    public float  currOffset;
    private bool up, fall;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(fall)
        {
            currOffset = height - Time.deltaTime * 14;
            Enemy.GetComponent<NavMeshAgent>().baseOffset = currOffset;

            if (currOffset <= 0)
            {
                fall = true;
                StartCoroutine("GroundWait");
            }
        }
        if(up)
        {
            currOffset += Time.deltaTime * 14;
            Enemy.GetComponent<NavMeshAgent>().baseOffset = currOffset;
            if (currOffset >= height)
            {
                up = false;
            }
        }
        
    }
    
    IEnumerator GroundWait()
        {
            yield return new WaitForSeconds(.5f);
            up = true;
        }

        private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            fall = true;
        }
    }
}
