using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehavior : MonoBehaviour {

    GameObject Earth;
    GameObject Meteor;

	// Use this for initialization
	void Start () {
        Earth = GameObject.FindGameObjectWithTag("Earth");
        Meteor = GameObject.FindGameObjectWithTag("Meteor");
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(Earth.transform.position, Meteor.transform.position);
        float RadiusEarth = Earth.transform.localScale.x / 2;
        float RadiusMeteor = Meteor.transform.localScale.x / 2;
        
        Debug.Log(distance + " : " + Earth.transform.position.y + " : " + Meteor.transform.position.y);

        if (distance < RadiusEarth + RadiusMeteor) {
            Debug.Log("COLLISION!!!");
        }
	}
}
