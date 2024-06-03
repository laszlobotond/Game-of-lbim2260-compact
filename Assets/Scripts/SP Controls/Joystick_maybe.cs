using System;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_maybe : MonoBehaviour
{
    float lookBackFix = 180;
    public GameObject player;
    public RectTransform dot;
    public RectTransform button;
    public float moveForce;
    public Rigidbody rb;

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            if (!SelectMovementTouch())
                ResetDot();
        }
        else ResetDot();
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

        rb.AddForce(x / 200 * moveForce * Time.deltaTime, 0, y / 200 * moveForce * Time.deltaTime);
    }

    float Fixup(float x)
    {
        if (x > 200) return 200;
        if (x < -200) return -200;
        if (x > 0 && x < 100) return 100;
        if (x < 0 && x > -100) return -100;
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
        dot.position = new Vector2(button.position.x, button.position.y);
    }
}
