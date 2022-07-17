using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_slide : MonoBehaviour
{
    private GameObject dice;
    private Vector3 dice_pos;
   
    
    [SerializeField]
    private float cube_constant = 2f;

    public AnimationCurve anim;
    [SerializeField]
    private float addition_number = 100f;
    private float initial_add;
    //private float reduction_factor = 50f;
   
    
    [SerializeField]
    private float redux_factor = 2f;
    
    
    [SerializeField]
    private float ratio_denom = 200f;
    public bool pause = false;
    private bool begin_descent = false;
    private bool end = false;


    private Vector3 pos_a;
    private Vector3 pos_b;
    private float num = 0f;

    private int lastX = 0;
    private int lastZ = 0;

    public cubeMovement cubeScript;

    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        dice = GameObject.FindGameObjectWithTag("Player");
        initial_add = addition_number;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void slide(int x, int z, int roll)
    {
        pos_a = dice_pos;
        pos_b = new Vector3(dice_pos.x + (cube_constant * x*roll), dice_pos.y, dice_pos.z + (cube_constant * z*roll));
        pause = true;
        begin_descent = true;
        lastX = x;
        lastZ = z;
    }




    private void FixedUpdate()
    {
        dice_pos = dice.transform.position;

        if (begin_descent == true)
        {
            if ((lastX == 1 && cubeScript.isRight) || (lastX == -1 && cubeScript.isLeft) || (lastZ == 1 && cubeScript.isFront) || (lastZ == -1 && cubeScript.isBack))
            {
                begin_descent = false;
                addition_number = initial_add;

                pause = false;
            }

            dice.transform.position = Vector3.Lerp(pos_a, pos_b, Mathf.Min(num / ratio_denom, 1));

            if (num / ratio_denom >= 1 || addition_number <= 0)
            {
                begin_descent = false;
                pause = false;
            }
            num = num + addition_number;
            //addition_number = (addition_number) / redux_factor;
        }
        else
        {
            addition_number = initial_add;
            num = 0;

        }
    }
}
