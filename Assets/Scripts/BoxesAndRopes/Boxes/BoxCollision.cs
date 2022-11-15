using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    public GameObject BoxTopPart, snapParticle;
    //public float ropesOnBox; //gonna use this to cast the remaining number to UI


    Animator animator;
    int numChildren; //number of children is always 6 since box prefab has made of 6 squares, destroy rest of the children aka added ropes
    
    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Card"))
        {   
            
            if(numChildren > 6) 
            {
                Instantiate(snapParticle, transform.position, transform.rotation);
                SoundManager.PlaySound(SoundManager.Sound.ropeCut);
                Destroy(this.GetComponent<Transform>().GetChild(numChildren - 1).gameObject);
                //ropesOnBox = numChildren - 6; //which is zero after ropes are all gone

            }

            Destroy(other.gameObject);
        }
    }

    void Update() 
    {
        numChildren = this.transform.childCount;

        if(numChildren == 6)
        {   
            this.GetComponent<Collider>().enabled = false;
            animator.SetBool("isOpened", true);
            BoxTopPart.GetComponent<MeshRenderer>().enabled = false;
            
        }

        // if(ropesOnBox == 0)
        // {
        //    ropeNumbers.SetActive(false);
        // }

    }

    void Awake() 
    {
        animator = GetComponent<Animator>();
        numChildren = this.transform.childCount;
    }
}
