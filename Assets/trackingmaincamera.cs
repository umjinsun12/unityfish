using UnityEngine;
using System.Collections;

public class trackingmaincamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = GameObject.Find("Main Camera").transform.position;
        transform.rotation = GameObject.Find("Main Camera").transform.rotation;
    }
}
