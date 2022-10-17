using System;
using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
        public static LevelManager Instance;
        [ReadOnly]public int currentIterations;
        [field: Space(30)]
        [field: SerializeField]public int MaxRooms { get; private set; }
        [ReadOnly]public int currentRoomCount;

        [SerializeField] private Room startRoom;

        [SerializeField] public Room lastRoom;
        private void Awake()
        {
                Instance = this;
        }

        private void Start()
        {
            var room = Instantiate(startRoom, Vector3.zero, Quaternion.identity);
            lastRoom = room;
            StartCoroutine(GenerateRooms());
        }

        public bool CanSpawnMoreRooms()
        {
            return currentRoomCount <= MaxRooms;
        }

        public bool HasToSpawnLastRooms()
        {
            return currentRoomCount +1 <= MaxRooms ;
        }

        IEnumerator GenerateRooms()
        {
            for (int i = 0; i < MaxRooms; i++)
            {
                lastRoom.Initialize();
                currentRoomCount++;
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitUntil(() => !CanSpawnMoreRooms());
            lastRoom.InstanceLastRooms();
        }
}