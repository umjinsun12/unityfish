using UnityEngine;
using System.Collections;

public class foodsript : MonoBehaviour {


    public float starttime = 0; // 시작시간

                                // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        starttime += Time.deltaTime;

        if (starttime >4.0f)
        {
            DestroyObject(this.transform.gameObject);
            GameObject.Find("Main Camera").GetComponent<initstartpage>().foodcount--;

        }

        for (int i = 0; i < GameObject.Find("Main Camera").GetComponent<initstartpage>().allfood.Count; i++)
        {
            if (GameObject.Find("Main Camera").GetComponent<initstartpage>().allfood[i] == null)
            {
                GameObject.Find("Main Camera").GetComponent<initstartpage>().allfood.RemoveAt(i);
                i--;
            }
        }


    }
}
