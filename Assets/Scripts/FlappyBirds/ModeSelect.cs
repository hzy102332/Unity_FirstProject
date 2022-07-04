using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelect : MonoBehaviour
{
    public Image Image;
    public Sprite[] Sprites;
    public Text Text;
    public Text weapon;
    public float weapon_strength = 0;
    public Text score;
    public GameObject menu, back1,back2;
    

    //0: normal 1: boss mode
    public static float mode = 0;
    
    public void modechange()
    {
        mode = mode == 1 ? 0 :mode + 1;
        Image.sprite = Sprites[(int)mode];
        SoundManager.instance.Modeslect();
        if (mode == 1)
        {
            Text.text = "Boss Mode";
            Text.color = Color.red;
            GameObject.FindObjectOfType<GameControl_Flappy>().modechange = true;
            
        }else if (mode == 0)
        {
            Text.text = "Normal Mode";
            Text.color = Color.cyan;
            GameObject.FindObjectOfType<GameControl_Flappy>().modechange = false;
        }
    }

    public void Weaponup()
    {
        weapon_strength += 10;
        weapon.text = weapon_strength.ToString();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Image.sprite = Sprites[(int)mode];
        weapon_strength = 0;
     //拉开黑幕
        if (mode == 1)
        {
            Text.text = "Boss Mode";
            Text.color = Color.red;
            score.text = "15";
            menu.GetComponent<Animator>().SetTrigger("Trigger");
            back1.GetComponent<Animator>().SetTrigger("Trigger");
            back2.GetComponent<Animator>().SetTrigger("Trigger");
            GameObject.FindObjectOfType<GameControl_Flappy>().modechange = true;
            
        }else if (mode == 0)
        {
            Text.text = "Normal Mode";
            Text.color = Color.cyan;
            score.text = "0";
        }
    }
    
}
