using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    public Transform objectToRotateAround;
    public int camRotSpeed;
    private bool isCamMoving;

    private Directions directions;

    void Start() {
        isCamMoving=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.x > Screen.width - 30 && (!isCamMoving ^ (directions==Directions.up))) {
            //up
            transform.RotateAround(objectToRotateAround.position, Vector3.up, camRotSpeed * Time.deltaTime);
            isCamMoving=true;
            directions = Directions.up;
        }
        else if (Input.mousePosition.x < 30 && (!isCamMoving ^ (directions==Directions.down))) {
            //down
            transform.RotateAround(objectToRotateAround.position, Vector3.down, camRotSpeed * Time.deltaTime);
            isCamMoving=true;
            directions = Directions.down;
        }
        else if (Input.mousePosition.y > Screen.height - 30 && (!isCamMoving ^ (directions==Directions.left))) {
            //left
            transform.RotateAround(objectToRotateAround.position, Vector3.left, camRotSpeed * Time.deltaTime);
            isCamMoving=true;
            directions = Directions.left;
        }
        else if (Input.mousePosition.y < 30 && (!isCamMoving ^ (directions==Directions.right))) {
            //right
            transform.RotateAround(objectToRotateAround.position, Vector3.right, camRotSpeed * Time.deltaTime);
            isCamMoving=true;
            directions = Directions.right;
        }
        else {
            isCamMoving=false;
        }
    }

    enum Directions {
        up,
        down,
        left,
        right
    }
}
