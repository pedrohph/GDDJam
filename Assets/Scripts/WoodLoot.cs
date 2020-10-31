using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodLoot : MonoBehaviour
{
    Transform playerTransform;
    public float moveSpeed;


    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position,
            moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
