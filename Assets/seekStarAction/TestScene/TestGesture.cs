using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGesture : MonoBehaviour
{
    public KinectManager manager;
    public stellar_rotate stellar;
    public Text debugText;
    public bool flip = false;
    public float deviation = 10;
    public bool isGestureTrue = false;

    [HeaderAttribute("Gesture Value")]
    public Quaternion UserOrientation;
    //public Vector3[] JointPosition;
    //public Vector3[] JointLocalPosition;
    //public Quaternion[] JointOrientation;
    //public Quaternion[] JointLocalOrientation;
    //手臂
    public Vector3 ElbowToShoulder_L, ElbowToWrist_L;
    public Vector3 ElbowToShoulder_R, ElbowToWrist_R;
    //腿
    public Vector3 KneeToHip_L, KneeToAnkle_L;
    public Vector3 KneeToHip_R, KneeToAnkle_R;

    public List<Vector3> DirectionBetweenJoints;
    public List<float> AngleBetweenJoints;

    private float times = 0;

    private enum Joint
    {
        Hip_Center, Spine, Shoulder_Center, Head,  // 0 - 3
        Shoulder_Left, Elbow_Left, Wrist_Left, Hand_Left,  // 4 - 7
        Shoulder_Right, Elbow_Right, Wrist_Right, Hand_Right,  // 8 - 11
        Hip_Left, Knee_Left, Ankle_Left, Foot_Left,  // 12 - 15
        Hip_Right, Knee_Right, Ankle_Right, Foot_Right  // 16 - 19
    }
    private Joint joint;

    public enum Gesture
    {
        Capricorn, Aquarius, Pisces, Aries, Taurus, Gemini, //魔羯/水瓶/雙魚/牡羊/金牛/雙子
        Cancer, Leo, Virgo, Libra, Scorpio, Sagittarius //巨蟹/獅子/處女/天秤/天蠍/射手
    }
    public Gesture gesture;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("kinectManager").GetComponent<KinectManager>();
    }

    void Update()
    {
        times += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Return))
        {
            getUserGestureValue();
        }
        if (times > 1)
        {
            times = 0;
            getUserGestureValue();
            checkGestureForValue();
        }
    }

    private void getUserGestureValue()
    {
        if (manager.IsUserDetected())
        {
            DirectionBetweenJoints = new List<Vector3>();
            AngleBetweenJoints = new List<float>();

            uint p1 = manager.GetPlayer1ID();
            //uint jointLength = 20;
            UserOrientation = manager.GetUserOrientation(p1, flip);
            /*for (int i = 0; i < jointLength; i++)
            {
                JointPosition[i] = manager.GetJointPosition(p1, i);
                JointLocalPosition[i] = manager.GetJointLocalPosition(p1, i);
                JointOrientation[i] = manager.GetJointOrientation(p1, i, flip);
                JointLocalOrientation[i] = manager.GetJointLocalOrientation(p1, i, flip);
            }*/
            ElbowToShoulder_L = manager.GetDirectionBetweenJoints(p1, (int)Joint.Elbow_Left, (int)Joint.Shoulder_Left, flip, flip);
            ElbowToShoulder_R = manager.GetDirectionBetweenJoints(p1, (int)Joint.Elbow_Right, (int)Joint.Shoulder_Right, flip, flip);
            ElbowToWrist_L = manager.GetDirectionBetweenJoints(p1, (int)Joint.Elbow_Left, (int)Joint.Wrist_Left, flip, flip);
            ElbowToWrist_R = manager.GetDirectionBetweenJoints(p1, (int)Joint.Elbow_Right, (int)Joint.Wrist_Right, flip, flip);
            KneeToHip_L = manager.GetDirectionBetweenJoints(p1, (int)Joint.Knee_Left, (int)Joint.Hip_Left, flip, flip);
            KneeToHip_R = manager.GetDirectionBetweenJoints(p1, (int)Joint.Knee_Right, (int)Joint.Hip_Right, flip, flip);
            KneeToAnkle_L = manager.GetDirectionBetweenJoints(p1, (int)Joint.Knee_Left, (int)Joint.Ankle_Left, flip, flip);
            KneeToAnkle_R = manager.GetDirectionBetweenJoints(p1, (int)Joint.Knee_Right, (int)Joint.Ankle_Right, flip, flip);

            DirectionBetweenJoints.Add(ElbowToShoulder_L);
            DirectionBetweenJoints.Add(ElbowToWrist_L);
            DirectionBetweenJoints.Add(ElbowToShoulder_R);
            DirectionBetweenJoints.Add(ElbowToWrist_R);
            DirectionBetweenJoints.Add(KneeToHip_L);
            DirectionBetweenJoints.Add(KneeToAnkle_L);
            DirectionBetweenJoints.Add(KneeToHip_R);
            DirectionBetweenJoints.Add(KneeToAnkle_R);

            for (int i = 0; i < DirectionBetweenJoints.Count; i++)
            {
                DirectionBetweenJoints[i].Normalize();
            }
            for (int i = 0; i < DirectionBetweenJoints.Count; i += 2)
            {
                AngleBetweenJoints.Add(Vector3.Angle(DirectionBetweenJoints[i], DirectionBetweenJoints[i + 1]));
            }

            //Debug.Log("Get Gesture Value Complete.");
        }
    }

    private void checkGestureForValue()
    {
        if (manager.IsUserDetected())
        {
            uint p1 = manager.GetPlayer1ID();
            Vector3 _ElbowToShoulder_L = manager.GetDirectionBetweenJoints(p1, (int)Joint.Elbow_Left, (int)Joint.Shoulder_Left, flip, flip);
            Vector3 _ElbowToShoulder_R = manager.GetDirectionBetweenJoints(p1, (int)Joint.Elbow_Right, (int)Joint.Shoulder_Right, flip, flip);
            Vector3 _ElbowToWrist_L = manager.GetDirectionBetweenJoints(p1, (int)Joint.Elbow_Left, (int)Joint.Wrist_Left, flip, flip);
            Vector3 _ElbowToWrist_R = manager.GetDirectionBetweenJoints(p1, (int)Joint.Elbow_Right, (int)Joint.Wrist_Right, flip, flip);
            Vector3 _KneeToHip_L = manager.GetDirectionBetweenJoints(p1, (int)Joint.Knee_Left, (int)Joint.Hip_Left, flip, flip);
            Vector3 _KneeToHip_R = manager.GetDirectionBetweenJoints(p1, (int)Joint.Knee_Right, (int)Joint.Hip_Right, flip, flip);
            Vector3 _KneeToAnkle_L = manager.GetDirectionBetweenJoints(p1, (int)Joint.Knee_Left, (int)Joint.Ankle_Left, flip, flip);
            Vector3 _KneeToAnkle_R = manager.GetDirectionBetweenJoints(p1, (int)Joint.Knee_Right, (int)Joint.Ankle_Right, flip, flip);

            List<Vector3> _DirectionBetweenJoints = new List<Vector3>();

            _DirectionBetweenJoints.Add(_ElbowToShoulder_L);
            _DirectionBetweenJoints.Add(_ElbowToWrist_L);
            _DirectionBetweenJoints.Add(_ElbowToShoulder_R);
            _DirectionBetweenJoints.Add(_ElbowToWrist_R);
            _DirectionBetweenJoints.Add(_KneeToHip_L);
            _DirectionBetweenJoints.Add(_KneeToAnkle_L);
            _DirectionBetweenJoints.Add(_KneeToHip_R);
            _DirectionBetweenJoints.Add(_KneeToAnkle_R);

            for (int i = 0; i < _DirectionBetweenJoints.Count; i++)
            {
                _DirectionBetweenJoints[i].Normalize();
            }

            List<float> _AngleBetweenJoints = new List<float>();

            for (int i = 0; i < _DirectionBetweenJoints.Count; i += 2)
            {
                _AngleBetweenJoints.Add(Vector3.Angle(_DirectionBetweenJoints[i], _DirectionBetweenJoints[i + 1]));
            }

            checkGesture(_AngleBetweenJoints, UserOrientation.eulerAngles.y);

            if (isGestureTrue)
            {
                if (debugText)
                    debugText.text = "GestureTrue : " + gesture;
                Debug.Log("GestureTrue");
                stellar.SelectMainBool(true);
            }
            else
            {
                if (debugText)
                    debugText.text = "";
                Debug.Log("GestureFalse");
            }
        }
    }

    private void checkGesture(List<float> angle, float y)
    {
        if (angle[0] == 0 && angle[1] == 0 && angle[2] == 0 && angle[3] == 0) { isGestureTrue = false; return; }
        switch (gesture)
        {
            case (Gesture.Aquarius):
                float[] gAngleAquarius = { 100, 180, 180, 180 };
                for (int i = 0; i < angle.Count - 2; i++)
                {
                    float _deviation = Mathf.Abs(angle[i] - gAngleAquarius[i]);
                    if (angle[i] == 0) isGestureTrue = true;
                    else if (_deviation < deviation)
                    {
                        isGestureTrue = true;
                    }
                    else
                    {
                        isGestureTrue = false;
                        break;
                    }
                }
                break;
            case (Gesture.Taurus):
                float[] gAngleTaurus = { 180, 180, 150, 150 };
                for (int i = 0; i < angle.Count; i++)
                {
                    float _deviation = Mathf.Abs(angle[i] - gAngleTaurus[i]);
                    if (angle[i] == 0) isGestureTrue = true;
                    else if (_deviation < deviation)
                    {
                        isGestureTrue = true;
                    }
                    else
                    {
                        isGestureTrue = false;
                        break;
                    }
                }
                break;
            case (Gesture.Cancer):
                float[] gAngleCancer = { 100, 100, 180, 180 };
                for (int i = 0; i < angle.Count - 2; i++)
                {
                    float _deviation = Mathf.Abs(angle[i] - gAngleCancer[i]);
                    if (angle[i] == 0) isGestureTrue = true;
                    else if (_deviation < deviation)
                    {
                        isGestureTrue = true;
                    }
                    else
                    {
                        isGestureTrue = false;
                        break;
                    }
                }
                break;
        }
    }
}
