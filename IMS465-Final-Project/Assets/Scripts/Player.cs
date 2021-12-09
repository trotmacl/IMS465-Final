using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool canMove;
    private bool canSnag;
    [SerializeField] private float moveCooldown;
    [SerializeField] private float snagCooldown;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        canSnag = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
