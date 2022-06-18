using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{

    public GameObject Player;
    public GameObject[] enemyprefab;
    // public float enemynum = 2;
    public bool isplayer = true;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("createTank",1);
        Destroy(gameObject,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void createTank(){

        if(isplayer){
            Instantiate(Player,transform.position,Quaternion.identity);
        }else{
            // float enemynum = FindObjectOfType<Base>().enemynum;
            // if (enemynum > 0){
                 int num = Random.Range(0,4);
                Instantiate(enemyprefab[num],transform.position,Quaternion.identity);
            // }
           
        }
        
    }
}
