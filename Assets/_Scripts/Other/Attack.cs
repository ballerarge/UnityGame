using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;

    Animator anim;
    Rigidbody rBody;
    
    // Start is called before the first frame update
    void Start()
    {
        anim=gameObject.GetComponent<Animator>();
        rBody=gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
