
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LF.Dynasty
{
    public class S_Dynasty_Creation : IEcsInitSystem, IEcsRunSystem
    {
        public void Init(IEcsSystems systems)
        {
            //Создаём династии
            Dynasties_Creation();
        }

        public void Run(IEcsSystems systems)
        {
            //Создаём династии
            Dynasties_Creation();
        }

        readonly EcsFilterInject<Inc<SR_Dynasty_Creation>> dynasty_Creation_SR_F = default;
        void Dynasties_Creation()
        {
            //Для каждого запроса создания династии
            foreach(int dEntity in dynasty_Creation_SR_F.Value)
            {
                //Берём запрос
                ref SR_Dynasty_Creation rComp = ref dynasty_Creation_SR_F.Pools.Inc1.Get(dEntity);

                //Создаём династию
                Dynasty_Creation(
                    dEntity,
                    ref rComp);

                //Удаляем запрос
                dynasty_Creation_SR_F.Pools.Inc1.Del(dEntity);
            }
        }

        readonly EcsPoolInject<C_Dynasty> d_P = default;
        void Dynasty_Creation(
            int dEntity,
            ref SR_Dynasty_Creation rComp)
        {
            //Назначаем сущности компонент династии и заполняем его данные
            ref C_Dynasty d = ref d_P.Value.Add(dEntity);

            d = new(rComp.dynastyName);

            UnityEngine.Debug.LogWarning("Dynasty Created!");

            //Создаём событие, сообщающее о создании династии
            Dynasty_Created_SE(dEntity);
        }

        readonly EcsPoolInject<SE_Dynasty_Created> d_Created_SE_P = default;
        void Dynasty_Created_SE(
            int dEntity)
        {
            //Назначаем сущности компонент события и заполняем его данные
            ref SE_Dynasty_Created eComp = ref d_Created_SE_P.Value.Add(dEntity);
            eComp = new(0);
        }
    }
}
