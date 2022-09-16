using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private RoomStats stats;
    [SerializeField] private Transform[] obstaclesAnchors;
    [SerializeField] private Transform[] enemiesSpawnPoints;
    [SerializeField] public bool isBossRoom;
    public void InstanceRoom()
    {
        if (isBossRoom)
        {
            Instantiate(stats.BossRoomType, transform.position, Quaternion.identity);
            return;
        }
       // InstanceObstacles();
        var i = Random.Range(0, stats.Rooms.Length);
        var room = stats.Rooms[i];
        Instantiate(room, transform.position, Quaternion.identity);
    }
    private void InstanceEnemies()
    {
        
    }
    private void InstanceObstacles()
    {
        for (int i = 0; i < obstaclesAnchors.Length; i++)
        {
            var randomObstacle = Random.Range(0, stats.Obstacles.Length);
            Instantiate(stats.Obstacles[randomObstacle], obstaclesAnchors[i].position, Quaternion.identity);
        }
    }
}
