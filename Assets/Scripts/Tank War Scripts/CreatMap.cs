using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreatMap : MonoBehaviour
{
    //0. player 1.born_enemy 2.wall 3.barrier 4.water 5.grass 6.base
    public GameObject[] items;
    private List<Vector3> positionlist = new List<Vector3>();

    
    private void Awake()
    {
       createMap();
    }

    private void createMap()
    {
        positionlist.Add(new Vector3(-2,-7,0));
        
        CreateItem(items[6],new Vector3(0,-7,0),Quaternion.identity);
        CreateItem(items[2],new Vector3(-1,-7,0),Quaternion.identity);
        CreateItem(items[2],new Vector3(-1,-6,0),Quaternion.identity);
        CreateItem(items[2],new Vector3(0,-6,0),Quaternion.identity);
        CreateItem(items[2],new Vector3(1,-6,0),Quaternion.identity);
        CreateItem(items[2],new Vector3(1,-7,0),Quaternion.identity);
        // CreateItem(items[0],new Vector3(-2,-7,0),Quaternion.identity);//玩家
        //enenmy
        createenemy();
        // createenemy();
        createMapmaterials(70,20,20,20);
    }
    private void createenemy()
    {
        CreateItem(items[1],new Vector3(-9,11,0),Quaternion.identity);
        CreateItem(items[1],new Vector3(9,11,0),Quaternion.identity);
        CreateItem(items[1],new Vector3(0,11,0),Quaternion.identity);
    }
    
    private void createMapmaterials(float wall, float barrier, float water, float grass)
    {
        //wall
        for (int i = 0; i < wall; i++)
        {
            CreateItem(items[2],randompostion(),quaternion.identity);
        }
        //barrier
        for (int i = 0; i < barrier; i++)
        {
            CreateItem(items[3],randompostion(),quaternion.identity);
        }
        //water
        for (int i = 0; i < water; i++)
        {
            CreateItem(items[4],randompostion(),quaternion.identity);
        }
        //grass
        for (int i = 0; i < grass; i++)
        { 
            CreateItem(items[5],randompostion(),quaternion.identity);
        }
    }
    
    private void CreateItem(GameObject obj, Vector3 vect, Quaternion rotation){
        
        GameObject item = Instantiate(obj,vect,rotation);
        item.transform.SetParent(gameObject.transform);
        positionlist.Add(vect);
    }
    
    //创建随机位置
    private Vector3 randompostion()
    {
        while (true)
        {
            Vector3 postion = new Vector3(Random.Range(-8, 9),Random.Range(-7,11),0);
            if (!check(postion))      
                return postion;
        }
    }
    //判断是否已存在位置
    private Boolean check(Vector3 pos)
    {
        for (int i = 0; i < positionlist.Count; i++)
        {
            if (positionlist[i] == pos)
            {
                return true;
            }
        }
        return false;
    }
}
