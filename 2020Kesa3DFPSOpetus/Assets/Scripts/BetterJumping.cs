using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJumping : MonoBehaviour
{
    PlayerMovement pMove;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    // Start is called before the first frame update
    void Start()
    {
        pMove = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pMove.velocity.y < 0)
        {
            pMove.velocity += Vector3.up * pMove.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(pMove.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            pMove.velocity += Vector3.up * pMove.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
