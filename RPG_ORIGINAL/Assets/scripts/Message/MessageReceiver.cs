using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageReceiver : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<IMessage>() != null)
        {
            IMessage messenger = collider.gameObject.GetComponent<IMessage>();
            messenger.PopMessage();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<IMessage>() != null)
        {
            IMessage messenger = collider.gameObject.GetComponent<IMessage>();
            messenger.OutMessage();
        }
    }
}
