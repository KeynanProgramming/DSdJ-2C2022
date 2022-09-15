using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterC : MonoBehaviour
{
    private CharacterM _characterM;

    private void Awake()
    {
        _characterM = GetComponent<CharacterM>();
    }

    private void Update()
    {
        LookAtMouse();
        MoveUpdate();
        ShootUpdate();
    }

    private void MoveUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        if (h !=0 || v != 0)
        {
            _characterM.Move(new Vector3(h, 0, v));
        }
    }

    private void ShootUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _characterM.Shoot();
        }
    }
    
    private void LookAtMouse()
    {
        var lookAt = _characterM.GetMouseWorldPosition();
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);
    }
}
