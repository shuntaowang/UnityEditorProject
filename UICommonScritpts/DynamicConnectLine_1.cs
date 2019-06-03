using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对两个对象之间进行动态连线
/// </summary>
public class DynamicConnectLine_1 : MonoBehaviour
{
    /// <summary>
    /// 左边的对象
    /// </summary>
    public Transform LeftObj;
    /// <summary>
    /// 右边的对象
    /// </summary>
    public Transform RightObj;

    /// <summary>
    /// 连线
    /// </summary>
    public Transform MiddleLineObj;
    UISprite MiddleLineObjSprite;
    // Use this for initialization
    void Start()
    {
        MiddleLineObjSprite = MiddleLineObj.GetComponent<UISprite>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
    }

    void DrawLine()
    {
        float x = (RightObj.localPosition.x - LeftObj.localPosition.x) / 2 + LeftObj.localPosition.x;
        float y = (RightObj.localPosition.y - LeftObj.localPosition.y) / 2 + LeftObj.localPosition.y;
        MiddleLineObj.localPosition = new Vector3(x, y, MiddleLineObj.localPosition.z);
        MiddleLineObj.localRotation = Quaternion.Euler(0, 0, GetAngle(LeftObj.localPosition, RightObj.localPosition));
        if (MiddleLineObjSprite)
        {
            float distance = Vector3.Distance(LeftObj.localPosition, RightObj.localPosition);
            MiddleLineObjSprite.width = (int)distance;
        }
    }
    
    /// <summary>
    /// 获取两个对象之间的角度值
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private float GetAngle(Vector3 a, Vector3 b)
    {
        if (a.x - b.x != 0 && a.y - b.y == 0)
        {
            return 0;
        }
        if (a.x - b.x == 0 && a.y - b.y != 0)
        {
            return 90;
        }
        float angle = Mathf.Atan((a.y - b.y) / (a.x - b.x)) * Mathf.Rad2Deg;
        return angle;
    }
}
