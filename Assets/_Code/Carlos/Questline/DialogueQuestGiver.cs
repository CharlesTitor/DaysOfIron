using DialogueEditor;
using UnityEngine;

public class DialogueQuestGiver : MonoBehaviour
{
    [SerializeField] private int _necessaryNodeID;
    [SerializeField] private QuestManager _questSelected;

    public NPCConversation npcConversation;

    public void CorrectID()
    {

        //if (correctID == _necessaryNodeID)
        //{
        //    _questSelected.QuestActivated();
        //}
    }
}
