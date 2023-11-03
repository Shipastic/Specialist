using System.Reflection;

namespace ReflectionClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly lib = Assembly.LoadFrom("ClassesForLib.dll");

            #region Student Class Reflection
            Type typeStudent = lib.GetType("ClassesForLib.Student");

            Console.WriteLine("Constructors Student class:");
            ConstructorInfo[] ctorInfStudent = typeStudent.GetConstructors();

            foreach (var ctor in ctorInfStudent)
            {
                ParameterInfo[] parCtor =  ctor.GetParameters();
                if(parCtor.Count() == 0)
                {
                    Console.WriteLine($"Class {typeStudent} contains constructor {parCtor} without rameters");
                }
                foreach (var param in parCtor)
                {
                    Console.WriteLine($"Parameter name: {param.Name} - parameter default value: {param.DefaultValue}");
                }
            }

            Console.WriteLine();

            Console.WriteLine("Properies Student class:");
            PropertyInfo[] propertiesStudent = typeStudent.GetProperties();
            foreach (var property in propertiesStudent)
            {
                Console.WriteLine($"{property.Name} - {property.PropertyType}");
            }
            Console.WriteLine("==========================================");
            #endregion

            #region Teacher Class Reflection
            Type typeTeacher = lib.GetType("ClassesForLib.Teacher");

            Console.WriteLine("Constructors Teacher class:");
            ConstructorInfo[] ctorInfTeacher= typeTeacher.GetConstructors();

            foreach (var ctor in ctorInfTeacher)
            {
                ParameterInfo[] parCtor = ctor.GetParameters();
                if (parCtor.Count() == 0)
                {
                    Console.WriteLine($"Class {typeTeacher} contains constructor {parCtor} without rameters");
                }
                foreach (var param in parCtor)
                {
                    Console.WriteLine($"Parameter name: {param.Name} - parameter default value: {param.DefaultValue}");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Properies Teacher class:");
            PropertyInfo[] propertiesTeacher = typeTeacher.GetProperties();
            foreach (var property in propertiesTeacher)
            {
                Console.WriteLine($"{property.Name} - { property.PropertyType}");
            }
            Console.WriteLine("==========================================");
            #endregion

            #region Course Class Reflection
            Type typeCourse = lib.GetType("ClassesForLib.Course");

            Console.WriteLine("Constructors Course class:");
            ConstructorInfo[] ctorInfCourse= typeCourse.GetConstructors();

            foreach (var ctor in ctorInfCourse)
            {
                ParameterInfo[] parCtor = ctor.GetParameters();
                if (parCtor.Count() == 0)
                {
                    Console.WriteLine($"Class {typeCourse} contains constructor {parCtor} without rameters");
                }
                foreach (var param in parCtor)
                {
                    Console.WriteLine($"Parameter name: {param.Name} - parameter default value: {param.DefaultValue}");
                }
            }

            Console.WriteLine();

            Console.WriteLine("Properies Course class:");
            PropertyInfo[] propertiesCourse = typeCourse.GetProperties();
            foreach (var property in propertiesCourse)
            {
                Console.WriteLine($"{property.Name} - {property.PropertyType}");
            }
            #endregion
        }
    }
}