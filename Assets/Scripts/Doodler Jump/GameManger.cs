using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public GameObject[] plateformprefab;
    public float currentYpos;
    public float cameraheight = 7f;
    public Transform plateformPool;
    public Text point;

    private float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        CreatePlateformPool();

        while (currentYpos < Camera.main.transform.position.y + cameraheight)
        {
            PickNewPlateform();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentYpos < Camera.main.transform.position.y + cameraheight)
        {
            PickNewPlateform();
        }
    }

    void CreatePlateformPool()
    {
        int normal = 30;
        int weak = 15;

        for (int i = 0; i < normal; i++)
        {
            GameObject plateform = Instantiate(plateformprefab[0], plateformPool);
            plateform.SetActive(false);
        }
        
        for (int i = 0; i < weak; i++)
        {
            GameObject plateform = Instantiate(plateformprefab[1], plateformPool);
            plateform.SetActive(false);
        }
    }
    
    void PickNewPlateform(){
        currentYpos += Random.Range(1.3f,2f);
        float xpos = Random.Range(-5f,5f);

        int r = 0;
        do{
            r = Random.Range(0,plateformPool.childCount);
        }
        while(plateformPool.GetChild(r).gameObject.activeInHierarchy);

        plateformPool.GetChild(r).position = new Vector2(xpos,currentYpos);
        plateformPool.GetChild(r).gameObject.SetActive(true);

    }
    
    //player score
    void AddScore()
    {
        score += 1;
        point.text = score.ToString();
    }
    //show score
    
}
