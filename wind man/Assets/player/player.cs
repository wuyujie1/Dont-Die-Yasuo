
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
#if UNITY_EDITOR
using UnityEditorInternal;
#endif
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void move()
    {
        float x_in = Input.GetAxisRaw("Horizontal");
        float y_in = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 40f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 8f;
        }

        if ((x_in > 0 && gameObject.GetComponent<colide>().getRightMoveable()) || (x_in < 0 && gameObject.GetComponent<colide>().getLeftMoveable()))
        {
            transform.Translate(Vector3.right * x_in * speed * Time.deltaTime, Space.World);
        }
        if ((y_in > 0 && gameObject.GetComponent<colide>().getUpMoveable()) || (y_in < 0 && gameObject.GetComponent<colide>().getDownMoveable()))
        {
            transform.Translate(Vector3.up * y_in * speed * Time.deltaTime, Space.World);
        }


        if (x_in > 0 & y_in > 0)
        {
            transform.rotation = Quaternion.Euler(180, 0, 135);
        }
        else if (x_in < 0 & y_in > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 315);
        }
        else if (x_in > 0 & y_in < 0)
        {
            transform.rotation = Quaternion.Euler(180, 0, 230);
        }
        else if (x_in < 0 & y_in < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (x_in > 0)
        {
            transform.rotation = Quaternion.Euler(180, 0, 180);
        }
        else if (x_in < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (y_in < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (y_in > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }

    // Update is called once per frame
    void Update()
    {
        move();

        if (Input.GetKeyDown(KeyCode.R)) {
            //gameObject.transform.position.Set(-0.37f, 0.07f, 0f);
            Score.resetScore();


            GameObject[] enms = GameObject.FindGameObjectsWithTag("enemy");
            for (int i = 0; i < enms.Length; i++) {
                if (enms[i].name != "enemy") {
                    Destroy(enms[i]); }
            }
            Time.timeScale = 1;
        }
        }
}