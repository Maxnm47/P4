using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using UCM.astJunior;

namespace UCM.YAMLGeneration
{
    public class YamlGenerator : JAstVisitor<string>
    {
        string indent = "";
        public override string VisitObject(JObjectNode objectNode)
        {
            indent += "  ";
            string fields = string.Join(indent, objectNode.Fields.Select(Visit));
            indent = indent.Remove(indent.Length - 2);
            return fields;
        }

        public override string VisitField(JFieldNode fieldNode)
        {
            if (fieldNode.Value is JObjectNode)
            {
                return $"{fieldNode.Key.Value}: \n {Visit(fieldNode.Value)}";
            }

            if (fieldNode.Value is JArrayNode)
            {
                return $"{fieldNode.Key.Value}:  \n {Visit(fieldNode.Value)}";
            }

            return $"{fieldNode.Key.Value}: {Visit(fieldNode.Value)} \n";
        }

        public override string VisitInt(JIntNode intNode)
        {
            return intNode.Value.ToString();
        }

        public override string VisitNull(JNullNode jNullNode)
        {
            return "null";
        }

        public override string VisitFloat(JFloatNode floatNode)
        {
            return floatNode.Value.ToString(CultureInfo.InvariantCulture);
        }

        public override string VisitBool(JBoolNode boolNode)
        {
            return boolNode.Value.ToString().ToLower();
        }

        public override string VisitArray(JArrayNode arrayNode)
        {

            string elements = indent + "- " + string.Join(indent + "- ", arrayNode.Elements.Select(Visit));

            return elements;
        }

        public override string VisitString(JStringNode stringNode)
        {
            return stringNode.Value;
        }
    }
}