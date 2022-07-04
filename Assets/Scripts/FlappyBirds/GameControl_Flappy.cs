using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl_Flappy : MonoBehaviour
{
    public GameObject Pips;
    public GameObject Awards;
    public GameObject UI;
    public float interval = 1f;
    public float birdinterval = 0.5f;
    public float heigh;
    public float maxheigh;
    public GameObject hint;
    public Transform pipup;
    public Transform pipdown;
    public bool modechange = false;
    
    private float timer = 10;
    private float birdtimer = 10;
    public bool isbengin;
    public bool stopcreate = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //控制管道的大小
       switch (GameMenus.level)
       {
           case 1:
               pipup.localPosition = new Vector3(0,7.3f,0);
               pipdown.localPosition = new Vector3(0, -7.3f, 0);
               break;
           case 2:
               pipup.localPosition = new Vector3(0,7,0);
               pipdown.localPosition = new Vector3(0, -7, 0);
               break;
           case 3:
               pipup.localPosition = new Vector3(0,6.5f,0);
               pipdown.localPosition = new Vector3(0, -6.5f, 0);
               break;
           default:
               break;
       }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (!isbengin))
        {
            isbengin = true;
            Destroy(hint,1); 
            GameObject.Find("Player/begin").SetActive(false);
            GameObject.Find("Player").transform.Find("y1").gameObject.SetActive(true);
        }
        
        if (isbengin && !stopcreate)
        {
            //生成管道
            if (timer > interval)
            {
                GameObject newpip = Instantiate(Pips);
                newpip.transform.position = transform.position + new Vector3(0,Random.Range
                    (-heigh,maxheigh),0);
                // newpip.transform.parent = UI.transform;
                Destroy(newpip,10);
                timer = 0;
            }
            timer += Time.deltaTime;
            
            //生成奖励鸟
            if (modechange && birdtimer > birdinterval)
            {
                GameObject newaward = Instantiate(Awards);
                newaward.transform.position = transform.position + new Vector3(0,Random.Range(-4,5),0);
                // newaward.transform.SetParent(UI.gameObject.transform);
                Destroy(newaward,10);
                birdtimer = 0;
            }
            birdtimer += Time.deltaTime;
        }
    }

}
