
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TemplateRoomStorer : MonoBehaviour
{
    [SerializeField] private TemplateRoom[] possibleBossRooms;
    [ReadOnly] private TemplateRoom chestRoom;
    [SerializeField] private TemplateRoom[] normalRooms;
    [SerializeField] private int chestRoomsQuantity;
    [SerializeField] private GameObject playerPrefab;
    private void Start()
    {
        SpawnPlayer();
        for (int i = 0; i < chestRoomsQuantity; i++)
        {
            SortRooms();
        }
        
        RandomizeBossRooms();
        RandomizeChestRooms();
        RandomizeDefaultRooms();
    }

    private void SpawnPlayer()
    {
        foreach (var room in normalRooms)
        {
            if (room.isSpawnPoint)
            {
                Instantiate(playerPrefab, room.transform.position,Quaternion.identity);
                break;
            }
        }
    }

    private void SortRooms()
    {
        var newChestRoom = Random.Range(0, normalRooms.Length);
        if(!normalRooms[newChestRoom].isSpawnPoint)
          chestRoom = normalRooms[newChestRoom];
    }

    private void RandomizeBossRooms()
    {
        var room = possibleBossRooms[GetRandomIndex(possibleBossRooms.Length)];
        room.GenerateBossRoom();
    }

    private void RandomizeDefaultRooms()
    {
        foreach (var templateRoom in normalRooms)
        {
            if(!templateRoom.roomHasGenerated)
                templateRoom.GenerateNormalRoom();
        }
    }

    private void RandomizeChestRooms()
    {
        if(chestRoom != null)
            chestRoom.GenerateChestRoom();
    }

    private int GetRandomIndex(int lenght)
    {
        return Random.Range(0, lenght);
    }
}