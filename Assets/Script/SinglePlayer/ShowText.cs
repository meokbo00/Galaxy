using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

class Chat
{
    public int id;
    public string text;
    public float delaytime;
}

public class ShowText : MonoBehaviour
{
    public TMP_Text chatting;
    public GameObject ChatBox;
    public string Text;
    private List<Chat> chats;
    private int currentChatIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        ChatBox.gameObject.SetActive(true);
        var asset = Resources.Load<TextAsset>(Text);
        var json = asset.text;
        chats = JsonConvert.DeserializeObject<List<Chat>>(json);
        DisplayCurrentChat();
    }

    void Update()
    {
        if (!isTyping && Input.GetMouseButtonDown(0))
        {
            currentChatIndex++;
            DisplayCurrentChat();
        }
    }

    private void DisplayCurrentChat()
    {
        if (currentChatIndex < chats.Count)
        {
            StartCoroutine(Typing(chats[currentChatIndex].text, chats[currentChatIndex].delaytime)); 
        }
        else
        {
            ChatBox.gameObject.SetActive(false);
        }
    }

    IEnumerator Typing(string talk, float delaytime) 
    {
        isTyping = true;
        chatting.text = null;

        for (int i = 0; i < talk.Length; i++)
        {
            chatting.text += talk[i];
            yield return new WaitForSeconds(delaytime);
        }

        isTyping = false;
    }
}