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
    private Coroutine typingCoroutine;

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
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                // Stop the typing coroutine and display the full text immediately
                StopCoroutine(typingCoroutine);
                chatting.text = chats[currentChatIndex].text;
                isTyping = false;
            }
            else
            {
                currentChatIndex++;
                DisplayCurrentChat();
            }
        }
    }

    private void DisplayCurrentChat()
    {
        if (currentChatIndex < chats.Count)
        {
            typingCoroutine = StartCoroutine(Typing(chats[currentChatIndex].text, chats[currentChatIndex].delaytime));
        }
        else
        {
            ChatBox.gameObject.SetActive(false);
        }
    }

    IEnumerator Typing(string talk, float delaytime)
    {
        isTyping = true;
        chatting.text = string.Empty;

        for (int i = 0; i < talk.Length; i++)
        {
            chatting.text += talk[i];
            yield return new WaitForSeconds(delaytime);
        }

        isTyping = false;
    }
}