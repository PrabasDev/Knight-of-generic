using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtckPlayer : MonoBehaviour
{
    private BoxCollider2D colliderAtckPlayer;
    // Start is called before the first frame update
    void Start()
    {
        colliderAtckPlayer = GameObject.Find("Atck").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.move < 0f)
        {
            colliderAtckPlayer.offset = new Vector2(-1.268671f,-0.08791494f);
        }
        else if(PlayerMovement.move > 0f){
            colliderAtckPlayer.offset = new Vector2(1.268671f,-0.08791494f);
        }
    }
}
