using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    PlayerMovement player;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("JumpPad"))
        {
            player.jumpHeight = player.jumpHeightdefault;
            Debug.Log("Exit");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "JumpPad":
                Debug.Log("JumpPad");
                player.jumpHeight = 10f;
                player.velocity.y = Mathf.Sqrt(player.jumpHeight * -2 * player.gravity);
                break;
        }
    }

}
