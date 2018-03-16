using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByCamera : MonoBehaviour
{

#if UNITY_EDITOR
    private void OnValidate()
    {

        
    }
#endif

    // Use this for initialization
    void Start ()
    {
        
        this.transform.localRotation= Quaternion.Euler(20f,0f, 0f);

    }
}
