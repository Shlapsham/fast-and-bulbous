using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    bool[] selectedKeys = { false, false, false, false, false, false, false, false, false, false, false };
    bool[] testSpell = { true, true, true, true, true, true, true, true, true, true, true };
    bool flag1 = false;
    void Start()
    {
        
    }
    void Update()
    {
        checkKeyPress();
        casting();
    }
    void checkKeyPress()
    {
        if (UnityEngine.Input.GetKey("A"))
        {
            if (selectedKeys[0])
            {
                selectedKeys[0] = false;
            }
            else
            {
                selectedKeys[0] = true;
            }
        }
        if (UnityEngine.Input.GetKey("B"))
        {
            if (selectedKeys[1])
            {
                selectedKeys[1] = false;
            }
            else
            {
                selectedKeys[1] = true;
            }
        }
        if (UnityEngine.Input.GetKey("X"))
        {
            if (selectedKeys[2])
            {
                selectedKeys[2] = false;
            }
            else
            {
                selectedKeys[2] = true;
            }
        }
        if (UnityEngine.Input.GetKey("Y"))
        {
            if (selectedKeys[3])
            {
                selectedKeys[3] = false;
            }
            else
            {
                selectedKeys[3] = true;
            }
        }
        if (UnityEngine.Input.GetKey("LeftBumper"))
        {
            if (selectedKeys[4])
            {
                selectedKeys[4] = false;
            }
            else
            {
                selectedKeys[4] = true;
            }
        }
        if (UnityEngine.Input.GetKey("RightBumper"))
        {
            if (selectedKeys[5])
            {
                selectedKeys[5] = false;
            }
            else
            {
                selectedKeys[5] = true;
            }
        }
        if (UnityEngine.Input.GetAxis("LeftTrigger") > 0)
        {
            if (selectedKeys[6])
            {
                selectedKeys[6] = false;
            }
            else
            {
                selectedKeys[6] = true;
            }
        }
        if (UnityEngine.Input.GetAxis("DPADHorizontal") == 1)
        {
            if (selectedKeys[7])
            {
                selectedKeys[7] = false;
            }
            else
            {
                selectedKeys[7] = true;
            }
        }
        if (UnityEngine.Input.GetAxis("DPADHorizontal") == -1)
        {
            if (selectedKeys[8])
            {
                selectedKeys[8] = false;
            }
            else
            {
                selectedKeys[8] = true;
            }
        }
        if (UnityEngine.Input.GetAxis("DPADVertical") == 1)
        {
            if (selectedKeys[9])
            {
                selectedKeys[9] = false;
            }
            else
            {
                selectedKeys[9] = true;
            }
        }
        if (UnityEngine.Input.GetAxis("DPADVertical") == -1)
        {
            if (selectedKeys[10])
            {
                selectedKeys[10] = false;
            }
            else
            {
                selectedKeys[10] = true;
            }
        }
    }
    void casting()
    {
        if (UnityEngine.Input.GetAxis("RightTrigger") > 0)
        {
            if (selectedKeys == testSpell)
            {
                flag1 = true;
            }
            for (int i = 0; i >= selectedKeys.Length; i++)
            {
                selectedKeys[i] = false;
            }
        }
    }
}