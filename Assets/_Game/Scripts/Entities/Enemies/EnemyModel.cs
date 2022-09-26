using System;
using UnityEngine;
 class EnemyModel : MonoBehaviour
 {
     public EnemySO data;
     public Rigidbody rb;
     protected Transform _transform;
     
     private void Awake()
     {
         rb = GetComponent<Rigidbody>();
         _transform = transform;
     }

     public virtual void Idle()
     {
         rb.velocity = Vector3.zero;
     }
     
     public virtual void Move(Vector3 dir)
     {
         rb.velocity = dir.normalized * data.speed;
     }

     public virtual void LookAt(Vector3 dir)
     {
         _transform.forward = dir.normalized;
     }

     public virtual void Attack()
     {
         
     }

     public virtual void Die()
     {
         
     }
     
     


 }
