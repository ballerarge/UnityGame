using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{

    void moveForwards();
    void moveBackwards();
    void moveLeft();
    void moveRight();
    void jump();
    void dance();
    void performAttack();


}
