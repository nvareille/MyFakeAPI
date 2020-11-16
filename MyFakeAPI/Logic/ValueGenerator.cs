using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyFakeAPI.Logic
{
    public class ValueGenerator
    {
        private static int IdGenerator = 1;
        private static Random Rnd = new Random();
        private Dictionary<string, string> Model;
        private readonly Dictionary<string, Func<object>> Functions = new Dictionary<string, Func<object>>
        {
            {"string", GenerateString},
            {"int", GenerateInt},
            {"id", GenerateId},
        };

        public ValueGenerator(Dictionary<string, string> model)
        {
            Model = model;
        }

        public static object GenerateString()
        {
            return (Path.GetRandomFileName().Replace(".", ""));
        }

        public static object GenerateInt()
        {
            return (Rnd.Next(0, 10000000));
        }

        public static object GenerateId()
        {
            return (IdGenerator++);
        }

        public object Generate(string str)
        {
            return (Functions[str]());
        }

        public Dictionary<string, object> GenerateEntity()
        {
            Dictionary<string, object> obj = new Dictionary<string, object>();

            foreach (KeyValuePair<string, string> pair in Model)
            {
                obj.Add(pair.Key, Generate(pair.Value));
            }

            return (obj);
        }
    }
}
