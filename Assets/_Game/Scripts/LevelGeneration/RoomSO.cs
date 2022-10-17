using UnityEngine;

namespace _Game.Scripts.LevelGeneration
{
    [CreateAssetMenu(fileName = "New Room Dispacement", menuName = "Rooms Displacement", order = 0)]
    public class RoomSO : ScriptableObject
    {
        [field: SerializeField] public Room[] PosibleRooms { get; private set; }
        [field: SerializeField] public Room[] CloseRooms { get; private set; }

    }
}