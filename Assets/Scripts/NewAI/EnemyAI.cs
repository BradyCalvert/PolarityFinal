using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public int damage;
    [Tooltip("The enemy will shoot once every [shoot delay] seconds")]
    public int shootDealy;

    public Transform[] waypoints;
    [HideInInspector]
    public int currWaypoint;
    [HideInInspector]
    public GameObject player;

    public float shootRange;
    public float chaseRange;
    public float closeEnoughDistance = 3f;
    Animator anim;

    bool playerInSight, playerCloseEnoughToShoot, playerInChaseRange;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        player = Magnet_Manager.instance.player;
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit hit;
        Vector3 playerDir = player.transform.position - transform.position;
        Ray checkRay = new Ray(transform.position, playerDir);
        //In Sight
        if (Physics.Raycast(checkRay.origin, checkRay.direction, out hit))
        {
            if (hit.transform.name == "Player")
            {
                playerInSight = true;
            }
            else
                playerInSight = false;
        }
        else
            playerInSight = false;

        //close enough to shoot
        if (Vector3.Distance(transform.position, player.transform.position) < shootRange)
            playerCloseEnoughToShoot = true;
        else
            playerCloseEnoughToShoot = false;

        //in range to shoot
        if (Vector3.Distance(transform.position, player.transform.position) < chaseRange)
                playerInChaseRange = true;
        else
            playerInChaseRange = false;

        if (Vector3.Distance(transform.position, waypoints[currWaypoint].position) < 3)
        {
            anim.SetTrigger("getNewPoint");
        }

        anim.SetBool("playerInSight", playerInSight);
        anim.SetBool("playerCloseEnoughToShoot", playerCloseEnoughToShoot);
        anim.SetBool("playerInChaseRange", playerInChaseRange);
    }

    private void OnDrawGizmos()
    {
        //if(player == null)
        //{
        //    GameObject tempPLayer = GameObject.Find("Player");
        //    Vector3 playerDir = player.transform.position - transform.position;
        //    Ray checkRay = new Ray(transform.position, playerDir);

        //    Gizmos.DrawRay(checkRay);
        //}
        if(shootRange != 0)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, shootRange);
        }

        if (chaseRange != 0)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseRange);
        }
        if (closeEnoughDistance != 0)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, closeEnoughDistance);
        }

    }
}
