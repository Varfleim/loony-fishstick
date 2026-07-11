using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

using GBB.Map;
using HS.Hexasphere;

namespace LF.Initialization
{
    public class S_Map_Initialization : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            //Инициализируем карты
            Maps_Initialization();
        }

        readonly EcsFilterInject<Inc<SR_Map_Initialization>> map_Initialization_SR_F = default;
        readonly EcsPoolInject<SR_Map_Initialization> map_Initialization_SR_P = default;
        void Maps_Initialization()
        {
            //Для каждого запроса инициализации карты
            foreach (int mapRequestEntity in map_Initialization_SR_F.Value)
            {
                //Берём запрос
                ref SR_Map_Initialization requestComp = ref map_Initialization_SR_P.Value.Get(mapRequestEntity);

                //Инициализируем карту
                Map_Initialization(
                    ref requestComp,
                    mapRequestEntity);

                //Удаляем запрос
                map_Initialization_SR_P.Value.Del(mapRequestEntity);
            }
        }

        readonly EcsPoolInject<GBB.Map.Render.SR_Map_Activation> map_Activation_SR_P = default;
        readonly EcsPoolInject<SR_Map_Creation> map_Creation_SR_P = default;
        readonly EcsPoolInject<SR_Hexasphere_Creation> hS_Creation_SR_P = default; 
        void Map_Initialization(
            ref SR_Map_Initialization requestComp,
            int mapEntity)
        {
            //Запрашиваем создание карты
            Map_Data.Map_Creation_SR(
                mapEntity,
                map_Creation_SR_P.Value);

            //Запрашиваем создание гексасферы
            Hexasphere_Data.HS_Creation_SR(
                mapEntity,
                hS_Creation_SR_P.Value,
                requestComp.hexasphereSubdivisions);

            //ТЕСТ
            //Запрашиваем активацию карты
            GBB.Map.Render.MapRender_Data.Map_Activation_SR(
                mapEntity,
                map_Activation_SR_P.Value);
            //ТЕСТ
        }
    }
}
