using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodLoot : MonoBehaviour
{
    Transform playerTransform;
    public float moveSpeed;
    public GameObject particle;

    public delegate void PlayLootSFX(AudioClip clip);
    public event PlayLootSFX lootPlayedSFX;

    public delegate void CollectLoot();
    public event CollectLoot CollectedLoot;

    public AudioClip clip;

    protected void OnEnable()
    {
        AudioManager am = FindObjectOfType<AudioManager>();
        am.ListenSoundsFromLoots(this);

        GameManager gm = FindObjectOfType<GameManager>();
        gm.addLoot();
    }

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position,
                moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(particle, other.gameObject.transform.position,Quaternion.identity) ;
            if(lootPlayedSFX != null)
            {
                lootPlayedSFX(clip);
            }
            if (CollectedLoot != null)
            {
                CollectedLoot();
            }

            Destroy(gameObject);
        }
    }
}
