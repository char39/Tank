using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCtrl : MonoBehaviour
{
    private Transform firePostr;
    private GameObject bullet;
    public float rotSpeed = 100f;       // 회전 속도
    public float upperAngle = -30f;     // 최대 각도
    public float downAngle = 0f;        // 최소 각도
    public float currentRotate = 0f;    // 현재 각도
    
    void Start()
    {
        firePostr = transform.GetChild(0).GetChild(0).transform;
        bullet = Resources.Load<GameObject>("Bullet");
    }

    void Update()
    {
        CannonAngle();
        CannonFire();
    }

    private void CannonAngle()
    {
        float wheel = -Input.GetAxis("Mouse ScrollWheel");      // 마우스 휠 입력
        float angle = wheel * rotSpeed * Time.deltaTime;        // 회전 각도 계산
        if (wheel < 0)
        {
            currentRotate += angle;
            if (currentRotate > upperAngle)
                transform.Rotate(angle, 0f, 0f);
            else
                currentRotate = upperAngle;
        }
        else if (wheel > 0)
        {
            currentRotate += angle;
            if (currentRotate < downAngle)
                transform.Rotate(angle, 0f, 0f);
            else
                currentRotate = downAngle;
        }
    }

    private void CannonFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePostr.position, firePostr.rotation);
        }
    }

}
