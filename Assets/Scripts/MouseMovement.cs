using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

  public enum CameraMode
  {
    FirstPerson,
    ThirdPerson
  }

  public CameraMode currentMode = CameraMode.FirstPerson;

  public Vector3 firstPersonOffset = new Vector3(0f, 1.6f, 0f);
  public Vector3 thirdPersonOffset = new Vector3(0f, 2f, -4f);

  void LateUpdate()
  {
    if (currentMode == CameraMode.FirstPerson)
    {
      transform.localPosition = firstPersonOffset;
    }
    else
    {
      transform.localPosition = thirdPersonOffset;
    }
  }


  public float mouseSensitivity = 100f;

  float xRotation = 0f;
  float YRotation = 0f;

  void Start()
  {
    //Locking the cursor to the middle of the screen and making it invisible
    Cursor.lockState = CursorLockMode.Locked;
  }

  void Update()
  {

    if (Input.GetKeyDown(KeyCode.T))
    {
      currentMode = currentMode == CameraMode.FirstPerson
          ? CameraMode.ThirdPerson
          : CameraMode.FirstPerson;
    }

    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

    //control rotation around x axis (Look up and down)
    xRotation -= mouseY;

    //we clamp the rotation so we cant Over-rotate (like in real life)
    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    //control rotation around y axis (Look up and down)
    YRotation += mouseX;

    //applying both rotations
    transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f);

  }
}