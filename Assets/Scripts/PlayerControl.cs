using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;

    public BoxCollider2D coll;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        
    }

    public void t()
    {
        
    }
}
