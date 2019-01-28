using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour,IMessage
{
    private const string MESSAGE_BOX_PATH = "Canvas/Message/Panel";
    private const string SYSTEM_MESSAGE = "Canvas/Message/Panel/SystemMessage";

    [SerializeField] private string _message = "　";

    public void OutMessage()
    {
        GameObject messageBox = GameObject.Find(MESSAGE_BOX_PATH).gameObject;
        messageBox.SetActive(false);
        GameObject.Find(SYSTEM_MESSAGE).gameObject.SetActive(false);
        GameObject.Find(SYSTEM_MESSAGE).gameObject.GetComponent<Text>().text = _message;
    }

    public void PopMessage()
    {
        GameObject messageBox = GameObject.Find(MESSAGE_BOX_PATH).gameObject;
        messageBox.SetActive(true);
        GameObject.Find(SYSTEM_MESSAGE).gameObject.SetActive(true);
        GameObject.Find(SYSTEM_MESSAGE).gameObject.GetComponent<Text>().text = _message;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
