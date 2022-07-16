using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMovement : MonoBehaviour
{
    
   
    public float rollSpeed = 3f;
    public bool isMoving = false;
    
    int xDir, zDir;

    public CharacterController cubeController;
    public Player_slide playerSlideScript;
    public Dice_roll diceRollScript;
    public Transform ray_origin;
    public LayerMask groundLayer;


    public float gravity;
    
    [SerializeField]
    bool isGrounded;
    [SerializeField]
    bool isLeft;
    [SerializeField]
    bool isRight;
    [SerializeField]
    bool isFront;
    [SerializeField]
    bool isBack;

    [SerializeField]
    bool isTopLeft;
    [SerializeField]
    bool isTopRight;
    [SerializeField]
    bool isTopFront;
    [SerializeField]
    bool isTopBack;


    bool isBreak = false;

    public float length = 1.5f;
    
    void Update()
    {

       
        isGrounded = Physics.Raycast(ray_origin.position,Vector3.down,length, groundLayer);
        
        isLeft = Physics.Raycast(ray_origin.position, Vector3.left, 1.5f, groundLayer);
        isRight = Physics.Raycast(ray_origin.position, Vector3.right, 1.5f, groundLayer);
        isFront = Physics.Raycast(ray_origin.position, Vector3.forward, 1.5f, groundLayer);
        isBack = Physics.Raycast(ray_origin.position, Vector3.back, 1.5f, groundLayer);

        isTopLeft = Physics.Raycast(ray_origin.position+new Vector3(0,2,0), Vector3.left, 1.5f, groundLayer);
        isTopRight = Physics.Raycast(ray_origin.position + new Vector3(0, 2, 0), Vector3.right, 1.5f, groundLayer);
        isTopFront = Physics.Raycast(ray_origin.position + new Vector3(0, 2, 0), Vector3.forward, 1.5f, groundLayer);
        isTopBack = Physics.Raycast(ray_origin.position + new Vector3(0, 2, 0), Vector3.back, 1.5f, groundLayer);

       
        if (isMoving)
        {
            return;
        }
        if (!isMoving && !playerSlideScript.pause && isGrounded)
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round( transform.position.y), Mathf.Round( transform.position.z));
        }

        if(isLeft && isRight)
        {
            Front();
            Back();
        }
        else if(isFront&&isBack)
        {
            Right();
            Left();
        }
        else
        {
            Front();
            Back();
            Right();
            Left();
        }
        
        
        
        if (!isGrounded && !isMoving)
        {
            gameObject.transform.position += new Vector3(0, -0.5f, 0);
        }


    }


    void Front()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

            if (isFront)
            {
                if (isTopFront)
                {
                    var wallAnchor = transform.position + new Vector3(0, 1, 1);
                    var wallAxis = Vector3.Cross(Vector3.up, Vector3.forward);
                    xDir = 0;
                    zDir = 1;
                    StartCoroutine(roll(wallAnchor, wallAxis));
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        var wallAnchor = transform.position + new Vector3(0, 1, 1);
                        var wallAxis = Vector3.Cross(Vector3.up, Vector3.forward);
                        xDir = 0;
                        zDir = 1;
                        StartCoroutine(roll(wallAnchor, wallAxis));
                    }
                }
            }
            else
            {
                var anchor = transform.position + new Vector3(0f, -1f, 1f);
                var axis = Vector3.Cross(Vector3.up, Vector3.forward);
                xDir = 0;
                zDir = 1;
                StartCoroutine(roll(anchor, axis));
            }

        }
    }

    void Back()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isBack)
            {
                if (isTopBack)
                {
                    var wallAnchor = transform.position + new Vector3(0, 1, -1);
                    var wallAxis = Vector3.Cross(Vector3.up, -Vector3.forward);
                    xDir = 0;
                    zDir = -1;
                    StartCoroutine(roll(wallAnchor, wallAxis));
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        var wallAnchor = transform.position + new Vector3(0, 1, -1);
                        var wallAxis = Vector3.Cross(Vector3.up, -Vector3.forward);
                        xDir = 0;
                        zDir = -1;
                        StartCoroutine(roll(wallAnchor, wallAxis));

                    }
                }

            }
            else
            {
                var anchor = transform.position + new Vector3(0f, -1f, -1f);
                var axis = Vector3.Cross(Vector3.up, -Vector3.forward);
                xDir = 0;
                zDir = -1;
                StartCoroutine(roll(anchor, axis));
            }

        }
    }

    void Right()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {

            if (isRight)
            {
                if (isTopRight)
                {
                    var wallAnchor = transform.position + new Vector3(1, 1, 0);
                    var wallAxis = Vector3.Cross(Vector3.up, Vector3.right);
                    xDir = 1;
                    zDir = 0;
                    StartCoroutine(roll(wallAnchor, wallAxis));
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        var wallAnchor = transform.position + new Vector3(1, 1, 0);
                        var wallAxis = Vector3.Cross(Vector3.up, Vector3.right);
                        xDir = 1;
                        zDir = 0;
                        StartCoroutine(roll(wallAnchor, wallAxis));
                    }
                }

            }
            else
            {
                var anchor = transform.position + new Vector3(1f, -1f, 0);
                var axis = Vector3.Cross(Vector3.up, Vector3.right);
                xDir = 1;
                zDir = 0;
                StartCoroutine(roll(anchor, axis));
            }


        }

    }

    void Left()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (isLeft)
            {

                if (isTopLeft)
                {
                    var wallAnchor = transform.position + new Vector3(-1, 1, 0);
                    var wallAxis = Vector3.Cross(Vector3.up, Vector3.left);
                    xDir = -1;
                    zDir = 0;
                    StartCoroutine(roll(wallAnchor, wallAxis));
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {

                        var wallAnchor = transform.position + new Vector3(-1, 1, 0);
                        var wallAxis = Vector3.Cross(Vector3.up, Vector3.left);
                        xDir = -1;
                        zDir = 0;
                        StartCoroutine(roll(wallAnchor, wallAxis));
                    }
                }

            }
            else
            {
                var anchor = transform.position + new Vector3(-1f, -1f, 0);
                var axis = Vector3.Cross(Vector3.up, Vector3.left);
                xDir = -1;
                zDir = 0;
                StartCoroutine(roll(anchor, axis));
            }
        }
    }
    IEnumerator roll(Vector3 anchor,Vector3 axis)
    {
        isMoving = true;
        for(int i=0;i<(90/rollSpeed);i++)
        {
            transform.RotateAround(anchor,axis,rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
       // playerSlideScript.slide(xDir,zDir);
        diceRollScript.roll_dice(xDir,zDir);
        isMoving = false;
        /*isBreak = true;*/
        
    }

    
    
   
}
