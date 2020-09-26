using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class enemyMovement : MonoBehaviour
{
    private float x_speed;
    private float x_dir;
    private float y_speed;
    private float y_dir;

    private float cd = 0.8f;
    private float counter = 0f;
    private Vector3 dir = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.transform.position.x > 0)
        {
            x_dir = -1;
        }
        else if (gameObject.transform.position.x < 0)
        {
            x_dir = 1;
        }
        x_speed = Random.Range(7, 11);

        if (gameObject.transform.position.y > 0)
        {
            y_dir = -1;
        }
        else if (gameObject.transform.position.y < 0) {
            y_dir = 1;
        }
        y_speed = Random.Range(5, 9);

        dir.x = x_dir * x_speed;
        dir.y = y_dir * y_speed;
        dir.z = 0;

        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, dir);
        transform.rotation = rotation;
        transform.Rotate(0, 0, 270);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * x_dir * x_speed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * y_dir * y_speed * Time.deltaTime, Space.World);

        dir.x = x_dir * x_speed;
        dir.y = y_dir * y_speed;
        dir.z = 0;

        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, dir);
        transform.rotation = rotation;
        transform.Rotate(0, 0, 270);

        if (counter > 0)
        {
            counter -= Time.deltaTime;
        }
        else if (counter <= 0)
        {
            x_speed = Random.Range(7, 11);
            y_speed = Random.Range(5, 9);
            counter = cd;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyWall" && gameObject.name != "enemy")
        {
            Destroy(gameObject);
            Score.incrementScore();
        }
    }
}
