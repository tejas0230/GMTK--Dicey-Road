using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject dice;
    public Vector3 dice_pos;
    public Vector3 cam_pos;
    [SerializeField]
    private float cam_x_offset=0;
    [SerializeField]
    private float cam_y_offset=0;
    [SerializeField]
    private float cam_z_offset=0;
    // Start is called before the first frame update
    void Start()
    {
        dice = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dice_pos = dice.transform.position;
        cam_pos = new Vector3(dice_pos.x+cam_x_offset,dice_pos.y+cam_y_offset,dice_pos.z+cam_z_offset);
        transform.position = cam_pos;
    }
}
