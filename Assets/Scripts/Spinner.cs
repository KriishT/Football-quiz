using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    Transform trnsfrm;
 
    void Start()
    {
        trnsfrm = GetComponent<Transform>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        trnsfrm.Rotate(2, 0, 0);
    }
}
