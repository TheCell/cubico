using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    [Header("Player")]
    public PlayerController PlayerController;

    [Header("Camera")]
    public PlayerCamera PlayerCamera;

    [Header("Player Stats")]
    public TextMeshProUGUI xpos;
    public string XPosText;
    public TextMeshProUGUI ypos;
    public string YPosText;
    public TextMeshProUGUI zpos;
    public string ZPosText;
    public TextMeshProUGUI xvel;
    public string XVelText;
    public TextMeshProUGUI yvel;
    public string YVelText;
    public TextMeshProUGUI zvel;
    public string ZVelText;
    public TextMeshProUGUI isGrounded;
    public string isGroundedText;

    [Header("Respawn Stats")]
    public int CheckpointsReached;
    public TextMeshProUGUI checkpointText;
    public string checkpointString;

    // Update is called once per frame
    void Update()
    {
        XPosText = "X Position: " + PlayerController.rigidb.position.x.ToString("F3");
        YPosText = "Y Position: " + PlayerController.rigidb.position.y.ToString("F3");
        ZPosText = "Z Position: " + PlayerController.rigidb.position.z.ToString("F3");
        XVelText = "X Velocity: " + PlayerController.rigidb.velocity.x.ToString("F3");
        YVelText = "Y Velocity: " + PlayerController.rigidb.velocity.y.ToString("F3");
        ZVelText = "Z Velocity: " + PlayerController.rigidb.velocity.z.ToString("F3");
        isGroundedText = PlayerController.isGrounded.ToString();
        if(PlayerController.isGrounded)
        {
            isGrounded.text = "Is Grounded: Yes";
        }
        else
        {
            isGrounded.text = "Is Grounded: No";
        }
        checkpointString = "Checkpoints Reached: " + CheckpointsReached.ToString();
        checkpointText.text = checkpointString;
        xpos.text = XPosText;
        ypos.text = YPosText;
        zpos.text = ZPosText;
        xvel.text = XVelText;
        yvel.text = YVelText;
        zvel.text = ZVelText;
    }
}
