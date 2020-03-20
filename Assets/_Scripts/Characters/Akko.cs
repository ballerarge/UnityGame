using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Akko : MonoBehaviour, ICharacter
{

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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
			moveForwards();
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

    public void moveForwards() {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
        transform.Translate(transform.forward * Time.deltaTime * move_speed, Space.World);
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

enum Directions {
        up,
        down,
        left,
        right
    }
