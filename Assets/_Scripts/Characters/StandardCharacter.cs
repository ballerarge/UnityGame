using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardCharacter : MonoBehaviour, ICharacter
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


    // Start is called before the first frame update
    void Start()
    {
        health=starting_health;
        mAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
			moveForwards();
        }

        if(Input.GetKeyUp(KeyCode.W)) {
            mAnim.SetTrigger("Idle");
        }
        
        if (Input.GetKey(KeyCode.W)) {
            faceCamera();
        }

		if (Input.GetKey(KeyCode.S)) {
			moveBackwards();
        }

        if (Input.GetKey(KeyCode.A)) {
            moveLeft();
        }

        if (Input.GetKey(KeyCode.D)) {
            moveRight();
        }

        if (Input.GetKey(KeyCode.Space)) {
            jump();
        }
    }

    public void faceCamera() {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    public void moveForwards() {
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
        //transform.Translate(transform.forward * Time.deltaTime * move_speed, Space.World);
        mAnim.SetTrigger("Running");
        
    }

    public void moveBackwards() {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
        transform.Translate(-1 * transform.forward * Time.deltaTime * move_speed, Space.World);
    }

    public void moveLeft() {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
        transform.Translate(-1 * transform.right * Time.deltaTime * move_speed, Space.World);
    }

    public void moveRight() {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
        transform.Translate(transform.right * Time.deltaTime * move_speed, Space.World);
    }

    public void jump() {
    }

    public void dance() {
    }

    public void performAttack() {
    }
}
