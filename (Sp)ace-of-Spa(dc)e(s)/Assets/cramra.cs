using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cramra : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private float paraglax;
    [SerializeField] private GameObject paraglaxThis;
    [SerializeField] private Camera cram;
    private float fov;

    void Start()
    {
        Paraglax.Instance.Invoke("goHereFriend", 0.5f);

    }

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

        //var fov = this.GetComponent<Camera>();

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Camera.main.orthographicSize += Input.GetAxis("Mouse ScrollWheel") * -200 * Time.deltaTime;

        }


      //  Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, this.transform.position.y, Camera.main.transform.position.z + fov);



     //   this.GetComponent<Camera>().main.fieldOfView = fov;

        //   if (Input.GetAxis("Mouse ScrollWheel"))
        {
            //this.Camera.size += 1;
        }

        this.transform.position = pos;
        paraglaxThis.transform.position = wos;
    }
}
