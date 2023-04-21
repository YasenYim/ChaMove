using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cha3 : MonoBehaviour
{
    Animator animator;
    // 每一帧都执行move移动,没有单独写PlayerController脚本,Move是一个输入量,默认是0~1之间,如果不按的话就是0
    Vector3 move;
    CharacterController cc;   // 玩家控制器

    public float speed = 3;

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
        move = new Vector3(x, y, z);
        // 这一帧移动的向量,很小
        Vector3 m = move * speed * Time.deltaTime;

        // 朝向移动方向
        transform.LookAt(transform.position + m);

        // 通过cc去移动，而不是直接改transform
        cc.Move(m);
    }

   

    // 更新动画函数
    void UpdateAnim()
    {
        //animator.SetFloat("Forward", move.magnitude);
        animator.SetFloat("Forward", cc.velocity.magnitude / speed);
       
    }
}
