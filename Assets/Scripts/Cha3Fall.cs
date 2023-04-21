using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cha3Fall : MonoBehaviour
{
    Animator animator;
    // 每一帧都执行move移动,没有单独写PlayerController脚本,Move是一个输入量,默认是0~1之间   如果不按的话就是0
    Vector3 move;
    CharacterController cc;   // 玩家控制器
    public float speed = 3;
    [Range(0.0f,1.0f)]
    public float testSpeed = 1;
    bool isGround = true;
    float vy = 0;  // vy是记录在纵向的时候的速度大小

    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, 0, v);

        // 更新动画
        UpdateAnim();
    }
    void Move(float x, float y, float z)
    {
        move = new Vector3(x, 0, z);

        // 这一帧移动的向量,很小
        Vector3 FrameMove = move * speed * Time.deltaTime;

        if (isGround) { vy = 0; }   // vy会影响这一帧的位移
        else { vy += Physics.gravity.y * Time.deltaTime; }  // v = gt 重力加速度

        // 这一帧的小位移y = 速度vy * 这一帧的时间
        FrameMove.y = vy * Time.deltaTime;

        // 朝向移动方向
        transform.LookAt(transform.position + FrameMove);

        // 通过cc去移动，而不是直接改transform
        cc.Move(FrameMove);
    }

    private void FixedUpdate()
    {
        // 从脚底20cm往上的位置向下打一条射线
        // 这里重载的前面是起始点，后面是方向
        Ray ray = new Ray(transform.position + new Vector3(0, 0.2f, 0), Vector3.down);
        RaycastHit hit;   // 射线信息
        Color c = Color.white;   // 没有打中的时候,默认颜色是白色
        isGround = false;
        if(Physics.Raycast(ray,out hit,0.35f))
        {
            c = Color.red;   // 如果打中，颜色改成红色
            isGround = true;
        }
        Debug.DrawLine(transform.position + new Vector3(0, 0.2f, 0), transform.position - new Vector3(0, 0.15f, 0),c);
    }


    // 更新动画函数
    void UpdateAnim()
    {
        //animator.SetFloat("Forward", move.magnitude);
        animator.SetFloat("Forward", cc.velocity.magnitude / speed * testSpeed);
    }
}
