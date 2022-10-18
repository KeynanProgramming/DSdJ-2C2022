
using UnityEngine;

public class TemplateMaker : MonoBehaviour
{
    [SerializeField] private GameObject[] templates;

    private void Start()
    {
        Instantiate(templates[GetRandomRooms()], Vector3.zero, Quaternion.identity);
    }

    private int GetRandomRooms()
    {
        var index = Random.Range(0, templates.Length - 1);
        return index;
    }
}