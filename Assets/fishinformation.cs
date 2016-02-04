using UnityEngine;
using System.Collections;



public class fishinformation : MonoBehaviour {

    public GameObject thisfish;
	public int fishtype=0;
	public int fishnum=0; //fish번호
	public float appetite=0; //식욕
	public float satiety=0; //포만감
	public float speed=0;
	public float power=0;
	public float weight=0;
	public int fishcolornum=0;
    public int mini = 0;
	
	public Texture fishcolor;
	
	public Texture graytexture;
	
	public string nickname="물고기";

    public Vector3 destinyrot = new Vector3(0, Random.value * 360, 0);
    public Vector3 fdestinyrot = new Vector3(0, Random.value * 360, 0);
    public float timecount=0;
	public float amttomove; //시간당 움직임, 포만감 조절
    private Vector3 weightvector=new Vector3(0,0,0);
	
	public int diecheck=0;//1이면 죽음(색깔처림).. 2이면 떠오르는것. 3이면 다올라갔을때..

    public float sx=0, sy=0;
    public float nowx=0, nowy=0;
    Quaternion nowtransform;
    Quaternion nowtra;

    public float cheight;
    public float cwidth;

    // Use this for initialization
    void Start () {

        cheight = Screen.height;
        cwidth = Screen.width;

        //thisfish=GameObject.Find("fish"+fishnum);
        //thisfish.

        MeshRenderer[] renders2 = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer render in renders2) 
        {
       		//render.material.SetTexture("_MainTex", fishcolor);
	//		Debug.Log (""+render);
        }
		
		SkinnedMeshRenderer[] renders = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer render in renders) 
        {
        	//render.material.SetTexture("_MainTex", fishcolor);
	//		Debug.Log (""+render);
        }
		
		
		//renderer.material.mainTexture=fishcolor;
		

	}
	
	// Update is called once per frame
	void Update () {


        weightvector.Set(weight*15.0f, weight*15.0f, weight*15.0f);
        transform.localScale = weightvector; //크기설정
		amttomove=speed*Time.deltaTime*9;
        //위치 변환..transform.Translate(5f * Time.deltaTime, 0f, 0f);

        float no3 = GameObject.Find("Main Camera").GetComponent<initstartpage>().no3;
        float o2 = GameObject.Find("Main Camera").GetComponent<initstartpage>().o2;
        float temperature = GameObject.Find("Main Camera").GetComponent<initstartpage>().temperature;
        float co2 = GameObject.Find("Main Camera").GetComponent<initstartpage>().co2;

        if(no3>=100 || o2>=100 || temperature>=35 || co2>=100)
        {
            diecheck = 1;
            satiety = 100;
        }
        if (satiety<=0) //fish가 배고파 죽음..
		{
			diecheck=1;
			satiety=100;
		}
		if(diecheck==1)
		{
			GetComponentInChildren<Animation>().Stop();
			
			
 			MeshRenderer[] renders2 = GetComponentsInChildren<MeshRenderer>();
       	 	foreach (MeshRenderer render in renders2) 
       	 	{
       			render.material.SetTexture("_MainTex", graytexture);
		//		Debug.Log (""+render);
       	 	}
 			SkinnedMeshRenderer[] renders = GetComponentsInChildren<SkinnedMeshRenderer>();
   	     	foreach (SkinnedMeshRenderer render in renders) 
   	     	{
   	     		render.material.SetTexture("_MainTex", graytexture);
        	}
			diecheck=3;
		}
		else if(diecheck==2)
		{
            diecheck = 3;
            transform.position=new Vector3(transform.position.x,transform.position.y+0.8f+transform.position.z);
			if(transform.position.y>=1000)
			{
				diecheck=3;
			}
            
		}
		else if(diecheck==0)
		{	
			fishpattern();
		}
	}

    void fishpattern()
    {




        //    int aaaaaa = transform.Find("Main Camera").GetComponent<initstartpage>().fishcount;
        //     Debug.Log("" + aaaaaa);
        satiety -= Time.deltaTime * 0.1f;



        if (transform.position.z > 600)
        {
            Vector3 dir = transform.TransformDirection(Vector3.forward * -1);
            Quaternion drot = Quaternion.LookRotation(dir);
            Quaternion rot = Quaternion.Slerp(transform.rotation, drot, 1.0f);
            transform.position = new Vector3(transform.position.x, transform.position.y, 599);
            transform.rotation = rot;
        }

        else if (transform.position.z < 100)
        {
            Vector3 dir = transform.TransformDirection(Vector3.forward * -1);
            Quaternion drot = Quaternion.LookRotation(dir);
            Quaternion rot = Quaternion.Slerp(transform.rotation, drot, 1.0f);
            transform.position = new Vector3(transform.position.x, transform.position.y, 101);
            transform.rotation = rot;
        }
        if (transform.position.x > 800)
        {
            Vector3 dir = transform.TransformDirection(Vector3.forward * -1);
            Quaternion drot = Quaternion.LookRotation(dir);
            Quaternion rot = Quaternion.Slerp(transform.rotation, drot, 1.0f);
            transform.position = new Vector3(799, transform.position.y, transform.position.z);
            transform.rotation = rot;
        }
        else if (transform.position.x < -800)
        {
            Vector3 dir = transform.TransformDirection(Vector3.forward * -1);
            Quaternion drot = Quaternion.LookRotation(dir);
            Quaternion rot = Quaternion.Slerp(transform.rotation, drot, 1.0f);
            transform.position = new Vector3(-799, transform.position.y, transform.position.z);
            transform.rotation = rot;
        }
        if (transform.position.y > 400)
        {
            Vector3 dir = transform.TransformDirection(Vector3.forward * -1);
            Quaternion drot = Quaternion.LookRotation(dir);
            Quaternion rot = Quaternion.Slerp(transform.rotation, drot, 1.0f);
            transform.position = new Vector3(transform.position.x, 399, transform.position.z);
            transform.rotation = rot;
        }
        else if (transform.position.y < -400)
        {
            Vector3 dir = transform.TransformDirection(Vector3.forward * -1);
            Quaternion drot = Quaternion.LookRotation(dir);
            Quaternion rot = Quaternion.Slerp(transform.rotation, drot, 1.0f);
            transform.position = new Vector3(transform.position.x, -399, transform.position.z);
            transform.rotation = rot;
        }


        int foodcount = GameObject.Find("Main Camera").GetComponent<initstartpage>().foodcount;

        if (foodcount > 0)
        {
            GameObject minfood = GameObject.Find("Main Camera").GetComponent<initstartpage>().allfood[0];
            if (minfood == null)
            {
                return;
            }
            int min = (int)Vector3.Distance(minfood.transform.position, transform.position);

            int tmp;

            for (int i = 0; i < foodcount; i++)
            {
                GameObject otherfood = GameObject.Find("Main Camera").GetComponent<initstartpage>().allfood[i];
                tmp = (int)Vector3.Distance(minfood.transform.position, transform.position);
                if (min > tmp)
                {
                    min = tmp;
                    minfood = otherfood;
                    mini = i;
                }
            }

            if (Vector3.Distance(minfood.transform.position, transform.position) < 70.3f)
            {
                GameObject.Find("Main Camera").GetComponent<initstartpage>().foodcount--;
                DestroyObject(minfood);
                GameObject.Find("Main Camera").GetComponent<initstartpage>().allfood.RemoveAt(mini);
                Debug.Log(""+mini);
                satiety = 100;
                
            }

            float disx, disy, disz;
            disx = minfood.transform.position.x - transform.position.x;
            disy = minfood.transform.position.y - transform.position.y;
            disz = minfood.transform.position.z - transform.position.z;
            if (disx == 0) disx = 0.00001f;
            if (disy == 0) disy = 0.00001f;
            if (disz == 0) disz = 0.00001f;

            fdestinyrot.x = transform.eulerAngles.x;

            if (disy > 0)
            {
                if (fdestinyrot.x > 346 || fdestinyrot.x < 15) fdestinyrot.x -= 0.5f;

            } else
            {
                if (fdestinyrot.x < 14 || fdestinyrot.x > 345) fdestinyrot.x += 0.5f;
            }

            if (disz >= 0)
                fdestinyrot.x = Mathf.Atan(disx / disz) * 180 / Mathf.PI;
            else
                fdestinyrot.y = Mathf.Atan(disx / disz) * 180 / Mathf.PI * 180;

            nowtra.eulerAngles = new Vector3(fdestinyrot.x, fdestinyrot.y, fdestinyrot.z);
            transform.rotation = nowtra;

            transform.Translate(Vector3.forward * Time.deltaTime * 30.0f);

        }
        else
        {
            //아래서부터 목표설정임..
            if (appetite > satiety)//fish가 배고플 때
            {
                if (weight < 5)
                {
                    satiety = 100;
                    weight += 2.0f;

                }
                else
                {
                    int fishcount = GameObject.Find("Main Camera").GetComponent<initstartpage>().fishcount;

                    for (int i = 0; i < fishcount; i++)
                    {
                        GameObject otherfish = GameObject.Find("Main Camera").GetComponent<initstartpage>().allfish[i];


                        if (Vector3.Distance(otherfish.transform.position, transform.position) < 20
                            && weight * 0.5 > otherfish.GetComponent<fishinformation>().weight)
                        //잡아먹음...
                        {
                            otherfish.GetComponent<fishinformation>().diecheck = 1;
                            satiety = 100;
                            weight += 2;
                        }


                        if (Vector3.Distance(otherfish.transform.position, transform.position) < 400
                            && weight * 0.5 > otherfish.GetComponent<fishinformation>().weight)
                        //두배정도 클경우
                        {

                            float disx, disy, disz;
                            disx = otherfish.transform.position.x - transform.position.x;
                            disy = otherfish.transform.position.y - transform.position.y;
                            disz = otherfish.transform.position.z - transform.position.z;
                            if (disx == 0) disx = 0.00001f;
                            if (disy == 0) disy = 0.00001f;
                            if (disz == 0) disz = 0.00001f;

                            destinyrot.x = transform.eulerAngles.x;
                            if (disy > 0)
                            {
                                if (destinyrot.x > 346 || destinyrot.x < 15) destinyrot.x -= 0.5f;

                            }
                            else
                            {
                                if (destinyrot.x < 14 || destinyrot.x > 345) destinyrot.x += 0.5f;
                            }

                            if (disz >= 0)
                                destinyrot.y = Mathf.Atan(disx / disz) * 180 / Mathf.PI;
                            else
                                destinyrot.y = Mathf.Atan(disx / disz) * 180 / Mathf.PI + 180;


                            timecount = 5;



                            //   tempdestinyrot.eulerAngles = destinyrot;
                            //    nowx = transform.rotation.x;
                            //    nowy = transform.rotation.y;

                            break;
                            //destinyrot.z;
                        }


                    }


                }

            }
            else
            { //안배고프면 평소 아무렇게나 움직임..float

                timecount -= Time.deltaTime;

                if (timecount <= 0)
                {
                    destinyrot.x = Random.value * 30 - 15;
                    if (destinyrot.x < 0) destinyrot.x += 360;
                    destinyrot.y = Random.value * 360;
                    destinyrot.z = 0;

                    //nowx = transform.rotation.x;
                    //nowy = transform.rotation.y;
                    timecount = Random.value * 10 + 10;
                }

            }

            if (timecount <= 20) ////////////////////10초로고쳐야함
            {

                sx = sy = 0;
                nowx = transform.rotation.eulerAngles.x;
                nowy = transform.rotation.eulerAngles.y;
                if (destinyrot.x < 0) destinyrot.x += 360;
                if (destinyrot.y < 0) destinyrot.y += 360;


                if (nowx > 270 && destinyrot.x < 90) sx = 0.1f;
                else if (nowx < 90 && destinyrot.x > 270) sx = -0.1f;
                else if (nowx > destinyrot.x) sx = -0.1f; //360도 이후도생각해야함
                else if (nowx < destinyrot.x) sx = 0.1f;
                if (nowy > 270 && destinyrot.y < 90) sy = 0.1f;
                else if (nowy < 120 && destinyrot.y > 240) sy = -0.1f;
                else if (nowy > destinyrot.y) sy = -0.1f;
                else if (nowy < destinyrot.y) sy = 0.1f;

                nowx += sx;
                nowy += sy;

                if (nowx > 360) nowx = 1;
                if (nowx < 0) nowx = 359;
                if (nowy > 360) nowy = 1;
                if (nowy < 0) nowy = 359;
                /////정해야함
                nowtransform.eulerAngles = new Vector3(nowx,
                                                   nowy,
                                                   0);
                transform.rotation = nowtransform;

                // transform.Rotate(sx, sy, 0);


                // Debug.Log("rotate " + sx + " " +sy + " " + " " + destinyrot +nowtransform.eulerAngles+ transform.rotation.eulerAngles+timecount);
            }
            transform.Translate(Vector3.forward * speed * Time.deltaTime * 200.0f);
        }
    }
    
}
