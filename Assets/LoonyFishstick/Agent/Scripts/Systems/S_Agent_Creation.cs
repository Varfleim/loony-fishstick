
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LF.Agent
{
    public class S_Agent_Creation : IEcsInitSystem, IEcsRunSystem
    {
        public void Init(IEcsSystems systems)
        {
            //Создаём агентов
            AgentsCreation();
        }

        public void Run(IEcsSystems systems)
        {
            //Создаём агентов
            AgentsCreation();
        }

        readonly EcsFilterInject<Inc<SR_Agent_Creation>> agentCreationSRFilter = default;
        readonly EcsPoolInject<SR_Agent_Creation> agentCreationSRPool = default;
        void AgentsCreation()
        {
            //Для каждого запроса создания агента
            foreach(int agentRequestEntity in agentCreationSRFilter.Value)
            {
                //Берём запрос
                ref SR_Agent_Creation requestComp = ref agentCreationSRPool.Value.Get(agentRequestEntity);

                //Создаём агента
                AgentCreation(
                    ref requestComp,
                    agentRequestEntity);

                //Удаляем запрос
                agentCreationSRPool.Value.Del(agentRequestEntity);
            }
        }

        readonly EcsPoolInject<C_Agent> agentPool = default;
        void AgentCreation(
            ref SR_Agent_Creation requestComp,
            int agentEntity)
        {
            //Назначаем сущности компонент агента и заполняем его данные
            ref C_Agent agent = ref agentPool.Value.Add(agentEntity);
            agent = new(
                requestComp.agentName);

            //Создаём самособытие, сообщающее о создании агента
            AgentCreatedSelfEvent(agentEntity);
        }

        readonly EcsPoolInject<SE_Agent_Created> agentCreatedSEPool = default;
        void AgentCreatedSelfEvent(
            int agentEntity)
        {
            //Назначаем сущности компонент события и заполняем его данные
            ref SE_Agent_Created eventComp = ref agentCreatedSEPool.Value.Add(agentEntity);
            eventComp = new(0);
        }
    }
}
