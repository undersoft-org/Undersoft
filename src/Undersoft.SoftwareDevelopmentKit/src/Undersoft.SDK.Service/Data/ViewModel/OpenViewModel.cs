using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Undersoft.SDK.Service.Data.Entity;

using Identifier;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SDK.Service.Data.ViewModel;

[DataContract]
[StructLayout(LayoutKind.Sequential)]
public class OpenViewModel<TViewModel, TDetail, TSetting, TGroup> : DataObject, IViewModel
    where TViewModel : IDataObject
    where TDetail : class, IDetail, new()
    where TSetting : class, ISetting, new()
    where TGroup : struct, Enum
{
    private static IRubrics detailRubrics;
    private static IRubrics settingRubrics;

    public OpenViewModel() : base()
    {
        GetOpenRubrics();
    }

    [DataMember(Order = 12)]
    public virtual Identifiers<TViewModel> Identifiers { get; set; }

    [Details]
    [DataMember(Order = 13)]
    public virtual Details<TDetail> Details
    {
        get => new Details<TDetail>(GetOpenProperties<TDetail>(detailRubrics));
        set => SetOpenProperties<TDetail>(value);
    }

    [Settings]
    [DataMember(Order = 14)]
    public virtual Settings<TSetting> Settings
    {
        get => new Settings<TSetting>(GetOpenProperties<TSetting>(settingRubrics));
        set => SetOpenProperties<TSetting>(value);
    }

    [DataMember(Order = 15)]
    public virtual TGroup Group { get; set; }

    private IEnumerable<T> GetOpenProperties<T>(IRubrics openRubrics)
        where T : class, IDetail, new()
    {
        foreach (var r in openRubrics)
        {
            var detailMember = ((IInnerProxy)this)[r.RubricId];
            if (detailMember != null)
            {
                var objectDetail = new T() { Name = r.RubricName };
                objectDetail.SetDocument(detailMember);
                yield return objectDetail;
            }
        }
        ;
    }

    private void SetOpenProperties<T>(IEnumerable<T> openObjects) where T : class, IDetail, new()
    {
        openObjects.ForEach((o) => ((IInnerProxy)this)[o.Name] = o.GetObject());
    }

    private void GetOpenRubrics()
    {
        if (detailRubrics == null)
        {
            detailRubrics = new MemberRubrics(
                this.Proxy.Rubrics.Where(
                    r =>
                        r.CustomAttributes
                            .Select(c => c.AttributeType)
                            .Contains(typeof(DetailAttribute))
                )
            );
            settingRubrics = new MemberRubrics(
                this.Proxy.Rubrics.Where(
                    r =>
                        r.CustomAttributes
                            .Select(c => c.AttributeType)
                            .Contains(typeof(SettingAttribute))
                )
            );
        }
    }
}
