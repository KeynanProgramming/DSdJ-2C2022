using System;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Node[] nodes;
    private Room father;
    public bool imTheLast;

    private void Start()
    {
        //Initialize();
        if (LevelManager.Instance.CanSpawnMoreRooms())
        {
            if (LevelManager.Instance.HasToSpawnLastRooms())
            {
                InstanceLastRooms();
            }
            else
            {
                InstanceRooms();

            }
        }
        // if (LevelManager.Instance.HasToSpawnLastRooms())
        // {
        //     Initialize();
        // }
    

    }

    public void Initialize()
    {
        if (LevelManager.Instance.HasToSpawnLastRooms())
        {
            InstanceLastRooms();
        }
        else
        {
            InstanceRooms();
        }
    }

    public void InstanceRooms()
    {
        foreach (var node in nodes)
        {
            LevelManager.Instance.currentIterations++;
            node.Initialize();
        }  
    }

    public void InstanceLastRooms()
    {
        foreach (var node in nodes)
        {
            LevelManager.Instance.currentIterations++;
            node.CloseRoomInstance();
        }  
    }
    
}