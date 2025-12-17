using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

using GBB.Map;
using HS.Hexasphere;

namespace LF.Initialization
{
    public class S_Map_Initialization : IEcsInitSystem
    {
        readonly EcsWorldInject world = default;

        public void Init(IEcsSystems systems)
        {
            //Инициализируем карты
            MapsInitialization();
        }

        readonly EcsFilterInject<Inc<SR_Map_Initialization>> mapInitializationSRFilter = default;
        readonly EcsPoolInject<SR_Map_Initialization> mapInitializationSRPool = default;
        void MapsInitialization()
        {
            //Для каждого запроса инициализации карты
            foreach (int mapRequestEntity in mapInitializationSRFilter.Value)
            {
                //Берём запрос
                ref SR_Map_Initialization requestComp = ref mapInitializationSRPool.Value.Get(mapRequestEntity);

                //Инициализируем карту
                MapInitialization(
                    ref requestComp,
                    mapRequestEntity);

                //Удаляем запрос
                mapInitializationSRPool.Value.Del(mapRequestEntity);
            }
        }

        readonly EcsPoolInject<GBB.Map.Render.R_MapActivation> mapActivationRPool = default;
        void MapInitialization(
            ref SR_Map_Initialization requestComp,
            int mapEntity)
        {
            //Запрашиваем создание карты
            MapCreationRequest(
                ref requestComp,
                mapEntity);

            //Запрашиваем создание гексасферы
            HexasphereCreationRequest(
                ref requestComp,
                mapEntity);

            //ТЕСТ
            //Запрашиваем активацию карты
            GBB.Map.Render.MapRenderData.MapActivationRequest(
                world.Value,
                mapActivationRPool.Value,
                world.Value.PackEntity(mapEntity));
            //ТЕСТ
        }

        readonly EcsPoolInject<SR_MapCreation> mapCreationSRPool = default;
        void MapCreationRequest(
            ref SR_Map_Initialization requestComp,
            int mapEntity)
        {
            //Назначаем сущности запрос создания карты
            ref SR_MapCreation mapCreationRequest = ref mapCreationSRPool.Value.Add(mapEntity);

            //Заполняем данные запроса
            mapCreationRequest = new(
                requestComp.mapName);
        }

        readonly EcsPoolInject<SR_HexasphereCreation> hexasphereCreationSRPool = default; 
        void HexasphereCreationRequest(
            ref SR_Map_Initialization requestComp,
            int mapEntity)
        {
            //Назначаем сущности запрос создания гексасферы
            ref SR_HexasphereCreation hexasphereCreationRequest = ref hexasphereCreationSRPool.Value.Add(mapEntity);

            //Заполняем данные запроса
            hexasphereCreationRequest = new(
                requestComp.hexasphereSubdivisions);
        }
    }
}
