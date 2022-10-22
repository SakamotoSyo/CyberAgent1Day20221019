using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepLitRotation : MonoBehaviour
{
    
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0,0,0);
    }
}
