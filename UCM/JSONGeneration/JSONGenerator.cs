using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using UCM.astJunior;

namespace UCM.JSONGeneration
{
    public class JSONGenerator : JAstVisitor<string>
    {
        public override string VisitObject(JObjectNode objectNode)
        {
            return "{" + string.Join(", ", objectNode.Fields.Select(Visit)) + "}";
        }

        public override string VisitField(JFieldNode fieldNode)
        {
            return $"\"{fieldNode.Key.Value}\": {Visit(fieldNode.Value)}";
        }

        public override string VisitInt(JIntNode intNode)
        {
            return intNode.Value.ToString();
        }

        public override string VisitFloat(JFloatNode floatNode)
        {
            return floatNode.Value.ToString("G", CultureInfo.InvariantCulture);
        }

        public override string VisitNull(JNullNode nullNode)
        {
            return "null";
        }

        public override string VisitBool(JBoolNode boolNode)
        {
            return boolNode.Value.ToString().ToLower();
        }

        public override string VisitArray(JArrayNode arrayNode)
        {
            return "[" + string.Join(", ", arrayNode.Elements.Select(Visit)) + "]";
        }

        public override string VisitString(JStringNode stringNode)
        {
            return $"\"{stringNode.Value}\"";
        }
    }
}