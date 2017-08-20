using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class useHeroData
{


    [MenuItem("Custom Editor/Create Data Asset")]
    static void CreateDataAsset()
    {

        //資料 Asset 路徑
        string holderAssetPath = "Assets/HeroData/";

        if (!Directory.Exists(holderAssetPath)) Directory.CreateDirectory(holderAssetPath);

        //建立實體
        HeroData holder = ScriptableObject.CreateInstance<HeroData>();

        //使用 holder 建立名為 dataHolder.asset 的資源
        AssetDatabase.CreateAsset(holder, holderAssetPath + "dataHolder.asset");
    }
}