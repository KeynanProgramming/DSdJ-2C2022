using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.LevelGeneration;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private RoomSO roomToInstantiate;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        if (IsRoomOcupped())
        {
            Destroy(gameObject);
        }
        else
        {
             
            RoomInstance();
        }
    }

    private Room SelectRoom(Room[] roomArray)
    {
        int index = Random.Range(0, roomArray.Length);
        Room selectedRoom = roomToInstantiate.PosibleRooms[index];
        return selectedRoom;
    }
    private bool IsRoomOcupped()
    {
        int colliders = Physics.OverlapSphereNonAlloc(transform.position,2f,new Collider[1]);
        return colliders >= 1;
    }

    private void RoomInstance()
    {
        var newRoom = Instantiate(SelectRoom(roomToInstantiate.PosibleRooms), transform);
        LevelManager.Instance.lastRoom = newRoom;
    }

    public void CloseRoomInstance()
    {
        if (IsRoomOcupped())
        {
            return;
        }
        var newRoom =  Instantiate(SelectRoom(roomToInstantiate.CloseRooms), transform);
        LevelManager.Instance.lastRoom = newRoom;
    }
}
