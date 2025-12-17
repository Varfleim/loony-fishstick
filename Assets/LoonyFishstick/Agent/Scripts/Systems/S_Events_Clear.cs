
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LF.Agent
{
    public class S_Events_Clear : IEcsInitSystem, IEcsRunSystem
    {
        public void Init(IEcsSystems systems)
        {
            //Очищаем события создания агентов
            AgentCreatedSelfEventsClear();
        }
        
        public void Run(IEcsSystems systems)
        {
            //Очищаем события создания агентов
            AgentCreatedSelfEventsClear();
        }

        readonly EcsFilterInject<Inc<SE_Agent_Created>> agentCreatedSEFilter = default;
        readonly EcsPoolInject<SE_Agent_Created> agentCreatedSEPool = default;
        void AgentCreatedSelfEventsClear()
        {
            //Для каждого события создания агента
            foreach(int eventEntity in agentCreatedSEFilter.Value)
            {
                //Удаляем компонент события
                agentCreatedSEPool.Value.Del(eventEntity);
            }
        }
    }
}
