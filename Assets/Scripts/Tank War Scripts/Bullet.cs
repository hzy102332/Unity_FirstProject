using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public bool isPlayerBullet;
    public GameObject Born_player;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up *speed * Time.deltaTime,Space.World);
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        bool iswudi = FindObjectOfType<Player>().isDefended;
        float hp = FindObjectOfType<Base>().hp;
        switch(other.tag)
        {
            case "wall":
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
            case "enemy":
                if (isPlayerBullet){
                    other.SendMessage("Die"); 
                    Destroy(gameObject);
                    FindObjectOfType<Base>().SendMessage("kill");
                    if (FindObjectOfType<Base>().enemynum >= 0)
                    {
                        FindObjectOfType<Grid>().SendMessage("createenemy");
                    }
                } 
                break;
            case "base":
                other.SendMessage("Die");
                Destroy(gameObject);
                FindObjectOfType<Canvas>().SendMessage("Over");
                break;
            case "barriar":
                Destroy(gameObject);
                break;
            case "Player":
                if (!isPlayerBullet && !iswudi){
                    other.SendMessage("Die");
                    if (FindObjectOfType<Base>().hp > 0)
                        other.SendMessage("born");
                    FindObjectOfType<Base>().SendMessage("playerdie");
                }
                break;
            case "area":
                Destroy(gameObject);
                break;
            default: break;
        }
    }
}
