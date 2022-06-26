using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl_Flappy : MonoBehaviour
{
    public GameObject Pips;
    public float interval = 1f;
    public float heigh;
    public float maxheigh;
    public GameObject hint;
    private float timer = 10;
    
    // Start is called before the first frame update
    void Start()
    {
       Destroy(hint,1);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > interval)
        {
            GameObject newpip = Instantiate(Pips);
            newpip.transform.position = transform.position + new Vector3(0,Random.Range
            (-heigh,maxheigh),0);
            Destroy(newpip,6);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
