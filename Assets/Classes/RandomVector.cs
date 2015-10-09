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
public static class RandomVector
{
	#region Methods
	//////////////////////////////////////////////////////////////////////////
	//METHODS
	//////////////////////////////////////////////////////////////////////////
    public static T Range<T>(float min, float max)
    {
        if (typeof(T).Equals(typeof(Vector3)))
        {
            Vector3 _Result = new Vector3(
            Random.Range(min, max),
            Random.Range(min, max),
            Random.Range(min, max));

            return (T)(object)_Result;
        }
        else if (typeof(T).Equals(typeof(Vector2)))
        {
            Vector2 _Result = new Vector2(
            Random.Range(min, max),
            Random.Range(min, max));

            return (T)(object)_Result;
        }
        else
        {
            return default(T);
        }
    }

    public static T Range<T>(Vector3 min, Vector3 max)
    {
        if (typeof(T).Equals(typeof(Vector3)))
        {
            Vector3 _Result = new Vector3(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y),
            Random.Range(min.z, max.z));

            return (T)(object)_Result;
        }
        else if (typeof(T).Equals(typeof(Vector2)))
        {
            Vector2 _Result = new Vector2(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y));

            return (T)(object)_Result;
        }
        else
        {
            return default(T);
        }
    }

    /*
     * public Vector2 Range2(float min, float max)
    {
        return new Vector2(
        Random.Range(min, max),
        Random.Range(min, max));
    }
    
    public Vector3 Range3(float min, float max)
    {
        return new Vector3(
        Random.Range(min, max),
        Random.Range(min, max),
        Random.Range(min, max));
    }
    */
	//////////////////////////////////////////////////////////////////////////
	#endregion
}
//////////////////////////////////////////////////////////////////////////