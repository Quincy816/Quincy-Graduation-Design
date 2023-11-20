using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Daziji : MonoBehaviour
{
    [Header("打字间隔时间")]
    public float speedTime = 0.1f;//打字间隔时间

    float timer;//计时器时间
    public Text TextCompnt;//Text文字组件
    int wordNumber;//文字数量
    bool isStart;//是否开始打字

    public string wordContent;//----文字内容
    public GameObject Thebtn;

    void Awake()
    {
        
        isStart = true;//bool值的默认值是false  所以这里要重置为true
        
    }

    void FixedUpdate()
    {
        StartTyping();
        if (Input.GetMouseButtonDown(0))
        {
            isStart = false;//停止打字
            TextCompnt.text = wordContent;
            Thebtn.SetActive(true);
        }
    }
    void StartTyping()
    {
        if (isStart)
        {
            timer += Time.deltaTime;//简单的计时器
            if (timer >= speedTime)//如果计时器时间>打字间隔时间
            {
                timer = 0;//重置
                wordNumber++;//文字数量+1

                //Substring() 官方文档解释：从此实例检索子字符串。 子字符串从指定的字符位置开始且具有指定的长度。
                TextCompnt.text = wordContent.Substring((0), wordNumber);//数字数量的起始字符位置（从零开始）
                if (wordNumber >= wordContent.Length)//数字数量=文字的长度
                {
                    isStart = false;//停止打字
                }
            }
        }
    }
}

