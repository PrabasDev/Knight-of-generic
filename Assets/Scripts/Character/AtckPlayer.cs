using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtckPlayer : MonoBehaviour
{
    private BoxCollider2D colliderAtckPlayer;
    private BoxCollider2D cap2;
    public BoxCollider2D cap3;
    public BoxCollider2D cap4;

    // Start is called before the first frame update
    void Start()
    {
        colliderAtckPlayer = GameObject.Find("Atck").GetComponent<BoxCollider2D>();
        cap2 = GameObject.Find("Atck3").GetComponent<BoxCollider2D>();
        cap3 = GameObject.Find("Atck4").GetComponent<BoxCollider2D>();
        cap4 = GameObject.Find("Atck4_2").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.move < 0f)
        {
            colliderAtckPlayer.offset = new Vector2(-1.268671f,-0.08791494f);
            cap2.offset = new Vector2(-1.58463f, -0.0430101f);
            cap3.offset = new Vector2(-1.54f, -0.0430101f);
            cap4.offset = new Vector2(-2.28f, -0.0430101f);
        }
        else if(PlayerMovement.move > 0f){
            colliderAtckPlayer.offset = new Vector2(1.268671f,-0.08791494f);
            cap2.offset = new Vector2(1.58463f, -0.0430101f);
            cap3.offset = new Vector2(1.54f, -0.0430101f);
            cap4.offset = new Vector2(2.28f, -0.0430101f);
        }
    }
}
