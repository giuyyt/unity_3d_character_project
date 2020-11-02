using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{

    public float speed = 1.5f;//控制移动速度
    private Transform m_transform;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //均为局部坐标
        //向左
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            m_transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        //向右
        if (Input.GetKey(KeyCode.RightArrow))
        {

            m_transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        //向前
        if (Input.GetKey(KeyCode.UpArrow))
        {

            m_transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        //向后
        if (Input.GetKey(KeyCode.DownArrow))
        {

            m_transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
