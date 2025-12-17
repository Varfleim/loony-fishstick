
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LF.Initialization
{
    public class S_Agent_Initialization : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            //Инициализируем агентов
            AgentsInitialization();
        }

        readonly EcsFilterInject<Inc<SR_Agent_Initialization>> agentInitializationSRFilter = default;
        readonly EcsPoolInject<SR_Agent_Initialization> agentInitializationSRPool = default;
        void AgentsInitialization()
        {
            //Для каждого запроса инициализации агента
            foreach(int agentRequestEntity in agentInitializationSRFilter.Value)
            {
                //Берём запрос
                ref SR_Agent_Initialization requestComp = ref agentInitializationSRPool.Value.Get(agentRequestEntity);

                //Инициализируем агента
                AgentInitialization(
                    ref requestComp,
                    agentRequestEntity);

                //Удаляем запрос
                agentInitializationSRPool.Value.Del(agentRequestEntity);
            }
        }

        readonly EcsPoolInject<Agent.SR_Agent_Creation> agentCreationSRPool = default;
        void AgentInitialization(
            ref SR_Agent_Initialization requestComp,
            int agentEntity)
        {
            //Запрашиваем создание агента
            Agent.AgentData.AgentCreationSelfRequest(
                agentCreationSRPool.Value,
                agentEntity,
                requestComp.agentName);
        }
    }
}
