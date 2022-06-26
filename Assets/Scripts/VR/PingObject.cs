using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingObject : MonoBehaviour
{
    private GameObject player;
    public GameObject pingPin;
    private Vector3 position = new Vector3(0,0,0);

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
        position = gameObject.transform.position;
    }


    void Update()
    {
        transform.LookAt(player.transform);
    }

    public void Enemy()
    {
        GameObject clone;

        clone = Instantiate(pingPin, position, Quaternion.identity);
        clone.GetComponent<PingPin>().Enemy();
        Debug.Log("Enemy!");
        StartCoroutine("DeactivateSelf");
        //Destroy(gameObject);


    }
    public void Resource()
    {
        Debug.Log("clicked");
    }
    public void Damage()
    {
        Debug.Log("clicked");
    }
    public void GoHere()
    {
        Debug.Log("clicked");
    }


    IEnumerator DeactivateSelf()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
