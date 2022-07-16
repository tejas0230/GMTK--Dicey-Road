using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice_roll : MonoBehaviour
{
    public int initial_roll=6;
    public int roll = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void roll_dice(int x, int z)
    {
        if (roll % 2 == 0)
        {
            if (x == 1)
            {
                roll = (roll + 2) % 6;
            }
            else if (x == -1)
            {
                roll = (roll - 1) % 6;
            }
            if(z == 1)
            {
                roll = (roll - 2) % 6;
            }
            else if (z == -1)
            {
                roll = (roll + 1) % 6;
            }
        }
        else
        {
            if (x == 1)
            {
                roll = (roll + 2) % 6;
            }
            else if (x == -1)
            {
                roll = (roll + 1) % 6;
            }
            if(z == 1)
            {
                roll = (roll - 2) % 6;
            }
            else if (z == -1)
            {
                roll = (roll - 1) % 6;
            }
        }
        if(roll==0)
        {
            roll = 6;
        }
    }

}
