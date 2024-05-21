using UnityEngine;
using UnityEngine.UI;

public class SPItemUse : MonoBehaviour
{
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            string destroyedIconTag = gameObject.tag;
            SPGameManager icontag = FindObjectOfType<SPGameManager>(); // 임시로 적용한 코드입니다.
            icontag.PrintDestroyedicontag(destroyedIconTag);
            Debug.Log("아이템 " + destroyedIconTag + " 을 클릭했습니다");
            Destroy(gameObject);
        });
    }
}