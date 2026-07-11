using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LF.Initialization
{
    public class S_Test_Initialization : IEcsInitSystem
    {
        readonly EcsWorldInject world = default;


        //readonly EcsPoolInject<SR_Map_Initialization> map_Initialization_SR_P = default;

        readonly EcsPoolInject<SR_Object_Initialization> object_Initialization_SR_P = default;
        readonly EcsPoolInject<SR_Subject_Initialization> subject_Initialization_SR_P = default;

        //readonly EcsCustomInject<InitializationData> initialization_Data = default;

        public void Init(IEcsSystems systems)
        {
            //Создаём новую сущность и назначаем ей запрос инициализации карты
            /*int mapRequestEntity = world.Value.NewEntity();
            ref SR_Map_Initialization requestComp = ref map_Initialization_SR_P.Value.Add(mapRequestEntity);

            //Заполняем данные запроса
            requestComp = new(
                initialization_Data.Value.mapName,
                initialization_Data.Value.hexasphereSubdivisions);*/

            //Subject_Initialization_SR();
            //Subject_Initialization_SR();
            //Subject_Initialization_SR();

            Planet_Creation("TestPlanet0");
            Planet_Creation("TestPlanet1");
            Planet_Creation("TestPlanet2");
            Planet_Creation("TestPlanet3");
            Planet_Creation("TestPlanet4");

            Dynasty_Creation("TestDynasty0");
            Dynasty_Creation("TestDynasty1");
            Dynasty_Creation("TestDynasty2");
        }

        void Subject_Initialization_SR()
        {
            //Создаём новую сущность и назначаем ей запросы инициализации объекта и субъекта
            int subjRequestEntity = world.Value.NewEntity();
            ref SR_Object_Initialization objRComp = ref object_Initialization_SR_P.Value.Add(subjRequestEntity);
            ref SR_Subject_Initialization subjRComp = ref subject_Initialization_SR_P.Value.Add(subjRequestEntity);

            //Заполняем данные запросов
            objRComp = new(0);
            subjRComp = new(0);
        }

        readonly EcsPoolInject<Planet.SR_Planet_Creation> p_Creation_SR_P = default;
        void Planet_Creation(
            string planetName)
        {
            //Создаём новую сущность и назначаем ей запрос создания планеты
            int planetEntity = world.Value.NewEntity();
            Planet.Planet_Data.Planet_Creation_SR(
                planetEntity,
                p_Creation_SR_P.Value,
                planetName);
        }

        readonly EcsPoolInject<Dynasty.SR_Dynasty_Creation> d_Creation_SR_P = default;
        void Dynasty_Creation(
            string dynastyName)
        {
            //Создаём новую сущность и назначаем ей запрос создания династии
            int dEntity = world.Value.NewEntity();
            Dynasty.Dynasty_Data.Dynasty_Creation_SR(
                dEntity,
                d_Creation_SR_P.Value,
                dynastyName);
        }
    }
}
