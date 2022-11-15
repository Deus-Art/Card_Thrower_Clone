using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class test : MonoBehaviour
{
    
    private void Update() {

        transform.DOMoveZ(10f, 10f);
        if(transform.position.z > 2f){
        gameObject.SetActive(false);
        }

        
    }
}
