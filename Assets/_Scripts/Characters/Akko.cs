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
    }

    public void moveForwards() {
        this.transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
    }

    public void moveBackwards() {
        this.transform.Translate(Vector3.back * Time.deltaTime, Space.World);
    }

    public void moveLeft() {
        this.transform.Translate(Vector3.left * Time.deltaTime, Space.World);
    }

    public void moveRight() {
        this.transform.Translate(Vector3.right * Time.deltaTime, Space.World);
    }

    public void jump() {
    }

    public void dance() {
    }

    public void performAttack() {
    }
}
