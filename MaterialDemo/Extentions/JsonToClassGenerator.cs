using Newtonsoft.Json.Linq;

namespace MaterialDemo.Extentions
{
    public class JsonToClassGenerator
    {
        public static Dictionary<string, string> GenerateClass(string jsonString, string className, out string message)
        {
            try
            {
                var jsonObject = JObject.Parse(jsonString);
                classMap.Clear();
                GenerateClassFromJObject(jsonObject, className);
                message = string.Empty;
                return classMap;
            }
            catch (Newtonsoft.Json.JsonReaderException e)
            {
                message = e.Message;
                return null;
            }
        }
        private static Dictionary<string, string> classMap = new Dictionary<string, string>();
        private static void GenerateClassFromJObject(JObject jsonObject, string className)
        {
            var properties = new List<string>();

            foreach (var property in jsonObject.Properties())
            {
                string typeName = GetCSharpType(property.Value.Type);
                if (property.Value.Type == JTokenType.Object)
                {
                    GenerateClassFromJObject((JObject)property.Value, property.Name);
                    typeName = char.ToUpper(property.Name[0]) + property.Name.Substring(1);
                }
                else if (property.Value.Type == JTokenType.Array)
                {
                    var array = property.Value as JArray;
                    if (array.Count > 0 && array[0].Type == JTokenType.Object)
                    {
                        GenerateClassFromJObject((JObject)array[0], property.Name);
                        typeName = $"List<{char.ToUpper(property.Name[0]) + property.Name.Substring(1)}>";
                    }
                    else
                    {
                        typeName = $"List<{GetCSharpType(array[0].Type)}>";
                    }
                }

                properties.Add($"public {typeName} {property.Name} {{ get; set; }}");
            }
            className = char.ToUpper(className[0]) + className.Substring(1);
            string classDefinition = $"public class {className}\n{{\n" + string.Join("\n", properties.Select(p => $"    {p}")) + "\n}";
            if (classMap.ContainsKey(className))
            {
                if (classMap[className].Length < classDefinition.Length)
                {
                    classMap[className] = classDefinition;
                }
            }
            else
            {
                classMap.Add(className, classDefinition);
            }
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
