using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public Text number;
    public Text Goal;
    public float phase = 0;
    private float score = 0;
    

    public void Getpoint()
    {
        score += 1;
        number.text = score.ToString();
        switch (score)
        {
         case 5:
             if (phase == 0)
             {
                 score = 0;
                 Goal.text = "10";
                 number.text = score.ToString();
                 phase += 1;
                 FindObjectOfType<Base>().SendMessage("Recover");
                 // FindObjectOfType<CreatMap>().SendMessage("createMap");
             }
             break;
         case 10:
             if (phase == 1)
             {
                 score = 0;
                 number.text = score.ToString();
                 Goal.text = "15";
                 phase += 1;
                 FindObjectOfType<Base>().SendMessage("Recover");
                 FindObjectOfType<CreatMap>().SendMessage("createMap");
             }
             break;
         case 15:
             if (phase == 2)
             {
                 FindObjectOfType<Pause>().SendMessage("wingame");
             }
             break;
         default:
             break;
        }
    }
    
}
