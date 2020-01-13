using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Camera cam;
    Vector3 mousePos;
    Rigidbody  rid;
    
    // animation purposes
    public bool bIsMoving = false;

    float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsMoving)
        {
            transform.Translate(GetInputTranslationDirection() * speed * Time.deltaTime, Space.World);
        }
        UpdateIsMoving();
        CursorRotate();
    }

    void CursorRotate()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,  Input.mousePosition.z-cam.transform.position.z));
        rid.transform.eulerAngles = new Vector3(0, -Mathf.Atan2((mousePos.z - transform.position.z), (mousePos.x - transform.position.x))*Mathf.Rad2Deg, 0);
    }

    Vector3 GetInputTranslationDirection()
    {
        Vector3 direction = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        return direction;
    }
    
    void UpdateIsMoving()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W))
        {
            bIsMoving = true;
        }
        else
        {
            bIsMoving = false;
        }
    }
}
