#region Author
/************************************************************************************************************
Author: BODEREAU Roy
Website: http://roy-bodereau.fr/
GitHub: https://github.com/Kardux
LinkedIn: be.linkedin.com/in/roybodereau
************************************************************************************************************/
#endregion

#region Copyright
/************************************************************************************************************
CC-BY-SA 4.0
http://creativecommons.org/licenses/by-sa/4.0/
Cette oeuvre est mise a disposition selon les termes de la Licence Creative Commons Attribution 4.0 - Partage dans les Memes Conditions 4.0 International.
************************************************************************************************************/
#endregion

using UnityEngine;
using System.Collections;

//////////////////////////////////////////////////////////////////////////
//CLASS
//////////////////////////////////////////////////////////////////////////
public class LightningBehaviour : MonoBehaviour
{
	#region Variables
	//////////////////////////////////////////////////////////////////////////
	//VARIABLES
	//////////////////////////////////////////////////////////////////////////
    public Transform m_StartPoint;
    public Transform m_EndPoint;

    public Material m_Material;

    public int m_Arcs;

    public int m_MinSegments;
    public int m_MaxSegments;

    public float m_MeanWidth;
    public float m_WidthOffsetPercentage;

    public float m_MeanAmplitude;
    public float m_AmplitudeOffsetPercentage;

    public float m_MeanFrequency;
    public float m_FrequencyOffsetPercentage;

    public Color m_MeanColor;
    public float m_ColorOffsetPercentage;
	//////////////////////////////////////////////////////////////////////////
	#endregion

	#region Handlers
	//////////////////////////////////////////////////////////////////////////
	//HANDLERS
	//////////////////////////////////////////////////////////////////////////
	void Start()
	{
        GameObject _ArcContainer = new GameObject("Arc_Container");
        _ArcContainer.transform.SetParent(transform);

        for (int i = 0; i < m_Arcs; i++)
        {
            GameObject _Arc = new GameObject("Lightning_Arc_" + i.ToString());
            _Arc.transform.SetParent(_ArcContainer.transform);
            _Arc.AddComponent<LineRenderer>();
            _Arc.AddComponent<LightningArc>();
            _Arc.GetComponent<LightningArc>().SetTransforms(m_StartPoint, m_EndPoint);
            _Arc.GetComponent<LightningArc>().SetMaterialColor(m_Material, new Color(
                Mathf.Abs(Random.Range(m_MeanColor.r * (1.0f - m_ColorOffsetPercentage), m_MeanColor.r * (1.0f + m_ColorOffsetPercentage))), 
                Mathf.Abs(Random.Range(m_MeanColor.g * (1.0f - m_ColorOffsetPercentage), m_MeanColor.g * (1.0f + m_ColorOffsetPercentage))), 
                Mathf.Abs(Random.Range(m_MeanColor.b * (1.0f - m_ColorOffsetPercentage), m_MeanColor.b * (1.0f + m_ColorOffsetPercentage)))));
            _Arc.GetComponent<LightningArc>().SetParameters(
                Random.Range(m_MinSegments, m_MaxSegments + 1),
                Random.Range(m_MeanWidth * (1.0f - m_WidthOffsetPercentage), m_MeanWidth * (1.0f + m_WidthOffsetPercentage)), 
                Random.Range(m_MeanAmplitude * (1.0f - m_AmplitudeOffsetPercentage), m_MeanAmplitude * (1.0f + m_AmplitudeOffsetPercentage)), 
                Random.Range(m_MeanFrequency * (1.0f - m_FrequencyOffsetPercentage), m_MeanFrequency * (1.0f + m_FrequencyOffsetPercentage)));
            _Arc.GetComponent<LightningArc>().Begin();
        }
	}
	
	void Update()
	{
	
	}
	//////////////////////////////////////////////////////////////////////////
	#endregion

	#region Methods
	//////////////////////////////////////////////////////////////////////////
	//METHODS
	//////////////////////////////////////////////////////////////////////////

	//////////////////////////////////////////////////////////////////////////
	#endregion
}
//////////////////////////////////////////////////////////////////////////