using UnityEngine;

using Leopotam.EcsLite;

namespace LF.Agent
{
    public class AgentData : MonoBehaviour
    {
        public static void AgentCreationSelfRequest(
            EcsPool<SR_Agent_Creation> requestPool,
            int agentEntity,
            string agentName)
        {
            //Назначаем сущности запрос создания агента и заполняем его данные
            ref SR_Agent_Creation requestComp = ref requestPool.Add(agentEntity);
            requestComp = new(
                agentName);
        }
    }
}
