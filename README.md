3D游戏中控制角色的一些技巧。包括让角色移动，跳跃；以及镜头的跟随。
将一些技巧记录在此：

1.将镜头固定在角色上：
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothing;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void Update()//update表示平台的帧数而fixedupdate表示现实时间的时间
    {
        Vector3 newCameraPos = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, newCameraPos, smoothing * Time.deltaTime);

    }

}
```

2.角色的移动：使用四个方向键：
```csharp
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

```


3.角色跳跃：按空格
```csharp
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
    /// 当没落地的时候不能重复起跳
    /// </summary>
    /// <param name="distance"></param>
    /// <returns></returns>
    public bool IsGrounded(float distance)
    {
        //distance：检测物体与地面的距离，
        //https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
        bool b = Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), -Vector3.up, distance);
        return b;
    }
}

```
此处注意要把角色的RigidBody中Constraints中的三个Rotation给Freeze掉，否则角色跳跃可能会翻倒。
