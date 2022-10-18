using UnityEngine;

namespace _Game.Scripts.LevelGeneration.Template_Generation
{
    [CreateAssetMenu(fileName = "Room Template", menuName = "Templates", order = 0)]
    public class RoomTemplatesSo : ScriptableObject
    {
        [field: SerializeField] public GameObject[] Obstacles { get; private set; }
        [field: SerializeField] public GameObject Chest { get; private set;  }
        [field: SerializeField] public GameObject Boss { get; private set; }
    }
}