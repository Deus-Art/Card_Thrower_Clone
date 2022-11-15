using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopesCollisionTwo : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Card"))
        {
            transform.Translate(Vector3.right * 2f, Space.Self);
            gameObject.GetComponent<Collider>().enabled = false;
            Destroy(other.gameObject);
        }
    }
}
