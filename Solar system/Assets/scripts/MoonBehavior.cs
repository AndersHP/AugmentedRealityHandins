using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonBehavior : MonoBehaviour {

    public float rotateSpeed;

    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        transform.RotateAround(transform.parent.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
