using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour,IMessage,ICharacter
{
    private const string MESSAGE_BOX_PATH = "Canvas/Message/Panel";
    private const string NAME_TEXT_PATH = "Canvas/Message/Panel/name";
    private const string MESSAGE_TEXT_PATH = "Canvas/Message/Panel/message_text";
    [SerializeField]private string _message = "　";

    public void PopMessage()
    {
        GameObject messageBox = GameObject.Find(MESSAGE_BOX_PATH).gameObject;
        messageBox.SetActive(true);
        GameObject.Find(MESSAGE_TEXT_PATH).gameObject.SetActive(true);
        GameObject.Find(NAME_TEXT_PATH).gameObject.SetActive(true);
        Text messageText = GameObject.Find(MESSAGE_TEXT_PATH).gameObject.GetComponent<Text>();
        GameObject.Find(NAME_TEXT_PATH).gameObject.GetComponent<Text>().text = this.name;
        messageText.text = _message;
    }
    public void OutMessage()
    {
        GameObject messageBox = GameObject.Find(MESSAGE_BOX_PATH).gameObject;
        messageBox.SetActive(false);
        GameObject.Find(MESSAGE_TEXT_PATH).gameObject.SetActive(false);
        GameObject.Find(NAME_TEXT_PATH).gameObject.SetActive(false);
    }

    public void Damaged()
    {
        if (GetComponent<Rigidbody>() != null)
        {
            Rigidbody rig = GetComponent<Rigidbody>();
            rig.velocity = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
        }
    }
}
