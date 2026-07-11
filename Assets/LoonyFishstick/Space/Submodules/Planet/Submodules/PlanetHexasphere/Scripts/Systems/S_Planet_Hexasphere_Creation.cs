using UnityEngine;

using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

using GBB.Map;
using HS.Hexasphere;
using LF.Planet;

namespace LF.Planet.PlanetHexasphere
{
    public class S_Planet_Hexasphere_Creation : IEcsInitSystem, IEcsRunSystem
    {
        public void Init(IEcsSystems systems)
        {
            //Создаём гексасферы для планет
            Planets_Hexasphere_Creation();
        }

        public void Run(IEcsSystems systems)
        {
            //Создаём гексасферы для планет
            Planets_Hexasphere_Creation();
        }

        readonly EcsFilterInject<Inc<C_Planet, SE_Planet_Created>> planet_Created_SE_F = default;
        void Planets_Hexasphere_Creation()
        {
            //Для каждой созданной планеты
            foreach(int planetEntity in planet_Created_SE_F.Value)
            {
                //Берём планету
                ref C_Planet planet = ref planet_Created_SE_F.Pools.Inc1.Get(planetEntity);

                //Создаём гексасферу для неё
                Planet_Hexasphere_Creation(
                    planetEntity,
                    ref planet);
            }
        }

        readonly EcsPoolInject<SR_Map_Creation> map_Creation_SR_P = default;
        readonly EcsPoolInject<SR_Hexasphere_Creation> hexasphere_Creation_SR_P = default;
        void Planet_Hexasphere_Creation(
            int planetEntity,
            ref C_Planet planet)
        {
            //Этот запрос создаёт саму карту, но без провинций и без представления
            //Запрашиваем создание карты для планеты
            Map_Data.Map_Creation_SR(
                planetEntity,
                map_Creation_SR_P.Value);

            //Этот запрос создаёт гексасферу с провинциями
            //Запрашиваем создание гексасферы
            Hexasphere_Data.HS_Creation_SR(
                planetEntity,
                hexasphere_Creation_SR_P.Value,
                25 * Random.Range(1, 5));
        }
    }
}
