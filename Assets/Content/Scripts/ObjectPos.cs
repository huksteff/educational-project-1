using UnityEngine;

public class ObjectPos : MonoBehaviour
{

    void LateUpdate()
    {
        Shader.SetGlobalVector("_ObjectPos", gameObject.transform.position);
    }
}
