using UnityEngine;

public class EnableMouse : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
