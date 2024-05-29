using UnityEngine;
using UnityEngine.SceneManagement;

public class SPP1Deadzone : MonoBehaviour
{
    public bool isExpand;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "P1ball")
        {
            BallController ball = collision.GetComponent<BallController>();
            if (!ball.hasExpanded)
                SceneManager.LoadScene("Fail");
        }


        if (collision.gameObject.tag == "Item")
        {
            switch (collision.gameObject.name)
            {
                case "SPBlackHoleF(Clone)":
                    BlackHole_Skill skill = collision.GetComponent<BlackHole_Skill>();
                    this.isExpand = skill.hasExpanded;
                    break;
                case "SPDurabilityF(Clone)":
                    Durability_Skill skill2 = collision.GetComponent<Durability_Skill>();
                    this.isExpand = skill2.hasExpanded;
                    break;
                case "SPFastenF(Clone)":
                    Fasten_Skill skill3 = collision.GetComponent<Fasten_Skill>();
                    this.isExpand = skill3.hasExpanded;
                    break;
                case "SPForceF(Clone)":
                    Force_Skill skill4 = collision.GetComponent<Force_Skill>();
                    this.isExpand = skill4.hasExpanded;
                    break;
                case "SPInvincibleF(Clone)":
                    Invincible_Skill skill5 = collision.GetComponent<Invincible_Skill>();
                    this.isExpand = skill5.hasExpanded;
                    break;
                case "SPRandom_numberF(Clone)":
                    Random_number_Skill skill6 = collision.GetComponent<Random_number_Skill>();
                    this.isExpand = skill6.hasExpanded;
                    break;
                case "SPReductionF(Clone)":
                    Reduction_Skill skill7 = collision.GetComponent<Reduction_Skill>();
                    this.isExpand = skill7.hasExpanded;
                    break;
            }
            if (isExpand == false)
            {
                SceneManager.LoadScene("Fail");
            }
        }
    }
}