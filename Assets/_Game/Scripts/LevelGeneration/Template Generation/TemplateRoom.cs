using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class TemplateRoom : MonoBehaviour
{
    [SerializeField] private Transform[] obstacles;
    [SerializeField] private Transform chest;
    [SerializeField] private Transform bossSpawnPoint;
    [FormerlySerializedAs("roomTemplatesSo")] [SerializeField] private TemplateSO templateSo;
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
            var index = Random.Range(0, templateSo.Obstacles.Length);
            Instantiate(templateSo.Obstacles[index], obstacleSpawnPoint.transform);
        }

        roomHasGenerated = true;
    }

    public void GenerateChestRoom()
    {
        Instantiate(templateSo.Chest, chest.transform);
        roomHasGenerated = true;

    }

    public void GenerateBossRoom()
    {
        Instantiate(templateSo.Boss, bossSpawnPoint);
        roomHasGenerated = true;

    }

}