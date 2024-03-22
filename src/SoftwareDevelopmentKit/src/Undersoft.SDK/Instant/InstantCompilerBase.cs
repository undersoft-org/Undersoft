namespace Undersoft.SDK.Instant
{
    using Rubrics.Attributes;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.InteropServices;
    using Undersoft.SDK.Instant.Attributes;
    using Undersoft.SDK.Rubrics;

    public class InstantCompilerBase : InstantCompilerBaseConstructors
    {
        public SortedList<short, MemberRubric> Identities = new SortedList<short, MemberRubric>();

        public MemberRubric ResolveMemberAttributes(FieldBuilder fb, MemberInfo mi, MemberRubric mr)
        {
            if (
                !(((IMemberRubric)mi).MemberInfo is FieldBuilder)
                && !(((IMemberRubric)mi).MemberInfo is PropertyBuilder)
            )
            {
                mi = ((IMemberRubric)mi).MemberInfo;

                resolveInstantCreatorKeyAttributes(fb, mi, mr);

                resolveInstantCreatorIdentityAttributes(fb, mi, mr);

                resolveInstantCreatorRquiredAttributes(fb, mi, mr);

                resolveInstantCreatorVisibleAttributes(fb, mi, mr);

                resolveInstantCreatorDisplayAttributes(fb, mi, mr);

                resolveInstantCreatorAggregateAttributes(fb, mi, mr);

                resolveInstantCreatorExpandAttributes(fb, mi, mr);

                resolveInstantCreatorFileAttributes(fb, mi, mr);

                resolveInstantCreatorLinkAttributes(fb, mi, mr);

                resolveInstantCreatorInvokeAttributes(fb, mi, mr);

                resolveInstantCreatorIconAttributes(fb, mi, mr);
            }
            return mr;
        }

        public void ResolveMarshalAsAttributeForArray(FieldBuilder field, MemberRubric member, Type type)
        {
            MemberInfo _member = member.RubricInfo;
            if ((member is MemberRubric) && (member.InstantField != null))
            {
                _member = member.InstantField;
            }

            object[] o = _member.GetCustomAttributes(typeof(MarshalAsAttribute), false);
            if ((o == null) || !o.Any())
            {
                o = _member.GetCustomAttributes(typeof(InstantAsAttribute), false);
                if ((o != null) && o.Any())
                {
                    InstantAsAttribute faa = (InstantAsAttribute)o.First();
                    CreateInstantCreatorAsAttribute(
                        field,
                        new InstantAsAttribute(UnmanagedType.ByValArray)
                        {
                            SizeConst = (faa.SizeConst < 1) ? 64 : faa.SizeConst
                        }
                    );
                }
                else
                {
                    int size = 64;
                    if (member.RubricSize > 0)
                        size = member.RubricSize;
                    CreateInstantCreatorAsAttribute(
                        field,
                        new InstantAsAttribute(UnmanagedType.ByValArray) { SizeConst = size }
                    );
                }
            }
            else
            {
                MarshalAsAttribute maa = (MarshalAsAttribute)o.First();
                CreateMarshaAslAttribute(
                    field,
                    new MarshalAsAttribute(UnmanagedType.ByValArray)
                    {
                        SizeConst = (maa.SizeConst < 1) ? 64 : maa.SizeConst
                    }
                );
            }
        }

        public void ResolveMarshalAsAttributeForString(FieldBuilder field, MemberRubric member, Type type)
        {
            MemberInfo _member = member.RubricInfo;
            if ((member is MemberRubric) && (member.InstantField != null))
            {
                _member = member.InstantField;
            }

            object[] o = _member.GetCustomAttributes(typeof(MarshalAsAttribute), false);
            if ((o == null) || !o.Any())
            {
                o = _member.GetCustomAttributes(typeof(InstantAsAttribute), false);
                if ((o != null) && o.Any())
                {
                    InstantAsAttribute maa = (InstantAsAttribute)o.First();
                    CreateInstantCreatorAsAttribute(
                        field,
                        new InstantAsAttribute(UnmanagedType.ByValTStr)
                        {
                            SizeConst = (maa.SizeConst < 1) ? 64 : maa.SizeConst
                        }
                    );
                }
                else
                {
                    int size = 64;
                    if (member.RubricSize > 0)
                        size = member.RubricSize;
                    CreateInstantCreatorAsAttribute(
                        field,
                        new InstantAsAttribute(UnmanagedType.ByValTStr) { SizeConst = size }
                    );
                }
            }
            else
            {
                MarshalAsAttribute maa = (MarshalAsAttribute)o.First();
                CreateMarshaAslAttribute(
                    field,
                    new MarshalAsAttribute(UnmanagedType.ByValTStr)
                    {
                        SizeConst = (maa.SizeConst < 1) ? 64 : maa.SizeConst
                    }
                );
            }
        }

        public void CreateInstantCreatorAsAttribute(FieldBuilder field, InstantAsAttribute attrib)
        {
            field.SetCustomAttribute(
                new CustomAttributeBuilder(
                    MarshalAsCtor,
                    new object[] { attrib.Value },
                    new FieldInfo[] { typeof(MarshalAsAttribute).GetField("SizeConst") },
                    new object[] { attrib.SizeConst }
                )
            );
        }

        public void CreateInstantCreatorDisplayAttribute(FieldBuilder field, DisplayRubricAttribute attrib)
        {
            field.SetCustomAttribute(
                new CustomAttributeBuilder(DisplayRubricCtor, new object[] { attrib.Name })
            );
        }

        public void CreateInstantCreatorIdentityAttribute(FieldBuilder field, IdentityRubricAttribute attrib)
        {
            field.SetCustomAttribute(
                new CustomAttributeBuilder(
                    IdentityRubricCtor,
                    Type.EmptyTypes,
                    new FieldInfo[]
                    {
                    typeof(IdentityRubricAttribute).GetField("Order"),
                    typeof(IdentityRubricAttribute).GetField("IsAutoincrement")
                    },
                    new object[] { attrib.Order, attrib.IsAutoincrement }
                )
            );
        }

        public void CreateInstantCreatorKeyAttribute(FieldBuilder field, KeyRubricAttribute attrib)
        {
            field.SetCustomAttribute(
                new CustomAttributeBuilder(
                    KeyRubricCtor,
                    Type.EmptyTypes,
                    new FieldInfo[]
                    {
                    typeof(KeyRubricAttribute).GetField("Order"),
                    typeof(KeyRubricAttribute).GetField("IsAutoincrement")
                    },
                    new object[] { attrib.Order, attrib.IsAutoincrement }
                )
            );
        }

        public void CreateInstantCreatorRequiredAttribute(FieldBuilder field)
        {
            field.SetCustomAttribute(
                new CustomAttributeBuilder(RequiredRubricCtor, Type.EmptyTypes)
            );
        }

        public void CreateInstantCreatorVisibleAttribute(FieldBuilder field)
        {
            field.SetCustomAttribute(
                new CustomAttributeBuilder(VisibleRubricCtor, Type.EmptyTypes)
            );
        }

        public void CreateInstantCreatorExpandAttribute(FieldBuilder field)
        {
            field.SetCustomAttribute(
                new CustomAttributeBuilder(ExpandRubricCtor, Type.EmptyTypes)
            );
        }

        public void CreateInstantCreatorAggregateAttribute(FieldBuilder field, AggregateRubricAttribute attrib)
        {
            field.SetCustomAttribute(
                new CustomAttributeBuilder(
                    AggregateRubricCtor,
                    Type.EmptyTypes,
                    new FieldInfo[]
                    {
                    typeof(AggregateRubricAttribute).GetField("Operand")
                    },
                    new object[] { attrib.Operand }
                )
            );
        }

        public void CreateInstantCreatorLinkAttribute(FieldBuilder field, LinkAttribute attrib)
        {
            field.SetCustomAttribute(
                new CustomAttributeBuilder(
                    LinkRubricCtor,
                    Type.EmptyTypes,
                    new FieldInfo[]
                    {
                    typeof(LinkAttribute).GetField("Value"),
                    typeof(LinkAttribute).GetField("PrefixedLink"),
                    },
                    new object[] { attrib.Value, attrib.PrefixedLink }
                )
            );
        }

        public void CreateInstantCreatorFileAttribute(FieldBuilder field, FileRubricAttribute attrib)
        {
            field.SetCustomAttribute(
                new CustomAttributeBuilder(
                    FileRubricCtor,
                    Type.EmptyTypes,
                    new FieldInfo[]
                    {
                    typeof(FileRubricAttribute).GetField("Type"),
                    typeof(FileRubricAttribute).GetField("DataMember"),
                    },
                    new object[] { attrib.Type, attrib.DataMember }
                )
            );
        }

        public void CreateInstantCreatorInvokeAttribute(FieldBuilder field, InvokeAttribute attrib)
        {
            field.SetCustomAttribute(
                new CustomAttributeBuilder(
                    InvokeRubricCtor,
                    Type.EmptyTypes,
                    new FieldInfo[]
                    {
                    typeof(InvokeAttribute).GetField("Method"),
                    typeof(InvokeAttribute).GetField("Target"),
                    typeof(InvokeAttribute).GetField("Type"),
                    typeof(InvokeAttribute).GetField("Invoker")
                    },
                    new object[] { attrib.Method, attrib.Target, attrib.Type, attrib.Invoker }
                )
            );
        }

        public void CreateInstantCreatorIconAttribute(FieldBuilder field, IconRubricAttribute attrib)
        {
            field.SetCustomAttribute(
                new CustomAttributeBuilder(
                    IconRubricCtor,
                    Type.EmptyTypes,
                    new FieldInfo[]
                    {
                    typeof(IconRubricAttribute).GetField("IconMember"),
                    typeof(IconRubricAttribute).GetField("IconSlot")
                    },
                    new object[] { attrib.IconMember, attrib.IconSlot }
                )
            );
        }

        public void CreateMarshaAslAttribute(FieldBuilder field, MarshalAsAttribute attrib)
        {
            field.SetCustomAttribute(
                new CustomAttributeBuilder(
                    MarshalAsCtor,
                    new object[] { attrib.Value },
                    new FieldInfo[] { typeof(MarshalAsAttribute).GetField("SizeConst") },
                    new object[] { attrib.SizeConst }
                )
            );
        }

        void resolveInstantCreatorDisplayAttributes(FieldBuilder fb, MemberInfo mi, MemberRubric mr)
        {
            object o = mi.GetCustomAttributes(typeof(DisplayRubricAttribute), false).FirstOrDefault();
            if ((o != null))
            {
                DisplayRubricAttribute fda = (DisplayRubricAttribute)o;
                ;
                mr.DisplayName = fda.Name;

                if (fb != null)
                    CreateInstantCreatorDisplayAttribute(fb, fda);
            }
            else if (mr.DisplayName != null)
            {
                CreateInstantCreatorDisplayAttribute(fb, new DisplayRubricAttribute(mr.DisplayName));
            }
        }

        void resolveInstantCreatorIdentityAttributes(FieldBuilder fb, MemberInfo mi, MemberRubric mr)
        {
            if (!mr.IsKey)
            {
                object o = mi.GetCustomAttributes(typeof(IdentityRubricAttribute), false).FirstOrDefault();
                if ((o != null))
                {
                    IdentityRubricAttribute fia = (IdentityRubricAttribute)o;
                    mr.IsIdentity = true;
                    mr.IsAutoincrement = fia.IsAutoincrement;
                    fia.Order = (short)(Identities.Count);
                    mr.IdentityOrder = fia.Order;
                    Identities.Add(mr.IdentityOrder, mr);

                    if (fb != null)
                        CreateInstantCreatorIdentityAttribute(fb, fia);
                }
                else if (mr.IsIdentity)
                {
                    mr.IdentityOrder = (short)(Identities.Count);
                    Identities.Add(mr.IdentityOrder, mr);

                    if (fb != null)
                        CreateInstantCreatorIdentityAttribute(
                            fb,
                            new IdentityRubricAttribute
                            {
                                IsAutoincrement = mr.IsAutoincrement,
                                Order = mr.IdentityOrder
                            }
                        );
                }
            }
        }

        void resolveInstantCreatorKeyAttributes(FieldBuilder fb, MemberInfo mi, MemberRubric mr)
        {
            object o = mi.GetCustomAttributes(typeof(KeyAttribute), false).FirstOrDefault();
            if ((o == null))
                o = mi.GetCustomAttributes(typeof(KeyRubricAttribute), false).FirstOrDefault();
            else
            {
                o = new object();
                o = new KeyRubricAttribute();
            }

            if ((o != null))
            {
                KeyRubricAttribute fka = (KeyRubricAttribute)o;
                mr.IsKey = true;
                mr.IsIdentity = true;
                mr.IsAutoincrement = fka.IsAutoincrement;

                fka.Order = (short)(Identities.Count);
                mr.IdentityOrder = fka.Order;
                Identities.Add(mr.IdentityOrder, mr);

                mr.Required = true;

                if (fb != null)
                    CreateInstantCreatorKeyAttribute(fb, fka);
            }
            else if (mr.IsKey)
            {
                mr.IsIdentity = true;
                mr.Required = true;

                mr.IdentityOrder = (short)(Identities.Count);
                Identities.Add(mr.IdentityOrder, mr);

                if (fb != null)
                    CreateInstantCreatorKeyAttribute(
                        fb,
                        new KeyRubricAttribute
                        {
                            IsAutoincrement = mr.IsAutoincrement,
                            Order = mr.IdentityOrder
                        }
                    );
            }
        }

        void resolveInstantCreatorRquiredAttributes(FieldBuilder fb, MemberInfo mi, MemberRubric mr)
        {
            object o = mi.GetCustomAttributes(typeof(RequiredAttribute), false).FirstOrDefault();
            if ((o == null))
                o = mi.GetCustomAttributes(typeof(RequiredRubricAttribute), false).FirstOrDefault();
            else
            {
                o = new object();
                o = new RequiredRubricAttribute();
            }

            if ((o != null))
            {
                mr.Required = true;

                if (fb != null)
                    CreateInstantCreatorRequiredAttribute(fb);
            }
            else if (mr.Required)
            {
                if (fb != null)
                    CreateInstantCreatorRequiredAttribute(fb);
            }
        }

        void resolveInstantCreatorVisibleAttributes(FieldBuilder fb, MemberInfo mi, MemberRubric mr)
        {
            object o = mi.GetCustomAttributes(typeof(VisibleRubricAttribute), false).FirstOrDefault();
            if ((o != null))
            {
                mr.Visible = true;

                if (fb != null)
                    CreateInstantCreatorVisibleAttribute(fb);
            }
            else if (mr.Visible)
            {
                if (fb != null)
                    CreateInstantCreatorVisibleAttribute(fb);
            }
        }

        void resolveInstantCreatorExpandAttributes(FieldBuilder fb, MemberInfo mi, MemberRubric mr)
        {
            object o = mi.GetCustomAttributes(typeof(ExpandRubricAttribute), false).FirstOrDefault();
            if ((o != null))
            {
                mr.Expandable = true;

                if (fb != null)
                    CreateInstantCreatorExpandAttribute(fb);
            }
            else if (mr.Expandable)
            {
                if (fb != null)
                    CreateInstantCreatorExpandAttribute(fb);
            }
        }

        void resolveInstantCreatorAggregateAttributes(FieldBuilder fb, MemberInfo mi, MemberRubric mr)
        {
            object o = mi.GetCustomAttributes(typeof(AggregateRubricAttribute), false).FirstOrDefault();
            if ((o != null))
            {
                AggregateRubricAttribute fta = (AggregateRubricAttribute)o;
                ;

                mr.AggregationOperand = fta.Operand;

                if (fb != null)
                    CreateInstantCreatorAggregateAttribute(fb, fta);
            }
            else if (mr.AggregationOperand != AggregationOperand.None)
            {
                CreateInstantCreatorAggregateAttribute(
                    fb,
                    new AggregateRubricAttribute { Operand = mr.AggregationOperand }
                );
            }
        }

        void resolveInstantCreatorFileAttributes(FieldBuilder fb, MemberInfo mi, MemberRubric mr)
        {
            object o = mi.GetCustomAttributes(typeof(FileRubricAttribute), false).FirstOrDefault();
            if ((o != null))
            {
                FileRubricAttribute fta = (FileRubricAttribute)o;

                mr.IsFile = true;
                mr.FileType = fta.Type;
                mr.DataMember = fta.DataMember;

                if (fb != null)
                    CreateInstantCreatorFileAttribute(fb, fta);
            }
            else if (mr.IsFile || mr.FileType != FileRubricType.None)
            {
                CreateInstantCreatorFileAttribute(
                    fb,
                    new FileRubricAttribute() { Type = mr.FileType, DataMember = mr.DataMember }
                );
            }
        }

        void resolveInstantCreatorLinkAttributes(FieldBuilder fb, MemberInfo mi, MemberRubric mr)
        {
            object o = mi.GetCustomAttributes(typeof(LinkAttribute), false).FirstOrDefault();
            if ((o != null))
            {
                LinkAttribute fta = (LinkAttribute)o;

                mr.LinkValue = fta.Value;
                mr.PrefixedLink = fta.PrefixedLink;
                mr.IsLink = true;

                if (fb != null)
                    CreateInstantCreatorLinkAttribute(fb, fta);
            }
            else if (mr.LinkValue != null)
            {
                CreateInstantCreatorLinkAttribute(
                    fb,
                    new LinkAttribute() { Value = mr.LinkValue, PrefixedLink = mr.PrefixedLink }
                );
            }
        }

        void resolveInstantCreatorIconAttributes(FieldBuilder fb, MemberInfo mi, MemberRubric mr)
        {
            object o = mi.GetCustomAttributes(typeof(IconRubricAttribute), false).FirstOrDefault();
            if ((o != null))
            {
                IconRubricAttribute fta = (IconRubricAttribute)o;

                mr.IconMember = fta.IconMember;
                mr.IconSlot = fta.IconSlot;

                if (fb != null)
                    CreateInstantCreatorIconAttribute(fb, fta);
            }
            else if (mr.IconMember != null)
            {
                CreateInstantCreatorIconAttribute(
                   fb,
                   new IconRubricAttribute(mr.IconMember, mr.IconSlot)
               );
            }
        }

        void resolveInstantCreatorInvokeAttributes(FieldBuilder fb, MemberInfo mi, MemberRubric mr)
        {
            object o = mi.GetCustomAttributes(typeof(InvokeAttribute), false).FirstOrDefault();
            if ((o != null))
            {
                InvokeAttribute fta = (InvokeAttribute)o;

                mr.InvokeMethod = fta.Method;
                mr.InvokeTarget = fta.Target;
                mr.InvokeType = fta.Type;
                mr.Invoker = fta.Invoker;

                if (fb != null)
                    CreateInstantCreatorInvokeAttribute(fb, fta);
            }
            else if (mr.InvokeMethod != null && mr.InvokeType != null)
            {
                CreateInstantCreatorInvokeAttribute(
                   fb,
                   new InvokeAttribute(mr.InvokeType, mr.InvokeMethod)
               );
            }
            else if (mr.InvokeMethod != null && mr.InvokeTarget != null)
            {
                CreateInstantCreatorInvokeAttribute(
                    fb,
                    new InvokeAttribute(mr.InvokeTarget, mr.InvokeMethod)
                );
            }
        }
    }
}