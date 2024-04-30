// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using UCM.typechecker;

// namespace UCM.astVisitor
// {
//     public class ObjectTypeChecker
//     {
//         public TypeInfo CheckCompleteMatch(TypeInfo templateInfo, TypeInfo objectInfo)
//         {
//             if (templateInfo.type != objectInfo.type)
//             {
//                 return new TypeInfo(TypeEnum.Error);
//             }

//             if (templateInfo.type == TypeEnum.Error || objectInfo.type == TypeEnum.Error)
//             {
//                 return new TypeInfo(TypeEnum.Error);
//             }

//             if (templateInfo.subFields == null && objectInfo.subFields == null)
//             {
//                 return new TypeInfo(TypeEnum.Ok);
//             }

//             if (templateInfo.subFields!.Count != objectInfo.subFields!.Count)
//             {
//                 return new TypeInfo(TypeEnum.Error);
//             }


//             foreach (var key in templateInfo.subFields.Keys)
//             {
//                 if (!objectInfo.subFields.ContainsKey(key))
//                 {
//                     return new TypeInfo(TypeEnum.Error);
//                 }

//                 TypeInfo subObjectTypeInfo = objectInfo.subFields[key];
//                 TypeInfo subTemplateTypeInfo = templateInfo.subFields[key];

//                 if (subObjectTypeInfo.type != subTemplateTypeInfo.type)
//                 {
//                     return new TypeInfo(TypeEnum.Error);
//                 }

//                 if (subObjectTypeInfo.subFields != null || subTemplateTypeInfo.subFields != null)
//                 {
//                     TypeInfo result = CheckCompleteMatch(subTemplateTypeInfo, subObjectTypeInfo);
//                     if (result.type == TypeEnum.Error)
//                     {
//                         return new TypeInfo(TypeEnum.Error);
//                     }
//                 }

//             }

//             return new TypeInfo(TypeEnum.Ok);
//         }

//         public TypeInfo CheckPartialMatch(TypeInfo templateInfo, TypeInfo objectInfo)
//         {
//             if (templateInfo.type != objectInfo.type)
//             {
//                 return new TypeInfo(TypeEnum.Error);
//             }

//             if (templateInfo.type == TypeEnum.Error || objectInfo.type == TypeEnum.Error)
//             {
//                 return new TypeInfo(TypeEnum.Error);
//             }

//             if (objectInfo.subFields == null)
//             {
//                 return new TypeInfo(TypeEnum.Ok);
//             }

//             if (templateInfo.subFields == null)
//             {
//                 return new TypeInfo(TypeEnum.Error);
//             }

//             foreach (string key in objectInfo.subFields.Keys)
//             {
//                 if (!templateInfo.subFields.ContainsKey(key))
//                 {
//                     return new TypeInfo(TypeEnum.Error);
//                 }

//                 TypeInfo subObjectTypeInfo = objectInfo.subFields[key];
//                 TypeInfo subTemplateTypeInfo = templateInfo.subFields[key];

//                 if (subObjectTypeInfo.type != subTemplateTypeInfo.type)
//                 {
//                     return new TypeInfo(TypeEnum.Error);
//                 }

//                 if (subObjectTypeInfo.subFields != null || subTemplateTypeInfo.subFields != null)
//                 {
//                     TypeInfo result = CheckCompleteMatch(subTemplateTypeInfo, subObjectTypeInfo);
//                     if (result.type == TypeEnum.Error)
//                     {
//                         return new TypeInfo(TypeEnum.Error);
//                     }
//                 }
//             }

//             return new TypeInfo(TypeEnum.Ok);
//         }

//     }
// }