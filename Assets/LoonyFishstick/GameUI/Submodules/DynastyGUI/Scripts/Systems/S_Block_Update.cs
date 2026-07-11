
using System.Collections.Generic;

using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

using GBB;

using GS.UI;

using LF.Dynasty;

namespace LF.GameUI.Dynasty
{
    public class S_Block_Update : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            //Обновляем обзорные блоки династий
            Blocks_DOverview_Update();
        }

        readonly EcsFilterInject<Inc<C_BlockList, C_Block_DynastyOverview, SR_Block_Update>> b_DOverview_Update_SR_F = default;
        void Blocks_DOverview_Update()
        {
            //Если количество запросов обновления блоков больше нуля
            if (b_DOverview_Update_SR_F.Value.GetEntitiesCount() > 0)
            {
                //Получаем список данных для отображения
                List<DT_BlockList_Element> tempElements = Block_DOverview_GetData();

                //Для каждого запроса обновления блока
                foreach (int bEntity in b_DOverview_Update_SR_F.Value)
                {
                    //Берём блок
                    ref C_BlockList bL = ref b_DOverview_Update_SR_F.Pools.Inc1.Get(bEntity);

                    //Передаём в него список
                    bL.List_Set(tempElements);
                }

                //Очищаем временный список
                ListPool<DT_BlockList_Element>.Add(tempElements);
            }
        }

        readonly EcsFilterInject<Inc<C_Dynasty>> dynasty_F = default;
        List<DT_BlockList_Element> Block_DOverview_GetData()
        {
            //Создаём новый список
            List<DT_BlockList_Element> tempElements = ListPool<DT_BlockList_Element>.Get();

            //ТЕСТ
            //Для каждой династии
            foreach(int dEntity in dynasty_F.Value)
            {
                //Создаём новый элемент списка
                DT_BlockList_Element element = new();

                //Берём династию
                ref C_Dynasty d = ref dynasty_F.Pools.Inc1.Get(dEntity);

                //Заполняем данные элемента
                element.elementName = d.selfName;
                element.elementEntity = dEntity;

                element.elementValues.Add(new(dEntity, dEntity));

                //Заносим его в список
                tempElements.Add(element);
            }
            //ТЕСТ

            //Возвращаем список
            return tempElements;
        }
    }
}
