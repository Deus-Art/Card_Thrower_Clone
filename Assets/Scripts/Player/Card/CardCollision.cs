using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Hangin"))
        {
            other.transform.DOMoveY(50f, 10f);
            other.GetComponent<Collider>().enabled = false;
            other.GetComponentInChildren<Rigidbody>().useGravity = true;
            other.transform.DetachChildren();
            SoundManager.PlaySound(SoundManager.Sound.ropeCut);
        }
    }
}
