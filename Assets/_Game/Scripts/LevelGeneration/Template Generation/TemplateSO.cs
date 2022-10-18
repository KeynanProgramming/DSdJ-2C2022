using UnityEngine;

[CreateAssetMenu(fileName = "RoomTemplate", menuName = "Templates", order = 0)]
public class TemplateSO : ScriptableObject
{
    [field: SerializeField] public GameObject[] Obstacles { get; private set; }
    [field: SerializeField] public GameObject Chest { get; private set;  }
    [field: SerializeField] public GameObject Boss { get; private set; }
}