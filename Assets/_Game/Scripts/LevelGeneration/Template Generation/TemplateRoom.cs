using System;
using _Game.Scripts.LevelGeneration.Template_Generation;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class TemplateRoom : MonoBehaviour
{
    [SerializeField] private Transform[] obstacles;
    [SerializeField] private Transform chest;
    [SerializeField] private Transform bossSpawnPoint;
    [SerializeField] private RoomTemplatesSo roomTemplatesSo;
    public bool roomHasGenerated = false;
    public bool isSpawnPoint;

    private void Awake()
    {
        if (isSpawnPoint)
        {
            roomHasGenerated = true;
        }
    }

    public void GenerateNormalRoom()
    {
        foreach (var obstacleSpawnPoint in obstacles)
        {
            var index = Random.Range(0, roomTemplatesSo.Obstacles.Length);
            Instantiate(roomTemplatesSo.Obstacles[index], obstacleSpawnPoint.transform);
        }

        roomHasGenerated = true;
    }

    public void GenerateChestRoom()
    {
        Instantiate(roomTemplatesSo.Chest, chest.transform);
        roomHasGenerated = true;

    }

    public void GenerateBossRoom()
    {
        Instantiate(roomTemplatesSo.Boss, bossSpawnPoint);
        roomHasGenerated = true;

    }

}