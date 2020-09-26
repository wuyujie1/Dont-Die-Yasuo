using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colide : MonoBehaviour
{
    private Boolean upMoveable = true;
    private Boolean downMoveable = true;
    private Boolean leftMoveable = true;
    private Boolean rightMoveable = true;

    public Boolean getUpMoveable() {
        return upMoveable;
    }
    public Boolean getDownMoveable()
    {
        return downMoveable;
    }
    public Boolean getLeftMoveable()
    {
        return leftMoveable;
    }
    public Boolean getRightMoveable()
    {
        return rightMoveable;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            switch (collision.name) {
                case "Top":
                    upMoveable = false;
                    break;
                case "Bot":
                    downMoveable = false;
                    break;
                case "Left":
                    leftMoveable = false;
                    break;
                case "Right":
                    rightMoveable = false;
                    break;
            }
        }
        else
        {
            //Destroy(gameObject);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            switch (collision.name)
            {
                case "Top":
                    upMoveable = true;
                    break;
                case "Bot":
                    downMoveable = true;
                    break;
                case "Left":
                    leftMoveable = true;
                    break;
                case "Right":
                    rightMoveable = true;
                    break;
            }
        }
    }
}
