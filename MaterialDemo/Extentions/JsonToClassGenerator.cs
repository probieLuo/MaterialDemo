using Newtonsoft.Json.Linq;

namespace MaterialDemo.Extentions
{
    public class JsonToClassGenerator
    {
        public static List<string> GenerateClass(string jsonString, string className,out string message)
        {
            try
            {
                var jsonObject = JObject.Parse(jsonString);
                classDefinitions.Clear();
                GenerateClassFromJObject(jsonObject, className);
                message=string.Empty;
                return classDefinitions;
            }
            catch (Newtonsoft.Json.JsonReaderException e)
            {
                message=e.Message;
                return null;
            }
        }
        private static List<string> classDefinitions=new List<string>();
        private static void GenerateClassFromJObject(JObject jsonObject, string className)
        {
            var properties = new List<string>();

            foreach (var property in jsonObject.Properties())
            {
                string typeName = GetCSharpType(property.Value.Type);
                if (property.Value.Type == JTokenType.Object)
                {
                    GenerateClassFromJObject((JObject)property.Value, property.Name);
                    typeName = property.Name;
                }
                else if (property.Value.Type == JTokenType.Array)
                {
                    var array = property.Value as JArray;
                    if (array.Count > 0 && array[0].Type == JTokenType.Object)
                    {
                        GenerateClassFromJObject((JObject)array[0], property.Name);
                        typeName = $"List<{property.Name}>";
                    }
                    else
                    {
                        typeName = $"List<{GetCSharpType(array[0].Type)}>";
                    }
                }

                properties.Add($"public {typeName} {property.Name} {{ get; set; }}");
            }

            string classDefinition = $"public class {Char.ToUpper(className[0])+className.Substring(1)}\n{{\n" + string.Join("\n", properties.Select(p => $"    {p}")) + "\n}";
            classDefinitions.Add(classDefinition);
        }

        private static string GetCSharpType(JTokenType tokenType)
        {
            switch (tokenType)
            {
                case JTokenType.String:
                    return "string";
                case JTokenType.Integer:
                    return "int";
                case JTokenType.Float:
                    return "double";
                case JTokenType.Boolean:
                    return "bool";
                case JTokenType.Array:
                    return "List<object>";
                case JTokenType.Object:
                    return "object";
                default:
                    return "object";
            }
        }
    }
}
