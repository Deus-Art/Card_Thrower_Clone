using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopesCollision : MonoBehaviour
{
    public GameObject snapParticle;
    //public Transform snapPosition;

    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Card"))
        {
            Instantiate(snapParticle, transform.position, transform.rotation);
            SoundManager.PlaySound(SoundManager.Sound.ropeCut);
            transform.Translate(Vector3.left * 2f, Space.Self);
            gameObject.GetComponent<Collider>().enabled = false;
            Destroy(other.gameObject);
        }
    }

   
}
