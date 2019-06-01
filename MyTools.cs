using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
public class MyTools
{
    #region 文件转移
    /// <summary>
    /// 测试
    /// </summary>
    [MenuItem("Assets/MakeFolder/ReomoveTextureToFolder/CommonUI")]
    static void CommonUI()
    {

        Object[] objects = Selection.GetFiltered<Object>(SelectionMode.Assets);

        foreach (Object item in objects)
        {
            string path = AssetDatabase.GetAssetPath(item);
            string pas = "Assets/Common/" + Path.GetFileName(path);
            AssetDatabase.MoveAsset(path, pas);
            AssetDatabase.Refresh();

            //Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(pas);
            //texture.alphaIsTransparency = true; 
            AssetDatabase.Refresh();
        }
    }
    #endregion
    #region 修改字体
    [MenuItem("MyTools/ChangeFont/FontToArial")]
    static void FontToArial()
    {
        foreach (var item in Selection.gameObjects)
        {
            
            if()
        }
    }
    #endregion
}
