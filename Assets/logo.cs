using UnityEngine;
using System.Collections;

public class logo : MonoBehaviour {
	
	public float logotime;
	public Texture humax;
	public Texture isc;
	// Use this for initialization
	void Start () {
		logotime=0;
	}
	
	// Update is called once per frame
	void Update () {
		logotime+=Time.deltaTime;
		//Debug.Log (logotime);
		if(logotime<5)
		{
			MeshRenderer[] renders2 = GetComponentsInChildren<MeshRenderer>();
     	   	foreach (MeshRenderer render in renders2) 
     	   	{
      	 		render.material.SetTexture("_MainTex", humax);
	//			Debug.Log (""+render);
       		}
		}
		else if(logotime<10){
			MeshRenderer[] renders2 = GetComponentsInChildren<MeshRenderer>();
     	   	foreach (MeshRenderer render in renders2) 
     	   	{
      	 		render.material.SetTexture("_MainTex", isc);
	//			Debug.Log (""+render);
       		}
		}
		else
			DestroyObject(gameObject);
	
	}
}
