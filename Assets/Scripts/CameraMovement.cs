using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    GameObject player;
    Camera cam;
    PlayerMovement pm;
    
    // look around feature
    bool bFollowPlayer = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerMovement>();
        cam = Camera.main;
    }

    void Update()
    {
        bFollowPlayer = Input.GetKey(KeyCode.LeftShift) ? false : true;
        // maybe merge these two sections together
        if (bFollowPlayer)
        {
            FollowPlayer();
        }
        else
        {
            lookAhead();
        }
    }

    // deprecated?
    public void setFollowPlayer(bool follow)
    {
        bFollowPlayer = follow;
    }

    void FollowPlayer()
    {
        this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
    }

    void lookAhead()
    {
        Vector3 cameraPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.z));
        cameraPos.y = 10; // the z axis of the MainCamera
        Vector3 dir = cameraPos - this.transform.position; // mouse to cam
        if (player.GetComponent<MeshRenderer>().isVisible)
        {
            transform.Translate(dir*2*Time.deltaTime);
        }
    }
}