using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PingPin : MonoBehaviour
{
    //public Image pin;
    private GameObject player;
    private Image pin;
    
   
    void Start()
    {
        pin = GetComponentInChildren<Image>();
        player = GameObject.FindGameObjectWithTag("MainCamera");


    }
    public void Enemy()
    {
        pin.color = new Color32(255, 72, 72, 175);
    }
    public void Resource()
    {
        pin.color = new Color32(72, 255, 72, 175);
    }
    public void Damage()
    {
        pin.color = new Color32(72, 72, 255, 175);
    }
    public void GoHere()
    {
        pin.color = new Color32(72, 72, 72, 175);
    }


    void Update()
    {





       //Lookat
        Vector3 targetPostition = new Vector3(player.transform.position.x,
                                       this.transform.position.y,
                                       player.transform.position.z);
        this.transform.LookAt(targetPostition);
    }
}
