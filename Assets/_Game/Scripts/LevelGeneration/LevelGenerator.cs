using System;
using System.Collections.Generic;
using UnityEngine;
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Node[] nodes;

    private void Start()
    {
        InstaceRooms();
    }

    void InstaceRooms()
    {
        foreach (var item in nodes)
        {
            item.InstanceRoom();
        }
    }
    void AsignateBossRoom()
    {

    }

}
