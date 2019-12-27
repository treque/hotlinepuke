using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    GameObject player;
    
    // look around feature
    bool bFollowPlayer = true;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (bFollowPlayer)
        {
            FollowPlayer();
        }
    }

    public void setFollowPlayer(bool b)
    {
        bFollowPlayer = b;
    }

    void FollowPlayer()
    {
        this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
    }
}