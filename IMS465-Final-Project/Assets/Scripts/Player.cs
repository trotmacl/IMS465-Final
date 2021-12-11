using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool canAttack;
    private bool canMove;
    private bool canSnag;
    public float hp;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float moveCooldown;
    [SerializeField] private float snagCooldown;
    [SerializeField] public Cell cell;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        canSnag = true;
        hp = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Get Raycast data
        RaycastHit mouseRay;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mouseRay)) {

            Cell hoverCell = mouseRay.collider.gameObject.GetComponent<Cell>();
            if (hoverCell != null) {
                //Check for Snag click
                if (Input.GetMouseButtonDown(1) && canSnag && cell.enemy == null) {
                    GameObject snagTarget = hoverCell.enemy;
                    snagTarget.transform.position = new Vector3(cell.enemyX, snagTarget.transform.position.y, cell.enemyZ);
                    hoverCell.enemy = null;
                    cell.enemy = snagTarget;
                    StartCoroutine(Snag());
                }

                //Check for Move click
                if (Input.GetMouseButtonDown(0) && canMove)
                {
                    transform.position = new Vector3(hoverCell.playerX, transform.position.y, hoverCell.playerZ);
                    cell = hoverCell;
                    StartCoroutine(Move());
                }
            }

        }
    }

    public void TakeDamage() {
        
    }

    IEnumerator Move() {
        canMove = false;
        yield return new WaitForSeconds(moveCooldown);
        canMove = true;
    }

    IEnumerator Snag() {
        canSnag = false;
        yield return new WaitForSeconds(snagCooldown);
        canSnag = true;
    }
}
