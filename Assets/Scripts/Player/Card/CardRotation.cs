using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRotation : MonoBehaviour
{
    void Update()
    {

        transform.Rotate(0, 1440 * Time.deltaTime, 0, Space.Self);
        
    }
}
