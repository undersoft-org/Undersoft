namespace Undersoft.SDK.Rubrics
{

    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using Undersoft.SDK;
    using Undersoft.SDK.Invoking;
    using Uniques;

    public class MemberRubric : MemberInfo, IRubric
    {
        Uscn code = Uscn.Empty;
        IOrigin origin = new Origin();
        public object deltamark;
        public bool deltamarkset = false;
        public string label;

        public MemberRubric()
        {
        }

        public MemberRubric(FieldInfo field) : this((IMemberRubric)new FieldRubric(field)) { }

        public MemberRubric(FieldRubric field) : this((IMemberRubric)field) { }

        public MemberRubric(IMemberRubric member) : this()
        {
            RubricInfo = (MemberInfo)member;
            RubricName = member.RubricName;
            RubricId = member.RubricId;
            Visible = member.Visible;
            Editable = member.Editable;
            if (RubricInfo.MemberType == MemberTypes.Method)
                Id = $"{RubricName}_{new string(RubricParameterInfo.SelectMany(p => p.ParameterType.Name).ToArray())}"
                .UniqueKey64();
            else
                Id = RubricName.UniqueKey64();
        }

        public MemberRubric(MethodInfo method) : this((IMemberRubric)new MethodRubric(method)) { }

        public MemberRubric(MethodRubric method) : this((IMemberRubric)method) { }

        public MemberRubric(PropertyInfo property)
            : this((IMemberRubric)new PropertyRubric(property)) { }

        public MemberRubric(PropertyRubric property) : this((IMemberRubric)property) { }

        public MemberRubric(MemberRubric member, bool copyMode = false)
            : this(
                !copyMode && member.RubricInfo != null
                    ? (IMemberRubric)member.RubricInfo
                    : member
            )
        {
            InstantType = member.InstantType;
            InstantField = member.InstantField;
            FieldId = member.FieldId;
            RubricOffset = member.RubricOffset;
            IsKey = member.IsKey;
            IsIdentity = member.IsIdentity;
            IsAutoincrement = member.IsAutoincrement;
            IdentityOrder = member.IdentityOrder;
            Required = member.Required;
            DisplayName = member.DisplayName;
            RubricSize = member.RubricSize;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override object[] GetCustomAttributes(bool inherit)
        {
            return RubricInfo.GetCustomAttributes(inherit);
        }

        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            return RubricInfo.GetCustomAttributes(attributeType, inherit);
        }

        public override bool IsDefined(Type attributeType, bool inherit)
        {
            return RubricInfo.IsDefined(attributeType, inherit);
        }

        public MemberRubric ShalowCopy(MemberRubric dst)
        {
            if (dst == null)
                dst = new MemberRubric();
            dst.RubricInfo = this;
            dst.RubricName = RubricName;
            dst.RubricId = RubricId;
            dst.Visible = Visible;
            dst.Editable = Editable;
            dst.LinkValue = LinkValue;
            dst.LinkOperation = LinkOperation;
            dst.InvokeTarget = InvokeTarget;
            dst.InvokeMethod = InvokeMethod;
            dst.InvokeType = InvokeType;
            dst.InstantType = InstantType;
            dst.Invoker = Invoker;
            dst.InstantField = InstantField;
            dst.FieldId = FieldId;
            dst.RubricOffset = RubricOffset;
            dst.IsKey = IsKey;
            dst.IsIdentity = IsIdentity;
            dst.IsAutoincrement = IsAutoincrement;
            dst.IdentityOrder = IdentityOrder;
            dst.Required = Required;
            dst.DisplayName = DisplayName;
            dst.IsLink = IsLink;
            dst.Id = RubricName.UniqueKey64();

            return dst;
        }

        public MemberRubric CopyAttributeValues(MemberRubric dst)
        {
            if (dst == null)
                dst = new MemberRubric();
            dst.RubricInfo = this;
            dst.RubricName = RubricName;
            dst.Visible = Visible;
            dst.Editable = Editable;
            dst.LinkValue = LinkValue;
            dst.LinkOperation = LinkOperation;
            dst.InvokeTarget = InvokeTarget;
            dst.InvokeMethod = InvokeMethod;
            dst.InvokeType = InvokeType;
            dst.InstantType = InstantType;
            dst.Invoker = Invoker;
            dst.RubricOffset = RubricOffset;
            dst.IsKey = IsKey;
            dst.IsIdentity = IsIdentity;
            dst.IsAutoincrement = IsAutoincrement;
            dst.IdentityOrder = IdentityOrder;
            dst.Required = Required;
            dst.DisplayName = DisplayName;
            dst.IsLink = IsLink;
            return dst;
        }

        public long AutoId()
        {
            return origin.AutoId();
        }

        public byte GetPriority()
        {
            return origin.GetPriority();
        }

        TEntity IOrigin.Sign<TEntity>(TEntity entity)
        {
            return origin.Sign(entity);
        }

        TEntity IOrigin.Stamp<TEntity>(TEntity entity)
        {
            return origin.Stamp(entity);
        }

        public long SetId(long id)
        {
            return origin.SetId(id);
        }

        public long SetId(object id)
        {
            return origin.SetId(id);
        }

        public bool Equals(IUnique other)
        {
            return ((IEquatable<IUnique>)code).Equals(other);
        }

        public int CompareTo(IUnique other)
        {
            return ((IComparable<IUnique>)code).CompareTo(other);
        }

        public void GetFlag(StateFlags state)
        {
            origin.GetFlag(state);
        }

        public void SetFlag(StateFlags state, bool flag)
        {
            origin.SetFlag(state, flag);
        }

        public override Type DeclaringType =>
            InstantType != null ? InstantType : RubricInfo.DeclaringType;

        public string DisplayName { get; set; }

        public bool Editable { get; set; }

        public IUnique Empty => Uscn.Empty;

        public int FieldId { get; set; }

        public FieldInfo InstantField { get; set; }

        public Type InstantType { get; set; }

        public MethodInfo Getter =>
            MemberType == MemberTypes.Property ? ((PropertyRubric)RubricInfo).GetMethod : null;

        public short IdentityOrder { get; set; }

        public bool IsAutoincrement { get; set; }

        public bool IsDBNull { get; set; }

        public bool Expandable { get; set; }

        public bool IsIdentity { get; set; }

        public bool IsLink { get; set; }

        public bool IsKey { get; set; }

        public bool IsUnique { get; set; }

        public string LinkValue { get; set; }

        public OperationType LinkOperation { get; set; }

        public string InvokeMethod { get; set; }

        public string InvokeTarget { get; set; }

        public Type InvokeType { get; set; }

        public IInvoker Invoker { get; set; }

        public MemberInfo MemberInfo => RubricInfo;

        public override MemberTypes MemberType => RubricInfo.MemberType;

        public override string Name => RubricInfo.Name;

        public override Type ReflectedType => RubricInfo.ReflectedType;

        public bool Required { get; set; }

        public object[] RubricAttributes
        {
            get => (VirtualInfo != null) ? VirtualInfo.RubricAttributes : null;
            set { if (VirtualInfo != null) VirtualInfo.RubricAttributes = value; }
        }

        public int RubricId { get => OriginId; set => OriginId = value; }

        public MemberInfo RubricInfo { get; set; }

        public Module RubricModule =>
            MemberType == MemberTypes.Method ? ((MethodRubric)RubricInfo).RubricModule : null;

        public string RubricName { get; set; }

        public int RubricOffset { get; set; }

        public ParameterInfo[] RubricParameterInfo =>
            MemberType == MemberTypes.Method
                ? ((MethodRubric)RubricInfo).RubricParameterInfo
                : null;

        public Type RubricReturnType =>
            MemberType == MemberTypes.Method ? ((MethodRubric)RubricInfo).RubricReturnType : null;

        public MemberRubrics Rubrics { get; set; }

        public int RubricSize
        {
            get => VirtualInfo.RubricSize;
            set => VirtualInfo.RubricSize = value;
        }

        public Type RubricType
        {
            get => VirtualInfo.RubricType;
            set => VirtualInfo.RubricType = value;
        }

        public MethodInfo Setter =>
            MemberType == MemberTypes.Property ? ((PropertyRubric)RubricInfo).SetMethod : null;

        public AggregationOperand AggregationOperand { get; set; }

        public int AggregationOrdinal { get; set; }

        public IRubric AggregateRubric { get; set; }

        public IMemberRubric VirtualInfo => (IMemberRubric)RubricInfo;

        public bool Visible { get; set; }

        public string CodeNo { get => code.ToString(); set => code.FromTetrahex(value.ToCharArray()); }

        public DateTime Created { get; set; }

        public string Creator { get; set; }

        public long Id { get => code.Id; set => code.Id = value; }

        public long TypeId { get => code.TypeId; set => code.TypeId = value; }

        public DateTime Modified { get; set; }

        public string Modifier { get; set; }

        public int OriginId { get => (int)code.OriginId; set => code.OriginId = (uint)value; }

        public string TypeName { get; set; }

        public DateTime Time { get => DateTime.FromBinary(code.Time); set => code.Time = value.ToBinary(); }

        public string Label { get => label ??= DisplayName ?? RubricName; set => label = value; }
    }
}
