
using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class initstartpage : MonoBehaviour
{

    public List<GameObject> allfood = new List<GameObject>();

    public GUISkin mySkin;
    //=========================환경변수==============================
    public float co2; //co2
    public float o2; //o2
    public float temperature; //온도
    public float no3; //질산염 수치


    public GameObject threedprocam; //3d 모델

    // Use this for initialization

    //public float ttt = -30; //카메라 테스트용 z좌표위치
    //==========================배경음악==============================
    public AudioClip sound0, sound1, sound2, sound3, sound4, sound5,sound6;
    public AudioClip[] soundarr;//배경음악
	//==========================배경음악==============================

    public string IP = "127.0.0.1"; //ip와 port
    public int port = 25001;
    /*	public GameObject fish0,fish1,fish2,fish3,fish4,fish5,fish6,fish7,fish8,fish9;
        public GameObject fish10,fish11,fish12,fish13,fish14,fish15,fish16,fish17,fish18,fish19;
    */

	//==========================물고기==============================
    public GameObject fishs0, fishs1, fishs2, fishs3, fishs4, fishs5, fishs6, fishs7, fishs8, fishs9;
    public GameObject fishs10, fishs11, fishs12, fishs13, fishs14, fishs15, fishs16, fishs17, fishs18, fishs19;

    public GameObject[] kindfish; //fish의 종류
    public GameObject[] allfish; //현재 게임상에 존재하는 fish객체모음
    public GameObject food;
    public int fishcount = 0; //현재 게임상의 존재하는 fish 수
    public int foodcount = 0; // 현재 게임상의 존재하는 food 수
    public static int arr;

	//==========================물고기==============================

	//==========================텍스쳐==============================
    public Texture fc0, fc1, fc2, fc3, fc4, fc5, fc6, fc7, fc8, fc9;
    public Texture fc10, fc11, fc12, fc13, fc14, fc15, fc16, fc17, fc18, fc19;
    public Texture fc20, fc21, fc22, fc23, fc24, fc25, fc26, fc27, fc28, fc29;
    public Texture[] fcarr; //fishcolor와 array
	//==========================텍스쳐==============================


	//==========================플레인==============================
    public GameObject plane;
    public Texture planeimg0, planeimg1, planeimg2, planeimg3, planeimg4, planeimg5, planeimg6;
    public Texture[] planeimgarr;
	//==========================플레인==============================

    public float starttime = 0; // 시작시간
    public float startpagez = -199; // startpage
    void Start() //초기화
    {
        threedprocam = GameObject.Find("3D Pro Cam");
        threedprocam.SetActive(false);
        //Quaternion tempRotation;
        //tempRotation = gameObject.transform.rotation;
        //for (int i = 1; i <= 80; i++)
        //{


        //    tempRotation.eulerAngles = new Vector3(i, i, i);
        //    transform.rotation = tempRotation;

        //}

        //tempRotation.eulerAngles = new Vector3(0, 0, 0);
        //transform.rotation = tempRotation;
        // Debug.Log("" + Mathf.Atan(0.3f) * 180 / Mathf.PI + Mathf.Atan(-0.3f) * 180 / Mathf.PI);
        co2 = 10.7f;//0
        o2 = 20.1f;//0
        no3 = 0.0f;//0
        temperature = 22.0f;//0

        allfish = new GameObject[1000];
        kindfish = new GameObject[20];

        //물고기 종류설정
        kindfish[0] = fishs0;
        kindfish[1] = fishs1;
        kindfish[2] = fishs2;
        kindfish[3] = fishs3;
        kindfish[4] = fishs4;
        kindfish[5] = fishs5;
        kindfish[6] = fishs6;
        kindfish[7] = fishs7;
        kindfish[8] = fishs8;
        kindfish[9] = fishs9;
        kindfish[10] = fishs10;
        kindfish[11] = fishs11;
        kindfish[12] = fishs12;
        kindfish[13] = fishs13;
        kindfish[14] = fishs14;
        kindfish[15] = fishs15;
        kindfish[16] = fishs16;
        kindfish[17] = fishs17;
        kindfish[18] = fishs18;
        ////////////////////////////////////////////
        fcarr = new Texture[30];
        //물고기 색깔과 텍스쳐설정
        fcarr[0] = fc0;
        fcarr[1] = fc1;
        fcarr[2] = fc2;
        fcarr[3] = fc3;
        fcarr[4] = fc4;
        fcarr[5] = fc5;
        fcarr[6] = fc6;
        fcarr[7] = fc7;
        fcarr[8] = fc8;
        fcarr[9] = fc9;
        fcarr[10] = fc10;
        fcarr[11] = fc11;
        fcarr[12] = fc12;
        fcarr[13] = fc13;
        fcarr[14] = fc14;
        fcarr[15] = fc15;
        fcarr[16] = fc16;
        fcarr[17] = fc17;
        fcarr[18] = fc18;
        fcarr[19] = fc19;
        fcarr[20] = fc20;
        fcarr[21] = fc21;
        fcarr[22] = fc22;
        fcarr[23] = fc23;
        fcarr[24] = fc24;
        fcarr[25] = fc25;
        fcarr[26] = fc26;
        fcarr[27] = fc27;
        fcarr[28] = fc28;
        fcarr[29] = fc29;

        soundarr = new AudioClip[7];
        soundarr[0] = sound0;
        soundarr[1] = sound1;
        soundarr[2] = sound2;
        soundarr[3] = sound3;
        soundarr[4] = sound4;
        soundarr[5] = sound5;
        soundarr[6] = sound6;
        //audio.clip = soundarr[3];
        //audio.Play();
        //audio.loop = true;

        planeimgarr = new Texture[7];
        planeimgarr[0] = planeimg0;
        planeimgarr[1] = planeimg1;
        planeimgarr[2] = planeimg2;
        planeimgarr[3] = planeimg3;
        planeimgarr[4] = planeimg4;
        planeimgarr[5] = planeimg5;
        planeimgarr[6] = planeimg6;

        //이부분에서 물고기의 정보를 초기화하고 불로오는것을 해야함...
        /*	for(int i=0;i<=0;i++)
            {
                addfish(1,10,0.05f,i,Color.white);

                //	allfish[i].name="aa"+i;
            }
         * */
        plane = (GameObject)Instantiate(plane);

        //backgroundimage(3);
        loadfishdata();
    }
    void Update()
    {
        for (int i = 0; i < fishcount; i++)
        {
            if (allfish[i].GetComponent<fishinformation>().diecheck == 3)
            //물고기 죽음확인..
            {
                Destroy(allfish[i]);
                allfish[i] = allfish[fishcount - 1];

                fishcount--;
                for (int j = 0; j < fishcount; j++)
                {
                    allfish[j].name = "fish" + j;
                    allfish[j].tag = "fish" + j;
                }
            }
        }

        temperature = temperature - 0.0001f + fishcount*0.00001f;//w
        co2 = co2 + fishcount * 0.0001f;//w
        no3 = no3 + fishcount * 0.0002f;//w
        o2 = o2 + fishcount * 0.00013f;//w


    }
    void OnGUI()
    {
        /*if (starttime <= 10)
        {
            starttime += Time.deltaTime;
            if (startpagez >= -850) startpagez -= 1.2f;
            transform.position = new Vector3(0, 0, startpagez);

        }
        else if (starttime <= 22)
        {
            starttime += Time.deltaTime;
            if (startpagez <= 150) startpagez += 2.3f;
            transform.position = new Vector3(0, 0, startpagez);
        }
        else
        {*/

        GUI.skin = mySkin;

            if (GUI.Button(new Rect(0, 20, 100, 40), "Fish Add"))
            {

                int colorrandom = (int)(Random.value * 24);

                addfish("물고기",
                    (int)(Random.value * 17.0f + 1.0f), 
                    (float)(Random.value * 50.0f), 
                    (float)(Random.value * 0.4f + 0.05f), 
                    (float)(Random.value * 10.0f + 100.0f), colorrandom);
                //savefishdata();
            }
            if (GUI.Button(new Rect(0, 60, 100, 40), "Rand View"))
            {
                fishcamera((int)(Random.value * fishcount));
            }
            if (GUI.Button(new Rect(0, 100, 100, 40), "먹이주기"))
            {
                addfood();
            }
            if (GUI.Button(new Rect(0, 140, 100, 40), "물갈이"))
            {
                co2 = 10.7f;//0
                o2 = 20.1f;//0
                no3 = 0.0f;//0
                temperature = 22.0f;//0   
            }
            
            if (GUI.Button(new Rect(0, 180, 100, 40), "Main View"))
            {
                transform.position = new Vector3(0, 0, startpagez);
            }

            if(GUI.Button(new Rect(0,220,100,40),"3d"))
            {
                if(threedprocam.activeSelf==false)
                {
                    GameObject.Find("Main Camera").GetComponent<Camera>().rect = new Rect(0, 0, 1, 1);
                threedprocam.SetActive(true);

                }
                else
             {
                 GameObject.Find("Main Camera").GetComponent<Camera>().rect = new Rect(0, 0, 1, 1);
                threedprocam.SetActive(false);
             }

        }

        GUI.skin.box.fontSize = 20;//w
        GUI.Box(new Rect(Screen.width - 150, 20, 150, 150), "O2 : "+ o2.ToString("N2") + "\n" + "CO2 : " + co2.ToString("N2") + "\n" + "NO3 : " + no3.ToString("N2") + "\n" + "온도 : " + temperature.ToString("N2"));//w
            


            //		if(Network.peerType == NetworkPeerType.Disconnected)
            //		{
            //if (GUI.Button(new Rect(100, 100, 100, 25), "Start Client"))
            //{
            //    Network.Connect(IP, port);
            //}
            //			if(GUI.Button (new Rect(0,25,100,25),"Start Server"))
            //			{
            //				Network.InitializeServer(100,port);

            //			}

            //		}
            //		else{
            //			if(Network.peerType==NetworkPeerType.Server)
            //			{
            //				if(GUI.Button (new Rect(0,25,100,25),"Server Down"))
            //				{
            //					Network.Disconnect(250);
            //
            //				}
            //
            //			}
            //		}
            //	}
            //if (GUI.Button(new Rect(0, 200, 100, 25), ttt+Network.connections.Length))
            //{
            //    networkView.RPC("createfish", RPCMode.Others);
            //}

    }
    void addfood()
    {
        allfood.Add((GameObject)Instantiate(food, new Vector3(Random.value * 200.0f - 50.0f, Random.value * 160.0f - 50.5f, Random.value * 50.0f + 250.0f), Quaternion.identity));
        foodcount++;
    }

    void addfish(string name,int fishtype, float appetite, float speed, float weight, int colornum)
    {
       // Debug.Log(name + fishtype);
        allfish[fishcount] = (GameObject)Instantiate(kindfish[fishtype], new Vector3(Random.value * 200.0f - 50.0f, Random.value * 160.0f - 50.5f, Random.value * 50.0f + 250.0f), Quaternion.identity);

        allfish[fishcount].name = "fish" + fishcount;

        string[] tmps = name.Split(' ');
        name = "";
        for (int i = 0; i < tmps.Length; i++)
        {
            name += tmps[i];

        }
        allfish[fishcount].GetComponent<fishinformation>().nickname = name;
        allfish[fishcount].GetComponent<fishinformation>().satiety = 100;
        allfish[fishcount].GetComponent<fishinformation>().speed = speed;
        allfish[fishcount].GetComponent<fishinformation>().fishtype = fishtype;
        allfish[fishcount].GetComponent<fishinformation>().appetite = appetite; //더바꿔야함
        allfish[fishcount].GetComponent<fishinformation>().power = 10;
        allfish[fishcount].GetComponent<fishinformation>().weight = weight;

        allfish[fishcount].GetComponent<fishinformation>().fishnum = fishcount;
        allfish[fishcount].GetComponent<fishinformation>().fishcolornum = colornum;
        allfish[fishcount].GetComponent<fishinformation>().thisfish = kindfish[fishtype];

        Texture fishcolor;
        fishcolor = fcarr[colornum];
        allfish[fishcount].GetComponent<fishinformation>().fishcolor = fishcolor;

        fishcount++;
        //kindfish[fishtype] = (GameObject)Instantiate(kindfish[fishtype], new Vector3(Random.value * 100.0f - 50.0f, Random.value * 100.0f - 50.5f, Random.value * 24.0f - 24.0f), Quaternion.identity);

        //kindfish[fishtype].name = "fish" + fishcount;

        //string[] tmps = name.Split(' ');
        //name = "";
        //for (int i = 0; i < tmps.Length; i++)
        //{
        //    name += tmps[i];
            
        //}
        //kindfish[fishtype].GetComponent<fishinformation>().nickname = name;
        //kindfish[fishtype].GetComponent<fishinformation>().satiety = 100;
        //kindfish[fishtype].GetComponent<fishinformation>().speed = speed;
        //kindfish[fishtype].GetComponent<fishinformation>().fishtype = fishtype;
        //kindfish[fishtype].GetComponent<fishinformation>().appetite = appetite; //더바꿔야함
        //kindfish[fishtype].GetComponent<fishinformation>().power = 10;
        //kindfish[fishtype].GetComponent<fishinformation>().weight = weight;

        //kindfish[fishtype].GetComponent<fishinformation>().fishnum = fishcount;
        //kindfish[fishtype].GetComponent<fishinformation>().fishcolornum = colornum;
        //kindfish[fishtype].GetComponent<fishinformation>().thisfish = kindfish[fishtype];

        //Texture fishcolor;
        //fishcolor = fcarr[colornum];
        //kindfish[fishtype].GetComponent<fishinformation>().fishcolor = fishcolor;

        //allfish[fishcount] = kindfish[fishtype];

        //fishcount++;
        
    }
    void savefishdata()
    {//파일쓰기
       // string fileName = Application.dataPath+"gamedata.txt";
       // string fileName = Application.persistentDataPath + "gamedata.txt";
        string path = pathForDocumentsFile("gamedata.txt");
        
        try
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(fishcount);
            for (int i = 0; i < fishcount; i++)
            {
                sw.WriteLine(allfish[i].transform.position.x);
                sw.WriteLine(allfish[i].transform.position.y);
                sw.WriteLine(allfish[i].transform.position.z);
              //  sw.WriteLine(allfish[i].transform.rotation.eulerAngles.x);
              //  sw.WriteLine(allfish[i].transform.rotation.eulerAngles.y);
              //  sw.WriteLine(allfish[i].transform.rotation.eulerAngles.z);
                sw.WriteLine(allfish[i].GetComponent<fishinformation>().nickname);
                sw.WriteLine(allfish[i].GetComponent<fishinformation>().satiety);
                sw.WriteLine(allfish[i].GetComponent<fishinformation>().speed);
                sw.WriteLine(allfish[i].GetComponent<fishinformation>().fishtype);
                sw.WriteLine(allfish[i].GetComponent<fishinformation>().appetite);
                sw.WriteLine(allfish[i].GetComponent<fishinformation>().power);
                sw.WriteLine(allfish[i].GetComponent<fishinformation>().weight);
                sw.WriteLine(allfish[i].GetComponent<fishinformation>().fishcolornum);

                
            }
            sw.Close();
            fs.Close();
        }
        catch(IOException e)
        {
            Debug.Log(e);
        }
        
    }
    void loadfishdata()
    {
        //string fileName = Application.dataPath + "/gamedata.txt";
        //string fileName = Application.persistentDataPath + "/gamedata.txt";
        string path = pathForDocumentsFile("gamedata.txt");
        try
        {
            FileStream fs = new FileStream(path, FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            //string readstr;
            int count=int.Parse(sr.ReadLine());
            //Debug.Log(count);

            for (int i = 0; i < count; i++)
            {
                float fishx = float.Parse(sr.ReadLine()); 
                float fishy = float.Parse(sr.ReadLine()); 
                float fishz = float.Parse(sr.ReadLine());
             //   float fishrotx = float.Parse(sr.ReadLine()); 
             //   float fishroty = float.Parse(sr.ReadLine()); 
             //   float fishrotz = float.Parse(sr.ReadLine()); 
                string fishnickname = sr.ReadLine(); 
                float fishsatiety = float.Parse(sr.ReadLine()); 
                float fishspeed = float.Parse(sr.ReadLine()); 
                int fishfishtype = int.Parse(sr.ReadLine()); 
                float fishappetite = float.Parse(sr.ReadLine()); 
                float fishpower = float.Parse(sr.ReadLine()); 
                float fishweight = float.Parse(sr.ReadLine());
                int fishcolornum = int.Parse(sr.ReadLine());

                addfish(fishnickname,
                        fishfishtype,
                        fishappetite,
                        fishspeed,
                        fishweight,
                        fishcolornum);
                allfish[i].transform.position = new Vector3(fishx, fishy, fishz);
          //      allfish[i].transform.rotation.eulerAngles = new Vector3(fishrotx, fishroty, fishrotz);
                allfish[i].GetComponent<fishinformation>().satiety = fishsatiety;
                allfish[i].GetComponent<fishinformation>().power = fishpower;
            }
            
        }
        catch(FileNotFoundException e)
        {
            Debug.Log(e);
        }
    }
    public string pathForDocumentsFile(string filename)
    {
        string path = Application.persistentDataPath;
        path = path.Substring(0, path.LastIndexOf('/'));
        return Path.Combine(path, filename);
    }
    void fishcamera(int fishnum)
    {
        float x, y;
        if (fishcount == 0) 
        { 
            return; 
        }
        x = allfish[fishnum].transform.position.x;
        y = allfish[fishnum].transform.position.y;
        GetComponent<Camera>().transform.position = new Vector3(x, y, -30);
        GetComponent<Camera>().orthographic = false;
    }
    [RPC]
    public void firstsearch()
    {
        string tmp;
        tmp = "" + fishcount;
        for (int i = 0; i < fishcount; i++)
        {
            tmp += " " + allfish[i].GetComponent<fishinformation>().nickname
                + " " + allfish[i].GetComponent<fishinformation>().fishtype
                + " " + allfish[i].GetComponent<fishinformation>().satiety
                + " " + allfish[i].GetComponent<fishinformation>().weight
                + " " + allfish[i].GetComponent<fishinformation>().speed
                + " " + allfish[i].GetComponent<fishinformation>().fishcolornum;
        }
       // Debug.Log(tmp);
        GetComponent<NetworkView>().RPC("secondsearch", RPCMode.Others, tmp);
    }
    [RPC]
    public void secondsearch(string info)
    {
        //debug.log("secondsearch:"+info);
    }
    //[RPC]
    //public void sendfishnumber(int _fishnum)
    //{
    //}
    //물고기의 총 개수를 반환함
    [RPC]
    public void createfish(string name,int fishtypenum, float appetite, float weight, float speed, int colornum)
    {
        addfish(name,fishtypenum, appetite, speed, weight, colornum);
        savefishdata();
        //networkView.RPC("sendfishnumber", RPCMode.Others, fishcount - 1);
    }
    [RPC]
    public void searchfish(int number)
    {
        fishcamera(number);
    }


    [RPC]
    public void cameramoveleft()
    {
        transform.position = new Vector3(transform.position.x - 10.0f, transform.position.y, -30);
        GetComponent<Camera>().orthographic = false;
        
    }
    [RPC]
    public void cameramoveright()
    {
        transform.position = new Vector3(transform.position.x + 10.0f, transform.position.y, -30);
        GetComponent<Camera>().orthographic = false;
    }
    [RPC]
    public void cameramoveup()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y+10, -30);
        GetComponent<Camera>().orthographic = false;
    }
    [RPC]
    public void cameramovedown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y-10, -30);
        GetComponent<Camera>().orthographic = false;
    }
    [RPC]
    public void cameramoverandom()
    {
        float ranx = (Random.value * 1000.0f) - 500.0f;
        float rany = (Random.value * 1000.0f) - 500.0f;
        transform.position = new Vector3(ranx, rany, -30);
        GetComponent<Camera>().orthographic = false;
    }
    [RPC]
    public void cameramovecenter()
    {
        transform.position = new Vector3(0, 0, -30);
        GetComponent<Camera>().orthographic = false;
    }
    [RPC]
    public void cameramoveworld()
    {
        transform.position = new Vector3(0, 0, -700);
        GetComponent<Camera>().orthographic = true;
    }


    [RPC]
    public void worldsave()
    {
        savefishdata();
    }

    [RPC]
    public void worldreset()
    {
        for (int i = 0; i < fishcount; i++)
        { 
            Destroy(allfish[i]);
        }
        fishcount = 0;
    }

    [RPC]
    public void backgroundsound(int soundnum)
    {
        if (soundnum == 0)
        {
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            GetComponent<AudioSource>().clip = soundarr[soundnum];
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().loop = true;
           
        }
    }
 //   [RPC]
 //   public void backgroundimage(int imagenum)
 //   {
  //      MeshRenderer[] renders = plane.GetComponentsInChildren<MeshRenderer>();
   //     foreach (MeshRenderer render in renders)
    //    {
    //        render.material.SetTexture("_MainTex", planeimgarr[imagenum]);
            //		Debug.Log (""+render);
   //     }
   // }
    [RPC]
    public void fishkill(int fishnum)
    {
        allfish[fishnum].GetComponent<fishinformation>().diecheck = 1;
    }
    
}
