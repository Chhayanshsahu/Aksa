
using UnityEngine;
using UnityEditor;

public class FixNegativeScale : MonoBehaviour
{
    [MenuItem("Tools/Fix Negative Scale")]
    static void FixAllNegativeScales()
    {
        foreach (GameObject obj in GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None))
        {
            Vector3 scale = obj.transform.localScale;
            bool hasNegative = scale.x < 0 || scale.y < 0 || scale.z < 0;

            if (hasNegative)
            {
                Undo.RecordObject(obj.transform, "Fix Negative Scale");
                obj.transform.localScale = new Vector3(
                    Mathf.Abs(scale.x),
                    Mathf.Abs(scale.y),
                    Mathf.Abs(scale.z)
                );
            }
        }

        Debug.Log("Fixed all negative scales!");
    }
}
