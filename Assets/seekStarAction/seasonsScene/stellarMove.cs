using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stellarMove : MonoBehaviour
{
    public KinectManager manager;
    private Vector3[] posJoint = new Vector3[5];
    private float cavX = 9, cavY = 5;
    private float oldX = 0.5f, oldY = 0.3f;
    private bool RightHandControlMouse()
    {
        float rh = posJoint[1].y - posJoint[4].y, lh = posJoint[3].y - posJoint[4].y;
        if (rh > lh) { return true; }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("kinectManager").GetComponent<KinectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        uint playerID = manager != null ? manager.GetPlayer1ID() : 0;
        if (playerID > 0)
        {
            getPosJoint(playerID);

            if (RightHandControlMouse())
            {
                float mouseX = Mathf.Lerp(-cavX, cavX, Mathf.InverseLerp(-oldX, oldX, posJoint[1].x - posJoint[0].x));
                float mouseY = Mathf.Lerp(-cavY, cavY, Mathf.InverseLerp(-oldY, oldY, posJoint[1].y - posJoint[0].y));
                transform.position = new Vector2(mouseX, mouseY);
            }
            else
            {
                float mouseX = Mathf.Lerp(-cavX, cavX, Mathf.InverseLerp(-oldX, oldX, posJoint[3].x - posJoint[2].x));
                float mouseY = Mathf.Lerp(-cavY, cavY, Mathf.InverseLerp(-oldY, oldY, posJoint[3].y - posJoint[2].y));
                transform.position = new Vector2(mouseX, mouseY);
            }
        }
        else
        {
            float mouseX = Mathf.Lerp(-cavX, cavX, Mathf.InverseLerp(0, 1920, Input.mousePosition.x));
            float mouseY = Mathf.Lerp(-cavY, cavY, Mathf.InverseLerp(0, 1080, Input.mousePosition.y));
            transform.position = new Vector2(mouseX, mouseY);
        }
    }
    private void getPosJoint(uint userId)
    {
        posJoint[0] = manager.GetJointPosition(userId, 8); //Shoulder_Right
        posJoint[1] = manager.GetJointPosition(userId, 11);//Hand_Right
        posJoint[2] = manager.GetJointPosition(userId, 4); //Shoulder_Left
        posJoint[3] = manager.GetJointPosition(userId, 7); //Hand_Left
        posJoint[4] = manager.GetJointPosition(userId, 0); //Hip_Center
    }
}
