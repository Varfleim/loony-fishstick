
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

using GS.UI;
using LF.GameUI;
using LF.GameUI.Space;
using LF.GameUI.Dynasty;

namespace LF.Initialization
{
    public class S_GUI_Initialization : IEcsInitSystem
    {
        readonly EcsWorldInject world = default;

        readonly EcsPoolInject<SR_BlockList_Creation> bL_Creation_SR_P = default;

        public void Init(IEcsSystems systems)
        {
            //Инициализируем интерфейс космоса
            SpaceGUI_Initialization();

            //Инициализируем интерфейс династий
            DynastyGUI_Initialization();
        }

        void SpaceGUI_Initialization()
        {
            //Создаём блок исследования планетарной системы
            Block_PlanetSystemSurvey_Creation(
                1,
                0,
                1);
        }

        readonly EcsPoolInject<SR_Block_PlanetSystemSurvey_Creation> b_PlanetSystemSurvey_Creation_SR_P = default;
        void Block_PlanetSystemSurvey_Creation(
            int parentPanelType,
            int parentSubpanelType,
            int parentTabType)
        {
            //Создаём новую сущность
            int bEntity = world.Value.NewEntity();

            //Запрашиваем создание блока-списка
            UI_Data.BlockList_Creation_SR(
                bEntity,
                bL_Creation_SR_P.Value,
                parentPanelType,
                parentSubpanelType,
                parentTabType);

            //Запрашиваем создание блока исследования планетарной системы
            SpaceGUI_Data.Block_PlanetSystemSurvey_Creation_SR(
                bEntity,
                b_PlanetSystemSurvey_Creation_SR_P.Value);
        }

        void DynastyGUI_Initialization()
        {
            //Создаём обзорный блок династий
            Block_DynastyOverview_Creation(
                1,
                0,
                1);
        }

        readonly EcsPoolInject<SR_Block_DynastyOverview_Creation> b_DynastyOverview_Creation_SR_P = default;
        void Block_DynastyOverview_Creation(
            int parentPanelType,
            int parentSubpanelType,
            int parentTabType)
        {
            //Создаём новую сущность
            int bEntity = world.Value.NewEntity();

            //Запрашиваем создание блока-списка
            UI_Data.BlockList_Creation_SR(
                bEntity,
                bL_Creation_SR_P.Value,
                parentPanelType,
                parentSubpanelType,
                parentTabType);

            //Запрашиваем создание обзорного блока династий
            DynastyGUI_Data.Block_DynastyOverview_Creation_SR(
                bEntity,
                b_DynastyOverview_Creation_SR_P.Value);
        }
    }
}
