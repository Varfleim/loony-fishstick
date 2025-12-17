using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LF.Initialization
{
    public class S_Test_Initialization : IEcsInitSystem
    {
        readonly EcsWorldInject world = default;


        readonly EcsPoolInject<SR_Map_Initialization> mapInitializationSRPool = default;

        readonly EcsPoolInject<SR_Agent_Initialization> agentInitializationSRPool = default;


        readonly EcsCustomInject<InitializationData> initializationData = default;

        public void Init(IEcsSystems systems)
        {
            //Создаём новую сущность и назначаем ей запрос инициализации карты
            int mapRequestEntity = world.Value.NewEntity();
            ref SR_Map_Initialization requestComp = ref mapInitializationSRPool.Value.Add(mapRequestEntity);

            //Заполняем данные запроса
            requestComp = new(
                initializationData.Value.mapName,
                initializationData.Value.hexasphereSubdivisions);

            AgentInitializationSelfRequest("TestAgent1");
            AgentInitializationSelfRequest("TestAgent2");
            AgentInitializationSelfRequest("TestAgent3");
        }

        void AgentInitializationSelfRequest(
            string agentName)
        {
            //Создаём новую сущность и назначаем ей запрос инициализации агента
            int agentRequestEntity = world.Value.NewEntity();
            ref SR_Agent_Initialization requestComp = ref agentInitializationSRPool.Value.Add(agentRequestEntity);

            //Заполняем данные запроса
            requestComp = new(
                agentName);
        }
    }
}
