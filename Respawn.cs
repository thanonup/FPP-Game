using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public PlayerMovement thePlayer;
    private Vector3 respawnpoint;
    private bool isRespawning;

    private void Start()
    {
        respawnpoint = thePlayer.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        Respawn1();
    }
    public void Respawn1()
    {
        CharacterController cc = thePlayer.GetComponent<CharacterController>();
        cc.enabled = false;
        thePlayer.transform.position = respawnpoint;       
        cc.enabled = true;
    }
    public void setSpawnpoint(Vector3 newPosition)
    {
        respawnpoint = newPosition;       
    }

}
