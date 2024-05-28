using UCM.typeEnum;

namespace UCM.astVisitor
{
    public class TypeInfo
    {
        public TypeEnum type;
        // public string? fieldKey;
        public string? templateId;
        public bool isHidden = false;
        public TypeInfo? arrayType;
        public TypeInfo(TypeEnum type, string? templateId = null, bool isHidden = false, TypeInfo? arrayType = null)
        {
            this.type = type;
            // this.fieldKey = fieldKey;
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
                   //    fieldKey == other.fieldKey &&
                   templateId == other.templateId &&
                   isHidden == other.isHidden &&
                   (arrayType != null && arrayType.Equals(other.arrayType) || arrayType == null && other.arrayType == null);
        }
    }
}