using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioTrigger : MonoBehaviour {
    protected AudioSource tick;
    public GameObject AI;
    float hearingThreshold = 15.0f;
	// Use this for initialization
	void Start ()
    {
        tick = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float sqDist = (transform.position - tick.transform.position).sqrMagnitude;
        float percievedLoudness = tick.volume / sqDist;

        if(percievedLoudness < hearingThreshold)
        {
            Debug.Log("It can hear this");
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Plane"))
        {
            tick.Play();
        }
    }
}
