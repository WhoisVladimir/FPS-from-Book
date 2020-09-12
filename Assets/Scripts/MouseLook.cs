using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float YawSpeed = 3.0f;
    public float PitchSpeed = 9.0f;
    public float MinPitch = -45.0f;
    public float MaxPitch = 45.0f;
    public float rotationX = 0;
    public enum RotationAxes
    {
        MouseXandY,
        MouseX,
        MouseY
    }
    public RotationAxes axes = RotationAxes.MouseXandY;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if(rigidbody != null) rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * YawSpeed, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * PitchSpeed;
            rotationX = Mathf.Clamp(rotationX, MinPitch, MaxPitch);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
        else
        {
            rotationX -= Input.GetAxis("Mouse Y") * PitchSpeed;
            rotationX = Mathf.Clamp(rotationX, MinPitch, MaxPitch);

            float delta = Input.GetAxis("Mouse X") * YawSpeed;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}
