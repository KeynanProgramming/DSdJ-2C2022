using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Room",menuName ="Rooms/Stats",order = 0)]
public class RoomStats : ScriptableObject
{
    [SerializeField] private GameObject[] posibleRooms;
    public GameObject[] Rooms => posibleRooms;
    [SerializeField] private GameObject[] posibleEnemies;
    public GameObject[] Enemies => posibleEnemies;
    [SerializeField] private GameObject[] posibleObstacles;
    public GameObject[] Obstacles => posibleEnemies;
}
