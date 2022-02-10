using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CylinderB : MonoBehaviour
{   
    public delegate void delegateB();
    public static event delegateB OnCollideB;
    public Text texto;

    void Start()
    {   
        CylinderA.OnCollideA += colision;
        CylinderA.OnNear += updateColor;
    }

    private void colision() 
    {
        texto.text = "Ha colisionado";
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            transform.localScale *= 1.5f;
            OnCollideB();
        }
    }

    void updateColor() 
    {
        Color color = new Color(Random.value, Random.value, Random.value, Time.deltaTime);
        GetComponent<Renderer>().material.color = color;
    }
}
