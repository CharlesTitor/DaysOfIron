using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [SerializeField] private List<QuestProgress> _activeQuests = new List<QuestProgress>();


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }
    }


    public void StartQuest(Quest quest)
    {
        QuestProgress newQuest = new QuestProgress(quest);
        _activeQuests.Add(newQuest);
    }


    public bool IsQuestActive(Quest quest)
    {
        foreach (QuestProgress questProgress in _activeQuests)
        {
            if(questProgress.quest == quest)
            {
                return true;
            }
        }
        return false;
    }
    public void UpdateQuestObjective(ItemData item, int itemCuantity)
    {
        foreach (QuestProgress questProgress in _activeQuests)
        {
            foreach (QuestObjective objective in questProgress.objectives)
            {
                if (objective.type == ObjectiveType.CollectItem && objective.ItemRequired == item)
                {
                    objective.currentAmount += itemCuantity;
                    Debug.Log($"You have {objective.currentAmount} of {objective.requiredAmount}");
                    if (questProgress.isCompleted) { Debug.Log("Quest completed"); }
                }
            }
        }
    }
}
