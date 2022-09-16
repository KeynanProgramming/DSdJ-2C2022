using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private RoomStats stats;
    public void InstanceRoom()
    {
        var i = Random.Range(0, stats.Rooms.Length);
        var room = stats.Rooms[i];
        Instantiate(room, transform.position,Quaternion.identity);
    }
    private void InstaceEnemies()
    {
        
    }
}
