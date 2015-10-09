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
public class LightningArc : MonoBehaviour
{
	#region Variables
	//////////////////////////////////////////////////////////////////////////
	//VARIABLES
	//////////////////////////////////////////////////////////////////////////
    public enum ArcMode { SingleSide, BothSide, MiddleAllowed };

    private LineRenderer m_LR;

    private Transform m_StartTransform;
    private Transform m_EndTransform;

    private Material m_Material;
    private Color m_Color;

    private ArcMode m_Mode;

    private int m_Segments;

    private Vector3 m_Amplitude;

    private float m_Width;
    private float m_Frequency;

    private float m_Timer;

	//////////////////////////////////////////////////////////////////////////
	#endregion

	#region Handlers
	//////////////////////////////////////////////////////////////////////////
	//HANDLERS
	//////////////////////////////////////////////////////////////////////////
	void Update()
	{
        m_Timer += Time.deltaTime;
        if (m_Timer < 1.0f / m_Frequency)
        {
            return;
        }

        m_Timer -= 1.0f / m_Frequency;

        switch (Random.Range(0, (int)m_Mode + 1))
        {
            case 0 :
                for (int i = 0; i < m_Segments; i++)
                {
                    Vector3 _TmpAmplitude = (1.0f - Mathf.Abs(i - (m_Segments - 1) * 0.5f) / ((m_Segments - 1) * 0.5f)) * m_Amplitude;
                    m_LR.SetPosition(i, m_StartTransform.position + (m_EndTransform.position - m_StartTransform.position) * ((float)i / (m_Segments - 1)) + new Vector3(
                        Random.Range(0, _TmpAmplitude.x),
                        Random.Range(0, _TmpAmplitude.y),
                        Random.Range(0, _TmpAmplitude.z)));
                }
                break;

            case 1:
                for (int i = 0; i < m_Segments; i++)
                {
                    Vector3 _TmpAmplitude = (1.0f - Mathf.Abs(i - (m_Segments - 1) * 0.5f) / ((m_Segments - 1) * 0.5f)) * m_Amplitude;
                    m_LR.SetPosition(i, m_StartTransform.position + (m_EndTransform.position - m_StartTransform.position) * ((float)i / (m_Segments - 1)) + new Vector3(
                        Random.Range(0, -_TmpAmplitude.x),
                        Random.Range(0, -_TmpAmplitude.y),
                        Random.Range(0, -_TmpAmplitude.z)));
                }
                break;

            case 2 :
                for (int i = 0; i < m_Segments; i++)
                {
                    Vector3 _TmpAmplitude = (1.0f - Mathf.Abs(i - (m_Segments - 1) * 0.5f) / ((m_Segments - 1) * 0.5f)) * m_Amplitude;
                    m_LR.SetPosition(i, m_StartTransform.position + (m_EndTransform.position - m_StartTransform.position) * ((float)i / (m_Segments - 1)) + new Vector3(
                        Random.Range(- _TmpAmplitude.x * 0.5f, _TmpAmplitude.x * 0.5f),
                        Random.Range(- _TmpAmplitude.y * 0.5f, _TmpAmplitude.y * 0.5f),
                        Random.Range(- _TmpAmplitude.z * 0.5f, _TmpAmplitude.z * 0.5f)));
                }
                break;
        }
	}
	//////////////////////////////////////////////////////////////////////////
	#endregion

	#region Methods
	//////////////////////////////////////////////////////////////////////////
	//METHODS
	//////////////////////////////////////////////////////////////////////////
    public void SetTransforms(Transform StartTransform, Transform EndTransform)
    {
        m_StartTransform = StartTransform;
        m_EndTransform = EndTransform;
    }

    public void SetMaterialColor(Material Mat, Color Col)
    {
        m_Material = Mat;
        m_Color = Col;
    }

    public void SetMode(ArcMode Mode)
    {
        m_Mode = Mode;
    }

    public void SetParameters(int Segments, float Width, Vector3 Amplitude, float Frequency)
    {
        m_Segments = Segments;
        m_Width = Width;
        m_Amplitude = Amplitude;
        m_Frequency = Frequency;
    }

    public void Begin()
    {
        m_Timer = 0.0f;

        try
        {
            this.gameObject.GetComponent<LineRenderer>();
        }
        catch
        {
            this.gameObject.AddComponent<LineRenderer>();
        }
        finally
        {
            m_LR = this.GetComponent<LineRenderer>();
        }

        m_LR.SetVertexCount(m_Segments);
        m_LR.material = m_Material;
        m_LR.SetColors(m_Color, m_Color);
        m_LR.SetWidth(m_Width, m_Width);
    }
	//////////////////////////////////////////////////////////////////////////
	#endregion
}
//////////////////////////////////////////////////////////////////////////