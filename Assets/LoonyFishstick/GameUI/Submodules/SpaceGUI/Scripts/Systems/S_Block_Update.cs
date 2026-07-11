
using System.Collections.Generic;

using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

using GBB;
using GBB.Map;

using GS.UI;

using LF.Planet;

namespace LF.GameUI.Space
{
    public class S_Block_Update : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            //Обновляем блоки исследования планетарных систем
            Blocks_PSSurvey_Update();
        }

        readonly EcsFilterInject<Inc<C_BlockList, C_Block_PlanetSystemSurvey, SR_Block_Update>> b_PSSurvey_Update_SR_F = default;
        void Blocks_PSSurvey_Update()
        {
            //Если количество запросов обновления блоков больше нуля
            if (b_PSSurvey_Update_SR_F.Value.GetEntitiesCount() > 0)
            {
                //Получаем список данных для отображения
                List<DT_BlockList_Element> tempElements = Block_PSSurvey_GetData();

                //Для каждого запроса обновления блока
                foreach (int bEntity in b_PSSurvey_Update_SR_F.Value)
                {
                    //Берём блок
                    ref C_BlockList bL = ref b_PSSurvey_Update_SR_F.Pools.Inc1.Get(bEntity);

                    //Передаём в него список
                    bL.List_Set(tempElements);
                }

                //Очищаем временный список
                ListPool<DT_BlockList_Element>.Add(tempElements);
            }
        }

        readonly EcsFilterInject<Inc<C_Map, C_Planet>> planet_Map_F = default;
        List<DT_BlockList_Element> Block_PSSurvey_GetData()
        {
            //Создаём новый список
            List<DT_BlockList_Element> tempElements = ListPool<DT_BlockList_Element>.Get();

            //ТЕСТ
            //Для каждой планеты
            foreach (int pEntity in planet_Map_F.Value)
            {
                //Создаём новый элемент списка
                DT_BlockList_Element element = new();

                //Берём карту и планету
                ref C_Map map = ref planet_Map_F.Pools.Inc1.Get(pEntity);
                ref C_Planet planet = ref planet_Map_F.Pools.Inc2.Get(pEntity);

                //Заполняем данные элемента
                element.elementName = planet.selfName;
                element.elementEntity = pEntity;

                element.elementValues.Add(new(map.provinceEntities.Length, map.provinceEntities.Length));

                //Заносим его в список
                tempElements.Add(element);
            }
            //ТЕСТ

            //Возвращаем список
            return tempElements;
        }
    }
}
