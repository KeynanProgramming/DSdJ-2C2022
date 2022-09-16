using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterC : MonoBehaviour
{
    private CharacterM _characterM;
    private float firingInterval;

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
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        if (h !=0 || v != 0)
        {
            _characterM.Move(new Vector3(h, 0, v));
        }
    }

    private void ShootUpdate()
    {
        firingInterval -= Time.deltaTime;
        if (firingInterval <= 0f)
        {
            if (Input.GetButton("Fire1"))
            {
                _characterM.Shoot();
                firingInterval = _characterM.Stats.TotalAttackSpeed;
            }
        }
    }
    
    private void LookAtMouse()
    {
        var lookAt = _characterM.GetMouseWorldPosition();
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);
    }
}
