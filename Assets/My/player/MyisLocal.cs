using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//using MyPlayerController;

public class MyisLocal : NetworkBehaviour {

    private MyPlayerController fpsController;
    private Transform playerCameraTransform;
    private Camera playerCamera;
    private AudioListener playerAudioListener;

    void Start()
    {
        if (isLocalPlayer)
        {
            gameObject.name = "ME";
        }

        //當角色被產生出來時，如果不是Local Player就把所有的控制項目關閉，這些角色的位置資料將由Server來同步
        if (!isLocalPlayer)
        {
            fpsController = GetComponent<MyPlayerController>();
            playerCameraTransform = transform.Find("FirstPersonCharacter");
            playerCamera = playerCameraTransform.GetComponent<Camera>();
            playerAudioListener = playerCameraTransform.GetComponent<AudioListener>();

            if (fpsController)
            {
                fpsController.enabled = false;
            }
            if (playerCamera)
            {
                playerCamera.enabled = false;
            }
            if (playerAudioListener)
            {
                playerAudioListener.enabled = false;
            }
        }
    }

}
