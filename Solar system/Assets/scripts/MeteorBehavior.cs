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
        //        float RadiusEarth = Earth.transform.localScale.x / 2;
        float RadiusEarth = 0.03f;
        //        float RadiusMeteor = Meteor.transform.localScale.x / 2;
        float RadiusMeteor = 0.0375f;

        //Debug.Log(distance - (RadiusEarth + RadiusMeteor));
        Debug.Log(GameObject.FindGameObjectWithTag("Sun").transform.localScale.x);

        if (distance < RadiusEarth + RadiusMeteor) {
            Debug.Log("COLLISION!!!");
            Explode();
        }
	}

    void Explode() {
        ParticleSystem explosion = GetComponent<ParticleSystem>();
        explosion.Play();
    }
}
