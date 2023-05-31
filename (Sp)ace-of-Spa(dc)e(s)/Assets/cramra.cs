using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cramra : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private float paraglax;
    [SerializeField] private GameObject paraglaxThis;

    void Update()
    {
        Vector3 pos = this.transform.position;
        Vector3 wos = paraglaxThis.transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
            wos.y += paraglax * speed * Time.deltaTime;

        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
            wos.y -= paraglax * speed * Time.deltaTime;

        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
            wos.x += paraglax * speed * Time.deltaTime;

        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            wos.x -= paraglax * speed * Time.deltaTime;

        }

        //   if (Input.GetAxis("Mouse ScrollWheel"))
        {
            //this.Camera.size += 1;
        }

        this.transform.position = pos;
        paraglaxThis.transform.position = wos;
    }
}
