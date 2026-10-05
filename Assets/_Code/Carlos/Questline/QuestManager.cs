using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public bool IsQuestActive;
    public bool IsQuestCompleted;

    public virtual void QuestActivated()
    {
        IsQuestActive = true;
    }
    public virtual void QuestState()
    {

    }
    public virtual void QuestCompleted()
    {
        IsQuestCompleted = true;
    }
}
