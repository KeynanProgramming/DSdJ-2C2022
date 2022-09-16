
using System.Collections.Generic;
using UnityEngine;
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Node[] nodes;
    private Transform playerSpawn;

    private void Start()
    {
        AsignateBossRoom();
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
        var index = Random.Range(0, nodes.Length);
        nodes[index].isBossRoom = true;
    }

}
