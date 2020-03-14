using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Respawn respawn;

    public Renderer Rend;
    public Material cpOff;
    public Material cpOn;

    void Start()
    {
        respawn = FindObjectOfType<Respawn>();
    }
    public void CheckpointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        foreach(Checkpoint cp in checkpoints)
        {
            cp.CheckpointOff();
        }
        Rend.material = cpOn;
    }
    public void CheckpointOff()
    {
        Rend.material = cpOff;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            respawn.setSpawnpoint(transform.position);
            CheckpointOn();
        }
    }
}
