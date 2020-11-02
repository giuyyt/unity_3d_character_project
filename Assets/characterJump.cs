using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterJump : MonoBehaviour
{
    // Start is called before the first frame update
    public float force = 5f;//向角色上面添加的力的大小，决定能跳多高

    private Rigidbody myRigidbody;
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))//按下空格
        {
            //判断是否在地面上
            if (IsGrounded(1f)) 
            {
                myRigidbody.AddForce(new Vector3(0, force, 0), ForceMode.Impulse);
            }
        }
    }


    /// <summary>
    /// https://blog.csdn.net/lengyoumo/article/details/107015378
    /// </summary>
    /// <param name="distance"></param>
    /// <returns></returns>
    public bool IsGrounded(float distance)
    {
        //distance：检测物体与地面的距离
        //https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
        bool b = Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), -Vector3.up, distance);
        return b;
    }
}
