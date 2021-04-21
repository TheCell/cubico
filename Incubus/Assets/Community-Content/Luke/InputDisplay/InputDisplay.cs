using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputDisplay : MonoBehaviour
{
    public RawImage Base;
    public RawImage WPressed;
    public RawImage APressed;
    public RawImage SPressed;
    public RawImage DPressed;
    public RawImage EscPressed;
    public RawImage ShiftPressed;
    public RawImage SpacePressed;

    void Update()
    {
        Base.enabled = true;
        WPressed.enabled = Input.GetKey(KeyCode.W);
        APressed.enabled = Input.GetKey(KeyCode.A);
        SPressed.enabled = Input.GetKey(KeyCode.S);
        DPressed.enabled = Input.GetKey(KeyCode.D);
        EscPressed.enabled = Input.GetKey(KeyCode.Escape);
        ShiftPressed.enabled = Input.GetKey(KeyCode.LeftShift);
        SpacePressed.enabled = Input.GetKey(KeyCode.Space);
    }
}