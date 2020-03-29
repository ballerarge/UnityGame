using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardCharacter : MonoBehaviour
{
    Animator mAnim;
    private string charName;
    public int health;
    public int move_speed;
    readonly int starting_health = 100;
    public GameObject physAttack;
    public GameObject specialAttack1;
    public GameObject specialAttack2;
    public GameObject ultAttack;

    private MovementDirection directionState;

    // Start is called before the first frame update
    void Start()
    {
        health=starting_health;
        mAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        directionState = new MovementDirection(mAnim);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
            faceCamera();
        }

        directionState.checkDirection(mAnim);

    }

    public void faceCamera() {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    public void jump() {
    }

    public void dance() {
    }

    public void performAttack() {
    }
}

public class MovementDirection {
    private Direction currentDirection;
    private bool forward;
    private bool backward;
    private bool left;
    private bool right;

    public MovementDirection(Animator mAnim) {
        forward = false;
        backward = false;
        left = false;
        right = false;
        currentDirection = Direction.none;
        mAnim.SetTrigger("Idle");
    }

    public void checkDirection(Animator mAnim) {
        if (Input.GetKeyDown(KeyCode.W)) {
            moveForward(mAnim);
        }

        if (Input.GetKeyUp(KeyCode.W)) {
            stopMovingForward(mAnim);
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            moveLeft(mAnim);
        }

        if (Input.GetKeyUp(KeyCode.A)) {
            stopMovingLeft(mAnim);
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            moveBackwards(mAnim);
        }

        if (Input.GetKeyUp(KeyCode.S)) {
            stopMovingBackwards(mAnim);
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            moveRight(mAnim);
        }

        if (Input.GetKeyUp(KeyCode.D)) {
            stopMovingRight(mAnim);
        }
    }

    public void moveForward(Animator mAnim) {
        forward = true;
        currentDirection = Direction.forward;
        mAnim.SetTrigger("Running");
    }
    public void stopMovingForward(Animator mAnim) {
        forward = false;
        determineCurrentDirection(mAnim);
    }
    public void moveBackwards(Animator mAnim) {
        backward = true;
        currentDirection = Direction.backward;
        mAnim.SetTrigger("RunningBackwards");
    }
    public void stopMovingBackwards(Animator mAnim) {
        backward = false;
        determineCurrentDirection(mAnim);
    }
    public void moveLeft(Animator mAnim) {
        left = true;
        currentDirection = Direction.left;
        mAnim.SetTrigger("RunLeft");
    }
    public void stopMovingLeft(Animator mAnim) {
        left = false;
        determineCurrentDirection(mAnim);
    }
    public void moveRight(Animator mAnim) {
        right = true;
        currentDirection = Direction.right;
        mAnim.SetTrigger("RunRight");
    }
    public void stopMovingRight(Animator mAnim) {
        right = false;
        determineCurrentDirection(mAnim);
    }

    public Direction getCurrentDirection() {
        return currentDirection;
    }

    private void determineCurrentDirection(Animator mAnim) {
        if (forward) {
            currentDirection = Direction.forward;
            mAnim.SetTrigger("Running");
        } else if (backward) {
            currentDirection = Direction.backward;
            mAnim.SetTrigger("RunningBackwards");
        } else if (left) {
            currentDirection = Direction.left;
            mAnim.SetTrigger("RunLeft");
        } else if (right) {
            currentDirection = Direction.right;
            mAnim.SetTrigger("RunRight");
        } else {
            currentDirection = Direction.none;
            mAnim.SetTrigger("Idle");
        }
    }
}

public enum Direction {
    forward,
    backward,
    left,
    right,
    none
}
