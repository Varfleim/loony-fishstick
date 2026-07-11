
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

using GS.SubjectAndObject;

namespace LF.Initialization
{
    public class S_SubjectAndObject_Initialization : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            //Инициализируем объекты
            Objects_Initialization();

            //Инициализруем субъекты
            Subjects_Initialization();
        }

        readonly EcsFilterInject<Inc<SR_Object_Initialization>> object_Initialization_SR_F = default;
        readonly EcsPoolInject<SR_Object_Initialization> object_Initialization_SR_P = default;
        void Objects_Initialization()
        {
            //Для каждого запроса инициализации объекта
            foreach(int objEntity in object_Initialization_SR_F.Value)
            {
                //Берём запрос
                ref SR_Object_Initialization rComp = ref object_Initialization_SR_P.Value.Get(objEntity);

                //Инициализируем объект
                Object_Initialization(
                    ref rComp,
                    objEntity);

                //Удаляем запрос
                object_Initialization_SR_P.Value.Del(objEntity);
            }
        }

        readonly EcsPoolInject<SR_Object_Creation> object_Creation_SR_P = default;
        void Object_Initialization(
            ref SR_Object_Initialization rComp,
            int objEntity)
        {
            //Запрашиваем создание объекта
            SubjectAndObject_Data.Object_Creation_SR(
                object_Creation_SR_P.Value,
                objEntity);
        }

        readonly EcsFilterInject<Inc<SR_Subject_Initialization>> subject_Initialization_SR_F = default;
        readonly EcsPoolInject<SR_Subject_Initialization> subject_Initialization_SR_P = default;
        void Subjects_Initialization()
        {
            //Для каждого запроса инициализации субъекта
            foreach (int subjEntity in subject_Initialization_SR_F.Value)
            {
                //Берём запрос
                ref SR_Subject_Initialization rComp = ref subject_Initialization_SR_P.Value.Get(subjEntity);

                //Инициализируем субъект
                Subject_Initialization(
                    ref rComp,
                    subjEntity);

                //Удаляем запрос
                subject_Initialization_SR_P.Value.Del(subjEntity);
            }
        }

        readonly EcsPoolInject<SR_Subject_Creation> subject_Creation_SR_P = default;
        void Subject_Initialization(
            ref SR_Subject_Initialization rComp,
            int subjEntity)
        {
            //Запрашиваем создание субъекта
            SubjectAndObject_Data.Subject_Creation_SR(
                subject_Creation_SR_P.Value,
                subjEntity);
        }
    }
}
