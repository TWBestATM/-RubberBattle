using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPUI : MonoBehaviour {
    [SerializeField]
    private Image m_Image;

	// Use this for initialization
	void Start () {
	}
    /// <summary>
    /// 跟新血量
    /// </summary>
    /// <param name="percent">血量百分比</param>
    public void UpdateHPUI(float percent)
    {
        m_Image.fillAmount = percent;
    }
}
