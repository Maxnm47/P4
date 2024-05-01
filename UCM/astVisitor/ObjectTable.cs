using UCM.typechecker;

namespace UCM.astVisitor
{
    public class TypeInfo
    {
        public TypeEnum type;
        public string? fieldKey;
        public string? templateId;
        public bool? isHidden;
        public TypeInfo? arrayType;
        public TypeInfo(TypeEnum type, string? fieldKey = null, string? templateId = null, bool? isHidden = null, TypeInfo? arrayType = null)
        {
            this.type = type;
            this.fieldKey = fieldKey;
            this.templateId = templateId;
            this.isHidden = isHidden;
            this.arrayType = arrayType;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TypeInfo other = (TypeInfo)obj;

            return type == other.type &&
                   fieldKey == other.fieldKey &&
                   templateId == other.templateId &&
                   isHidden == other.isHidden &&
                   (arrayType != null && arrayType.Equals(other.arrayType) || arrayType == null && other.arrayType == null);
        }
    }
}