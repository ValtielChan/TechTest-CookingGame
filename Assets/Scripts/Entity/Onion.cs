using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : Enemy
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        // Walk toward the player
        transform.position += transform.forward * Time.deltaTime * walkSpeed;
    }
}
