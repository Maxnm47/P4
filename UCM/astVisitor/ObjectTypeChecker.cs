using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.typechecker;

namespace UCM.astVisitor
{
    public class ObjectTypeChecker
    {
        public TypeInfo CheckObjectType(TypeInfo templateInfo, TypeInfo objectInfo)
        {
            if (templateInfo.type != objectInfo.type)
            {
                return new TypeInfo(TypeEnum.Error);
            }

            if (templateInfo.subFields == null && objectInfo.subFields == null)
            {
                return new TypeInfo(TypeEnum.Ok);
            }

            if (templateInfo.subFields!.Count != objectInfo.subFields!.Count)
            {
                return new TypeInfo(TypeEnum.Error);
            }

            for (int i = 0; i < templateInfo.subFields!.Count; i++)
            {
                TypeInfo templateField = templateInfo.subFields[i];
                TypeInfo objectField = objectInfo.subFields[i];

                if (templateField.fieldKey != objectField.fieldKey)
                {
                    return new TypeInfo(TypeEnum.Error);
                }

                if (templateField.type != objectField.type)
                {
                    return new TypeInfo(TypeEnum.Error);
                }

                if (templateField.subFields != null || objectField.subFields != null)
                {
                    TypeInfo result = CheckObjectType(templateField, objectField);
                    if (result.type == TypeEnum.Error)
                    {
                        return new TypeInfo(TypeEnum.Error);
                    }
                }
            }

            return new TypeInfo(TypeEnum.Ok);
        }
    }
}