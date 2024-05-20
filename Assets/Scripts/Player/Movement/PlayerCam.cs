using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

public class PlayerCam : MonoBehaviour
{
    //public float sensX;
    //public float sensY;

    ///  public Transform orientation;
    public float xRotation;

    public float yRotation;

    public bool isControl;
      private void Start()
    {
        // #if UNITY_STANDALONE || UNITY_EDITOR
        //         // get mouse input
        //         Cursor.lockState = CursorLockMode.Locked;
        //         Cursor.visible = false;
        // #endif
        isControl = true;
        SetCam();
    }

    public void SetCam()
    {
        xRotation = Mathf.Clamp(xRotation, -70f, 50f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    private Vector2 lastPos;


    private void Update()
    {
        // if (Utils.IsPointerOverUIElement())
        //     return;
        if (!isControl)
            return;
        //if (PlayerController.instance.statePlayer == PlayerController.StatePlayer.Living)
        // {
        float mouseX = 0f;
        float mouseY = 0f;

        //#if UNITY_EDITOR
        // // get mouse input
        //if (Input.GetMouseButton(0))
        //{
        if (GameState.stateGame != StateGame.OpenStore)
        {

            mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * 35;
            mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 35;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -70f, 50f);
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        }
        //   }
        /*
        #elif UNITY_IOS || UNITY_ANDROID
                    // if (Touchscreen.current.touches.Count > 0 && Touchscreen.current.touches[0].isInProgress)
                    // {
                    //     mouseX = Touchscreen.current.touches[0].delta.ReadValue().x * Time.deltaTime * sensX;
                    //     mouseY = Touchscreen.current.touches[0].delta.ReadValue().y * Time.deltaTime * sensX;
                    // }

                    if (Input.touchCount > 0)
                    {
                        for (int i = 0; i < Input.touchCount; i++)
                        {
                            var touchPosition = Input.GetTouch(i).position;

                            if (!Utils.IsPointerOverUIElement(touchPosition))
                            {
                                if (Input.GetTouch(i).phase == TouchPhase.Began)
                                {
                                    lastPos = touchPosition;
                                }
                                else if (Input.GetTouch(i).phase == TouchPhase.Moved)
                                {
                                    var direct = touchPosition - lastPos;
                                    this.lastPos = touchPosition;
                                    direct /= 10;
                                    //     transform.localEulerAngles = new Vector3(direct.y, direct.x, 0);

                                    yRotation += direct.x;
                                    xRotation -= direct.y;
                                    xRotation = Mathf.Clamp(xRotation, -70f, 50f);

                                    // rotate cam and orientation
                                    transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
                                }

                                break;
                            }
                        }
                    }

        #endif
              //  }
        */
    }
}