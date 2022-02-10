using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform player;

    void Start() {
        CylinderA.OnNear += Rotate;
    }

    void Rotate() {
        transform.LookAt(player);
        Debug.DrawRay(transform.position, transform.forward * 9, Color.green, 0.1f, true);
    }
}