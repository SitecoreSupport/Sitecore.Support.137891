using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics.DynamicsCrm.Models;
using Sitecore.Analytics.Model.Framework;
using System.Runtime.CompilerServices;

namespace Sitecore.Support.Analytics.DynamicsCrm.Models
{
    [Serializable]
    public class CrmContactData : Facet, ICrmContactData, IFacet, IElement, IValidatable
    {
        [CompilerGenerated]
        [Serializable]
        private sealed class <>c
		{
			public static readonly CrmContactData.<>c<>9 = new CrmContactData.<>c();
        public static Func<Guid, string> <>9__9_0;
			internal string <set_MarketingLists>b__9_0(Guid x)
        {
            return x.ToString();
        }
    }
    public Guid ContactId
    {
        get
        {
            return base.GetAttribute<Guid>("ContactId");
        }
        set
        {
            base.SetAttribute<Guid>("ContactId", value);
        }
    }
    public DateTime LastSynced
    {
        get
        {
            return base.GetAttribute<DateTime>("LastSynced");
        }
        set
        {
            base.SetAttribute<DateTime>("LastSynced", value);
        }
    }
    public ICollection<Guid> MarketingLists
    {
        get
        {
            List<Guid> list = new List<Guid>();
            string attribute = base.GetAttribute<string>("MarketingLists");
            if (attribute != null)
            {
                using (List<string>.Enumerator enumerator = attribute.Split(new char[]
                {
                        ','
                }).ToList<string>().GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Guid item = Guid.Parse(enumerator.Current);
                        list.Add(item);
                    }
                }
            }
            return list;
        }
        set
        {
            string value2 = null;
            if (value != null && value.Any<Guid>())
            {
                string arg_37_0 = ",";
                Func<Guid, string> arg_32_1;
                if ((arg_32_1 = CrmContactData.<> c.<> 9__9_0) == null)
					{
                    arg_32_1 = (CrmContactData.<> c.<> 9__9_0 = new Func<Guid, string>(CrmContactData.<> c.<> 9.< set_MarketingLists > b__9_0));
                }
                value2 = string.Join(arg_37_0, value.Select(arg_32_1));
            }
            base.SetAttribute<string>("MarketingLists", value2);
        }
    }
    public string CrmName
    {
        get
        {
            return base.GetAttribute<string>("CrmName");
        }
        set
        {
            base.SetAttribute<string>("CrmName", value);
        }
    }
    public CrmContactData()
    {
        base.EnsureAttribute<Guid>("ContactId");
        base.EnsureAttribute<string>("MarketingLists");
        base.EnsureAttribute<DateTime>("LastSynced");
        base.EnsureAttribute<string>("CrmName");
    }
}
}