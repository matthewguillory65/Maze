using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Inventory> items;

	// Use this for initialization
	void Start ()
    {
        items = new List<Inventory>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
