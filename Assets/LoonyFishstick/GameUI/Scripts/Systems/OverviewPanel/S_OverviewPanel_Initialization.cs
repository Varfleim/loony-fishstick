
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

using GS.UI;

namespace LF.GameUI
{
    public class S_OverviewPanel_Initialization : IEcsInitSystem
    {
        readonly EcsWorldInject world = default;


        readonly EcsPoolInject<R_OverviewSubpanel_Creation> oSbp_Creation_R_P = default;
        readonly EcsPoolInject<R_OverviewTab_Creation> oT_Creation_R_P = default;

        public void Init(IEcsSystems systems)
        {
            //ТЕСТ
            //Главная обзорная
            int rEntity = world.Value.NewEntity();
            ref R_OverviewSubpanel_Creation rComp = ref oSbp_Creation_R_P.Value.Add(rEntity);

            rComp = new(
                "MainOverviewPanel",
                "TestSubpanelMain0",
                true);

            rEntity = world.Value.NewEntity();
            ref R_OverviewTab_Creation rCompp = ref oT_Creation_R_P.Value.Add(rEntity);

            rCompp = new(
                "MainOverviewPanel",
                "TestSubpanelMain0",
                "TestTabMain00");

            rEntity = world.Value.NewEntity();
            rCompp = ref oT_Creation_R_P.Value.Add(rEntity);

            rCompp = new(
                "MainOverviewPanel",
                "TestSubpanelMain0",
                "TestTabMain01");

            rEntity = world.Value.NewEntity();
            rComp = ref oSbp_Creation_R_P.Value.Add(rEntity);

            rComp = new(
                "MainOverviewPanel",
                "TestSubpanelMain1",
                true);

            rEntity = world.Value.NewEntity();
            rCompp = ref oT_Creation_R_P.Value.Add(rEntity);

            rCompp = new(
                "MainOverviewPanel",
                "TestSubpanelMain1",
                "TestTabMain10");
            //Главная обзорная

            //Планировщик
            rEntity = world.Value.NewEntity();
            rComp = ref oSbp_Creation_R_P.Value.Add(rEntity);

            rComp = new(
                "OutlinerPanel",
                "TestSubpanelOut0",
                true);

            rEntity = world.Value.NewEntity();
            rCompp = ref oT_Creation_R_P.Value.Add(rEntity);

            rCompp = new(
                "OutlinerPanel",
                "TestSubpanelOut0",
                "TestTabOut00");

            rEntity = world.Value.NewEntity();
            rCompp = ref oT_Creation_R_P.Value.Add(rEntity);

            rCompp = new(
                "OutlinerPanel",
                "TestSubpanelOut0",
                "TestTabOut01");

            rEntity = world.Value.NewEntity();
            rComp = ref oSbp_Creation_R_P.Value.Add(rEntity);

            rComp = new(
                "OutlinerPanel",
                "TestSubpanelOut1",
                true);

            rEntity = world.Value.NewEntity();
            rCompp = ref oT_Creation_R_P.Value.Add(rEntity);

            rCompp = new(
                "OutlinerPanel",
                "TestSubpanelOut1",
                "TestTabOut10");
            //Планировщик

            //Линзы
            rEntity = world.Value.NewEntity();
            rComp = ref oSbp_Creation_R_P.Value.Add(rEntity);

            rComp = new(
                "LensPanel",
                "TestSubpanelLens0",
                true);

            rEntity = world.Value.NewEntity();
            rCompp = ref oT_Creation_R_P.Value.Add(rEntity);

            rCompp = new(
                "LensPanel",
                "TestSubpanelLens0",
                "TestTabLens00");

            rEntity = world.Value.NewEntity();
            rCompp = ref oT_Creation_R_P.Value.Add(rEntity);

            rCompp = new(
                "LensPanel",
                "TestSubpanelLens0",
                "TestTabLens01");

            rEntity = world.Value.NewEntity();
            rComp = ref oSbp_Creation_R_P.Value.Add(rEntity);

            rComp = new(
                "LensPanel",
                "TestSubpanelLens1",
                true);

            rEntity = world.Value.NewEntity();
            rCompp = ref oT_Creation_R_P.Value.Add(rEntity);

            rCompp = new(
                "LensPanel",
                "TestSubpanelLens1",
                "TestTabLens10");
            //Линзы
            //ТЕСТ
        }
    }
}
