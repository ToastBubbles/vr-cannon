using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class PingAction : MonoBehaviour
{

    private float heldTime;
    public bool button;

    void Start()
    {
        
    }

    void Update()
    {

       

        button = gameObject.GetComponent<Player>().pingheld;

        if (button)
            heldTime += Time.deltaTime;
        else
            heldTime = 0;

        Debug.Log("held for: " + heldTime);
        if (heldTime > 0.2)
        {

        }



    }
}
