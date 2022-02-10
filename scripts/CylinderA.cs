using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CylinderA : MonoBehaviour
{   
    public GameObject player;
    private float range;
    public float speed = 10f;
    public float minDistance = 10f;
        
    public delegate void delegateA();
    public static event delegateA OnCollideA;
    public static event delegateA OnNear; 

    void Start()
    {   
        
        CylinderB.OnCollideB += incrementarFuerza;
    }

    private void incrementarFuerza()    
    {
        speed *= 4;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            OnCollideA(); // dispara evento onCollideA al chocar con jugador
    }

    void Update() 
    {
        range = Vector3.Distance(transform.position, player.transform.position);
        if (range < minDistance) {
            OnNear();
            if (Input.GetKeyDown("space")) {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -1 * speed  * Time.deltaTime * 10);
            }
        }
    }

}