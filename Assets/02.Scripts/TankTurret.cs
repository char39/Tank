using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ray를 쏘아 마우스 포지션으로 따라

public class TankTurret : MonoBehaviour
{
    private Transform tr;

    void Start()
    {
        tr = transform;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // 메인 카메라에서 마우스 포지션으로 Ray를 쏨
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 2000f, Color.green);
        if (Physics.Raycast(ray, out hit, 2000f, 1 << 8))
        {
            Vector3 relative = tr.InverseTransformPoint(hit.point);
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            tr.Rotate(0f, angle * Time.deltaTime * 5f, 0f);
        }


    }
}
