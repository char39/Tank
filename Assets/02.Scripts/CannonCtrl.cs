using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCtrl : MonoBehaviour
{
    private Transform tr;
    public float rotSpeed = 500f;

    void Start()
    {
        tr = transform;
    }

    void Update()
    {
        float angle = Input.GetAxis("Mouse ScrollWheel") * rotSpeed * Time.deltaTime;
        tr.Rotate(angle, 0f, 0f);
    }
}
