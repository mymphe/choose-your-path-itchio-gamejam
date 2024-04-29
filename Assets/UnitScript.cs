using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    private const float searchInterval = 100f;
    private float searchTimer = 0f;
    
    private int health = 100;
    private int damage = 20;
    private float moveSpeed = 5f;

    private const float searchRadius = 10f;

    [SerializeField] private LayerMask unitLayer;

    private void Update()
    {
        searchTimer -= Time.deltaTime;
        if (searchTimer < 0f)
        {
            searchTimer = searchInterval;
            //CapsuleCollider collider = Search();
            Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius, unitLayer);

            foreach (Collider collider in colliders)
            {
                Debug.Log(collider.GetComponentInParent<GameObject>().transform.position);
            }
            //Move();
            //Attack();
        }
    }

    //private CapsuleCollider Search() {
        
    //}

    //private void Move(Vector3 destination)
    //{

    //}

    //private void Attack()
    //{
    //    Debug.Log("Attacked!");
    //}
}
