using System;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_sharp : MonoBehaviour
{
    float lookBackFix = 180;
    public GameObject player;
    public RectTransform dot;
    public RectTransform button;
    public float moveForce;
    public Rigidbody rb;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            if (!SelectMovementTouch())
            {
                ResetDot();
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
        else
        {
            ResetDot();
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    bool SelectMovementTouch()
    {
        float x = 0, y = 0;
        for (int i = 0; i < Input.touchCount; i++)
        {
            x = Input.touches[i].position.x - button.position.x;
            y = Input.touches[i].position.y - button.position.y;
            if (x < 270 && x > -270 && y < 270 && y > -270)
            {
                ActuallyMove(x, y);
                return true;
            }
        }
        return false;
    }

    void ActuallyMove(float x, float y)
    {
        if (x != 0 && y != 0) TurnPlayer(x, y);
        dot.position = new Vector2(400 + x, 300 + y);
        x = Fixup(x);
        y = Fixup(y);

        rb.velocity = new Vector3(x / 200 * moveForce * Time.deltaTime, 0, y / 200 * moveForce * Time.deltaTime);
    }

    float Fixup(float x)
    {
        if (x > 200) return 200;
        if (x < -200) return -200;
        if (x > 0 && x < 150) return 150;
        if (x < 0 && x > -150) return -150;
        return x;
    }

    void TurnPlayer(float x, float y)
    {
        double tg = x / y;
        double ang = Math.Atan(tg);
        float deg = (float)(ang * 180 / Math.PI);

        GameObject thirdPerson = GameObject.Find("Main Camera");
        if (thirdPerson)
        {
            // change rotation
            if (y > 0) player.transform.eulerAngles = new Vector3(0, deg, 0);
            else player.transform.eulerAngles = new Vector3(0, lookBackFix + deg, 0);
        }
        else
        {
            // just face forward
            player.transform.eulerAngles = Vector3.zero;
        }

    }

    void ResetDot()
    {
        //dot.position = new Vector2(400, 300);
        dot.position = new Vector2(button.position.x, button.position.y);
    }
}
