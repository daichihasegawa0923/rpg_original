using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<ICharacter>() != null)
        {
            col.GetComponent<ICharacter>().Damaged();
        }
        Debug.Log(col.gameObject.name);
    }
}
