using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTargetMover : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private EnemyType myType;
    [SerializeField] private float distanceToStop = 2f;

    PlayerShipInput debugTransformTarget;

    [SerializeField] private ShipController controller;
    [SerializeField] private CannonController cannonController;
    public List<Vector2> path = new List<Vector2>();

    Vector3 targetPos;
    int actualNode;
    float distanceToTarget;

    bool forward;
    bool left;
    bool right;

    // Start is called before the first frame update
    void Awake()
    {
        debugTransformTarget = FindObjectOfType<PlayerShipInput>();
        if(myType == EnemyType.Chaser)
        {
            distanceToStop = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(debugTransformTarget)
        {
            targetPos = debugTransformTarget.transform.position;
            if (path.Count > 0)
            {
                float distanceToNextNode = Vector2.Distance(transform.position, path[actualNode]);
                distanceToTarget = Vector2.Distance(transform.position, targetPos);


                Vector2 dirToMovePosition = (path[actualNode] - (Vector2)transform.position).normalized;

                float dot = Vector2.Dot(transform.up, dirToMovePosition);
                if (dot > 0)
                {
                    forward = true;
                }
                else if (dot < 0)
                {
                    forward = false;
                }

                float angleToDir = Vector2.SignedAngle(transform.up, dirToMovePosition);

                if (angleToDir < 3 && angleToDir > -3)
                {
                    left = false;
                    right = false;
                }
                else
                {
                    if (angleToDir > 0)
                    {
                        left = false;
                        right = true;
                    }
                    else
                    {
                        left = true;
                        right = false;
                    }
                }

                if (distanceToTarget < distanceToStop)
                {
                    forward = false;
                    float aim = Vector2.SignedAngle(transform.up, dirToMovePosition);
                    if (myType == EnemyType.Shooter && (aim < 2 && aim > -2))
                    {
                        cannonController.ShootFrontCannon();
                    }
                }

                if (distanceToNextNode < 1f)
                {
                    actualNode++;
                    if (actualNode > path.Count - 1)
                    {
                        actualNode = path.Count - 1;
                    }
                }
            }



            controller.moving = forward;
            controller.turnLeft = left;
            controller.turnRight = right;
        }


    }


    public void DefinePath(List<Vector2> newPath)
    {
        path = newPath;
        actualNode = 0;
    }
}

public enum EnemyType
{
    Shooter, Chaser
}

