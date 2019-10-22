using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMovement : MonoBehaviour
{
    Transform myTransform;
    [SerializeField]
    float maxSpeed = 20f;
    float momentumX = 0f;
    float momentumY = 0f;
    [SerializeField]
    float acceleration = 0.5f;
    void Start()
    {
        myTransform = transform;
    }
    void Update()
    {
        Movement();
        CollisionCheck();
        myTransform.position = (new Vector2(myTransform.position.x + LogisticFunction(maxSpeed, acceleration, momentumX), myTransform.position.y + LogisticFunction(maxSpeed, acceleration, momentumY)));
    }
    void Movement()
    {
        if (UnityEngine.Input.GetAxis("LeftStickVertical") < 0)
        {
            if (momentumY < 10 / acceleration)
            {
                momentumY = momentumY - UnityEngine.Input.GetAxis("LeftStickVertical");
            }
        }
        else if (momentumY > 0)
        {
            momentumY--;
            momentumY = Mathf.Round(momentumY);
        }
        if (UnityEngine.Input.GetAxis("LeftStickVertical") > 0)
        {
            if (momentumY > -10 / acceleration)
            {
                momentumY = momentumY - UnityEngine.Input.GetAxis("LeftStickVertical");
            }
        }
        else if (momentumY < 0)
        {
            momentumY++;
            momentumY = Mathf.Round(momentumY);
        }
        if (UnityEngine.Input.GetAxis("LeftStickHorizontal") > 0)
        {
            if (momentumX < 10 / acceleration)
            {
                momentumX = momentumX + UnityEngine.Input.GetAxis("LeftStickHorizontal");
            }
        }
        else if (momentumX > 0)
        {
            momentumX--;
            momentumX = Mathf.Round(momentumX);
        }
        if (UnityEngine.Input.GetAxis("LeftStickHorizontal") < 0)
        {
            if (momentumX > -10 / acceleration)
            {
                momentumX = momentumX + UnityEngine.Input.GetAxis("LeftStickHorizontal");
            }
        }
        else if (momentumX < 0)
        {
            momentumX++;
            momentumX = Mathf.Round(momentumX);
        }
    }
    void CollisionCheck()
    {
        RaycastHit2D upTR = Physics2D.Raycast(new Vector2(myTransform.position.x + 24f, myTransform.position.y + 24f), Vector2.up, 1f);
        RaycastHit2D rightTR = Physics2D.Raycast(new Vector2(myTransform.position.x + 24f, myTransform.position.y + 24f), Vector2.right, 1f);
        RaycastHit2D rightBR = Physics2D.Raycast(new Vector2(myTransform.position.x + 24f, myTransform.position.y - 24f), Vector2.right, 1f);
        RaycastHit2D downBR = Physics2D.Raycast(new Vector2(myTransform.position.x + 24f, myTransform.position.y - 24f), Vector2.down, 1f);
        RaycastHit2D downBL = Physics2D.Raycast(new Vector2(myTransform.position.x - 24f, myTransform.position.y - 24f), Vector2.down, 1f);
        RaycastHit2D leftBL = Physics2D.Raycast(new Vector2(myTransform.position.x - 24f, myTransform.position.y - 24f), Vector2.left, 1f);
        RaycastHit2D leftTL = Physics2D.Raycast(new Vector2(myTransform.position.x - 24f, myTransform.position.y + 24f), Vector2.left, 1f);
        RaycastHit2D upTL = Physics2D.Raycast(new Vector2(myTransform.position.x - 24f, myTransform.position.y + 24f), Vector2.up, 1f);
        if (upTR && upTL)
        {
            if (momentumY > 0)
            {
                momentumY = -momentumY / 2f;
            }
        }
        if (rightTR && rightBR)
        {
            if (momentumX > 0)
            {
                momentumX = -momentumX / 2f;
            }
        }
        if (downBR && downBL)
        {
            if (momentumY < 0)
            {
                momentumY = -momentumY / 2f;
            }
        }
        if (leftTL && leftBL)
        {
            if (momentumX < 0)
            {
                momentumX = -momentumX / 2f;
            }
        }
    }
        float LogisticFunction(float max, float growth, float x, float translateUp = 0)
    {
        float answer;
        if (x > 0)
        {
            answer = max / (1 + Mathf.Pow((float)System.Math.E, -growth * (x - (5f / growth)))) + translateUp;
        }
        else if (x < 0)
        {
            answer = -max / (1 + Mathf.Pow((float)System.Math.E, -growth * (-x - (5f / growth)))) + translateUp;
        }
        else
        {
            answer = 0;
        }
        return answer;
    }
}