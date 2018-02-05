using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehaviour : MonoBehaviour {

    public float rotateSpeed;

    void Start()
    {
        //Vuforia.VuforiaBehaviour.    
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
