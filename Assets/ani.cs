using UnityEngine;
using System.Collections;

public class ani : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Animation>().Stop();
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Animation>().Play();
        
	}
}
