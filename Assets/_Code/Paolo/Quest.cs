using System.Collections.Generic;
using UnityEngine;

public enum ObjectiveType
{
    CollectItem,
    DefeatEnemy,
    ReachLocation,
    TalkToNPC,
    Custom
}

[System.Serializable]
public class QuestObjective
{
    public string objectiveID;
    public string description;
    public ObjectiveType type;
    public int requiredAmount;
    public int currentAmount;

    public bool isCompleted => currentAmount >= requiredAmount;
}

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quests/Quest")]
public class Quest : ScriptableObject
{
    public string questID;
    public string questName;
    [TextArea]
    public string description;
    public List<QuestObjective> objectives = new List<QuestObjective>();

    private void OnValidate()
    {
        if (string.IsNullOrEmpty(questID))
        {
            questID = questName + "_" + System.Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}

[System.Serializable]
public class QuestProgress
{
    public Quest quest;
    public List<QuestObjective> objectives;

    public QuestProgress(Quest quest)
    {
        this.quest = quest;
        objectives = new List<QuestObjective>();

        foreach (var obj in quest.objectives)
        {
            objectives.Add(new QuestObjective
            {
                objectiveID = obj.objectiveID,
                description = obj.description,
                type = obj.type,
                requiredAmount = obj.requiredAmount,
                currentAmount = 0
            });
        }
    }

    public bool isCompleted => objectives.TrueForAll(o => o.isCompleted);
    public string questID => quest.questID;
}